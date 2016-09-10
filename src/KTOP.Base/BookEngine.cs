using Autofac;
using KTOP.EBookReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KTOP.Base
{
    public class BookEngine : IBookEngine
    {
        #region fields
        private IContainer _container;
        private ILogger _logger;
        //private NHazm.Normalizer _normalizer;
        #endregion

        #region properties
        public BookEngineConfig Config { get; set; }
        #endregion

        #region constructors
        public BookEngine(ILogger logger)
        {
            //_spellChecker = new SpellChecker();
            _logger = logger;
            //_normalizer = new NHazm.Normalizer(true, true, true);

            RegisterTypes();
        }
        #endregion

        #region private methods
        /// <summary>
        /// Find proper interface by the file extention
        /// </summary>
        /// <param name="bookPath"></param>
        /// <returns></returns>
        private static Type GetEbookType(string bookPath)
        {
            switch (new FileInfo(bookPath).Extension.ToLower())
            {
                case ".epub":
                    return typeof(IEpubReader);
            }

            return null;
        }

        /// <summary>
        /// Init IoC container
        /// </summary>
        private void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EPubReader>().As<IEpubReader>();

            _container = builder.Build();
        }

        /// <summary>
        /// Converts "ي" to "ی" and "ك" to "ک"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string FixArabicKeYe(string input) => input.Replace("ي", "ی").Replace("ك", "ک");

        /// <summary>
        /// Convert Persian/Arabic characters into single Persian/Arabic characters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string PersianShape(string input) => ArabicShaping.ArabicLigaturizer.ArabicShape(input);

        /// <summary>
        /// Fix typing errors
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string FixVirtualSpaceAndPrefixSuffixes(string input) => input;// _spellChecker.FixString(input);



        #endregion

        #region public methods
        /// <summary>
        /// Process a book and fix it by defined config
        /// </summary>
        /// <param name="bookPath"></param>
        /// <returns></returns>
        public IEBook ProcessBook(string bookPath)
        {

            IEBook book = (IEBook)_container.Resolve(GetEbookType(bookPath));
            book.LoadFile(bookPath);

            _logger.Info($"{book.Files.Count} files to process.");

            Parallel.ForEach(book.Files, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (file) =>
            {
                var errors = new List<string>();

                var fileStr = File.ReadAllText(file, Encoding.UTF8);

                if (Config.FixArabicYeKe)
                    fileStr = FixArabicKeYe(fileStr);

                //if (Config.FixVirtualSpaceAndPrefixSuffixes)
                //    fileStr = _normalizer.Run(fileStr);

                if (Config.PersianShape)
                    fileStr = PersianShape(fileStr);


                File.WriteAllText(file, fileStr);
                _logger.Info("processing ...");
            });

            _logger.Info("Proecss done");

            return book;
        }
        #endregion
    }
}
