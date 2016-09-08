using Autofac;
using KTOP.Base;
using KTOP.Helper;
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
            Console.WriteLine("KTOP - Kindle Text Optimization for Persian eBooks By Ali Bahraminezhad\r\nhttps://github.com/al1b/KTOP\r\n");

            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<BookEngine>().As<IBookEngine>();
            var container = builder.Build();

            var watch = new Stopwatch();
            watch.Start();

            try
            {
                args = args.Where((a) => a.Trim() != string.Empty)
                           .ToArray();

                if (args.Length == 0 || args[0] == "--help" || args[1] == "-h" || args[0] == "/?")
                {
                    PrintHelp();
                    return;
                }

                var bookEngine = container.Resolve<IBookEngine>();
                bookEngine.Config = CreateConfig(args);

                Console.WriteLine("Begin optimizing the book, this might takes minutes, please wait ...");
                var book = bookEngine.ProcessBook(args[0]);

                var path = book.SaveAs(null);

                watch.Stop();
                Console.WriteLine($"The book has successfully optmized in {watch.Elapsed.Minutes} minutes and {watch.Elapsed.Seconds} seconds.\r\n");
                Console.WriteLine($"File has saved in:\r\n{path}");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, unfortunatelly something went wrong. You can check log file next to your epub file");
                Console.WriteLine(ex.Message);

                File.WriteAllText(FileHelper.LogFileName(args[0], "errors.txt"), ex.Message + "\r\n" + ex.StackTrace);
            }
            finally
            {
                watch.Stop();

                Console.WriteLine("Press any key to continnue.");
                Console.ReadLine();
            }


        }

        /// <summary>
        /// Print default help
        /// </summary>
        static void PrintHelp()
        {
            var message = @"Usage:

KTOP.CLI.exe fileName  [--persian, --arabic]

--persian ( Default, recommended for Perisan eBooks)
--arabic

";

            Console.WriteLine(message);
        }
        /// <summary>
        /// Create bookengineconfig by use input
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static BookEngineConfig CreateConfig(string[] args)
        {
            if (args.Length == 1 || args[1].ToLower() == "--persian")
                return new BookEngineConfig()
                {
                    FixArabicYeKe = true,
                    FixVirtualSpaceAndPrefixSuffixes = true,
                    PersianShape = true
                };


            if (args.Length == 1 || args[1].ToLower() == "--arabic")
                return new BookEngineConfig()
                {
                    FixArabicYeKe = false,
                    FixVirtualSpaceAndPrefixSuffixes = false,
                    PersianShape = true
                };


           throw new Exceptions.ParameterException();
        }

        /// <summary>
        /// Each file might have several mistakes in spelling, this method will create a well-formed log of them
        /// </summary>
        /// <param name="erros"></param>
        /// <returns></returns>
        static string GenerateErrorSpellingLog(Dictionary<string, List<string>> erros)
        {
            var builder = new StringBuilder();

            foreach (var key in erros.Keys)
            {
                builder.AppendLine(key);
                builder.AppendLine("--------------------");
                foreach (var item in erros[key])
                    builder.AppendLine(item);

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
