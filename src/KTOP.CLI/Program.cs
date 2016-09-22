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

        /// <summary>
        /// Create a backup file if input and output path are the same, also ask question to overwrite the file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        static bool CheckOutputPath(CommandOption inputFile, CommandOption outputFile, CommandOption overwrite)
        {
            // input file and output file are the same, make a backup
            if (Path.GetFullPath(inputFile.Value()) == Path.GetFullPath(outputFile.Value()))
            {
                File.Copy(inputFile.Value(), FileHelper.FileNameWithTimeStamp(inputFile.Value() + ".bak"), true);
                return true;
            }

            // output file might be exists, we need to ask a permission to overwrite it
            if (File.Exists(outputFile.Value()) && !overwrite.HasValue())
            {
                Console.WriteLine($"Warning: The output file already exists. Overwrite it? (y/n)");
                while (true)
                {
                    var overwriteInput = Console.ReadLine().ToLower();

                    // abort the opertaion
                    if (overwriteInput[0] == 'n')
                    {
                        Console.WriteLine("Operation was canceled by user.");
                        return false;
                    }

                    if (overwriteInput[0] == 'y')
                        return true;
                }
            }

            return true;
        }

        /// <summary>
        /// CLI
        /// </summary>
        /// <returns></returns>
        static CommandLineApplication CreateCommandLineInterface()
        {
            var cli = new CommandLineApplication
            {
                Name = "ktop",
                FullName = "KTOP - Kindle Text Optimization for Persian eBooks By Ali Bahraminezhad\r\nhttps://github.com/al1b/KTOP"
            };

            cli.HelpOption("-?|-h|--help");
            cli.Description = "Evaluates arguments with the operation specified.";

            // options
            var noOptOption = cli.Option("-n|--no-optimize", "Will not optmize the eBook.", CommandOptionType.NoValue);
            var fixArabicOption = cli.Option("-f|--fix-arabic-yeh-kaf", "Replace all Arabic Yeh and Kaf with Persian ones.", CommandOptionType.NoValue);

            var inputFile = cli.Option("-i|--input", "(Required)The path of input file.", CommandOptionType.SingleValue);
            var outputFile = cli.Option("-o|--output", "(Optional)Path of output file.", CommandOptionType.SingleValue);

            var overwrite = cli.Option("-r|--overwrite", "Overwrite the output file if output file already exists", CommandOptionType.NoValue);

            // commands
            cli.OnExecute(() =>
            {
                // input file is absolutely required, proccess cannot continue without file
                if (inputFile.HasValue() == false || string.IsNullOrEmpty(inputFile.Value()))
                {
                    cli.ShowHelp();
                    return 1;
                }

                // check output file
                if (outputFile.HasValue() && !CheckOutputPath(inputFile, outputFile, overwrite))
                    return 0;

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
                    var book = bookEngine.ProcessBook(inputFile.Value());
                    var outputPath = outputFile.HasValue() ? outputFile.Value() : null;
                    var savedPath = book.SaveAs();

                    if (outputPath != null)
                    {
                        File.Copy(savedPath, outputPath, true);
                        File.Delete(savedPath);
                        savedPath = Path.GetFullPath(outputPath);
                    }

                    Console.WriteLine($"Congratulations, operation was successful, File saved at '{savedPath}'.");
                }
                catch (Base.Exceptions.EBookFormatNotSupported ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Could not find file '{inputFile.Value()}'.");
                    return 0;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"File '{inputFile.Value()}' access denied.");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, unfortunatelly something went wrong. You can check log file next to your epub file");

                    var logPath = FileHelper.LogFileName(inputFile.Value(), "errors.txt");
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


            // return cli
            return cli;
        }

    }
}
