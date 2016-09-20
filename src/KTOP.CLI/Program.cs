using Autofac;
using KTOP.Base;
using KTOP.Helper;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cli = CreateCommandLineInterface();

            try
            {
                cli.Execute(args);
            }
            catch (CommandParsingException)
            {
                cli.ShowHelp();
            }
        }

        static CommandLineApplication CreateCommandLineInterface()
        {
            var app = new CommandLineApplication
            {
                Name = "ktop",
                FullName = "KTOP - Kindle Text Optimization for Persian eBooks By Ali Bahraminezhad\r\nhttps://github.com/al1b/KTOP"
            };

            app.HelpOption("-?|-h|--help");
            app.Description = "Evaluates arguments with the operation specified.";

            // options
            var noOptOption = app.Option("-n|--no-optimize", "Will not optmize the eBook.", CommandOptionType.NoValue);
            var fixArabicOption = app.Option("-f|--fix-arabic-yeh-kaf", "Replace all Arabic Yeh and Kaf with Persian ones.", CommandOptionType.NoValue);

            var fileInput = app.Option("-i|--input", "(Required)The path of input file.", CommandOptionType.SingleValue);
            var fileOuput = app.Option("-o|--output", "(Optional)Path of output file.", CommandOptionType.SingleValue);

            // commands
            app.OnExecute(() =>
            {
                // input file is absolutely required, proccess cannot continue without file
                if (fileInput.HasValue() == false || string.IsNullOrEmpty(fileInput.Value()))
                {
                    app.ShowHelp();
                    return 1;
                }

                var builder = new ContainerBuilder();
                builder.RegisterType<ConsoleLogger>().As<ILogger>();
                builder.RegisterType<BookEngine>().As<IBookEngine>();
                var container = builder.Build();

                // create config 
                var bookEngine = container.Resolve<IBookEngine>();
                bookEngine.Config = new BookEngineConfig()
                {
                    FixArabicYeKe = fixArabicOption.HasValue(),
                    FixVirtualSpaceAndPrefixSuffixes = true,
                    PersianShape = !noOptOption.HasValue()
                };

                try
                {
                    var book = bookEngine.ProcessBook(fileInput.Value());
                    var outputPath = fileOuput.HasValue() ? fileOuput.Value() : null;
                    book.SaveAs(outputPath);
                }
                catch (Base.Exceptions.EBookFormatNotSupported ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Could not find file '{fileInput.Value()}'.");
                    return 0;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"File '{fileInput.Value()}' access denied.");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, unfortunatelly something went wrong. You can check log file next to your epub file");

                    var logPath = FileHelper.LogFileName(fileInput.Value(), "errors.txt");
                    if (File.Exists(logPath))
                        File.Delete(logPath);

                    do
                    {
                        File.AppendAllText(logPath, ex.Message + "\r\n" + ex.StackTrace + "\r\n--------------------------\r\n");
                        ex = ex.InnerException;
                    } while (ex != null);

                    return 0;
                }


                return 1;
            });

            return app;
        }
    }
}
