using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KTOP.Base;
using System.Diagnostics;
using KTOP.Helper;
using Autofac;

namespace KTOP.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<BookEngine>().As<IBookEngine>();
            var container = builder.Build();

            args = args.Where((a) => a.Trim() != string.Empty)
                       .ToArray();

            if (!Validate(args)) return;

            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var spellErros = new Dictionary<string, List<string>>();
                var bookEngine = container.Resolve<IBookEngine>();
                bookEngine.Config = CreateConfig(args);

                Console.WriteLine("Begin optimizing the book, this might takes minutes, please wait ...");
                var book = bookEngine.ProcessBook(args[0], out spellErros);

                var path = book.SaveAs(null);

                watch.Stop();
                Console.WriteLine($"The book has successfully optmized in {watch.Elapsed.Minutes} minutes and {watch.Elapsed.Seconds} seconds.\r\n");
                Console.WriteLine($"File has saved in:\r\n{path}");

                if(spellErros.Keys.Count > 0)
                {
                    var totalCount = spellErros.Sum((v) => v.Value.Count);
                    Console.WriteLine($"\r\nWarning:\r\n{totalCount} spelling error(s) has found and fixed");
                    Console.WriteLine($"Please check log file next to your book.");

                    File.WriteAllText(FileHelper.LogFileName(path, "spell-error.txt"), GenerateErrorSpellingLog(spellErros), Encoding.UTF8);
                }

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
            var message = @"Optimize any Persian right-to-left epub to increase user experience on Amazon Kindles. 

Usage:

KTOP.CLI.exe fileName  /a /cs /p 

/a	Convert all Arabic Yeh and Keh into Persian characters
/p	Convert all Persian/Arabic letters into single unicode characters
/cs Check for spelling errors (this one might takes minutes) - Persian Only

Note: The order of switches is not important.";

            Console.WriteLine(message);
        }

        /// <summary>
        /// Validate program arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static bool Validate(string[] args)
        {
            if (args.Length == 0 || args[0] == "--help" || args[1] == "-h" || args[0] == "/?")
            {
                PrintHelp();
                return false;
            }

            if (args.Length > 1 && !File.Exists(args[0]))
            {
                Console.WriteLine($"Error:\r\n`{args[0]}` is not a file path or the file is not exists.");
                return false;
            }

            if(args.Length < 2)
            {
                PrintHelp();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Create bookengineconfig by use input
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static BookEngineConfig CreateConfig(string[] args)
        {
            var config = new BookEngineConfig();

            for (var i = 1; i < args.Length; i++)
                switch (args[i].ToLower())
                {
                    case "/a":
                        config.FixArabicYeKe = true;
                        break;
                    case "/p":
                        config.PersianShape = true;
                        break;
                    case "/cs":
                        config.FixVirtualSpaceAndPrefixSuffixes = true;
                        break;
                }

            return config;
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
