using Autofac;
using KTOP.EBookReader;
using SCICT.NLP.TextProofing.SpellChecker;
using SCICT.VirastyarInlineVerifiers;
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
        private SpellChecker _spellChecker;
        private ILogger _logger;
        #endregion

        #region properties
        public BookEngineConfig Config { get; set; }
        #endregion

        #region constructors
        public BookEngine(ILogger logger)
        {
            _spellChecker = new SpellChecker();
            _logger = logger;


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
        private string FixVirtualSpaceAndPrefixSuffixes(string input) => _spellChecker.FixString(input);



        #endregion

        #region public methods
        /// <summary>
        /// Process a book and fix it by defined config
        /// </summary>
        /// <param name="bookPath"></param>
        /// <returns></returns>
        public IEBook ProcessBook(string bookPath, out Dictionary<string, List<string>> wrongSpells)
        {
            // Each file might have some spell erros, we store all them here
            var spellErrors = new Dictionary<string, List<string>>();


            IEBook book = (IEBook)_container.Resolve(GetEbookType(bookPath));
            book.LoadFile(bookPath);

            _logger.Info($"{book.Files.Count} files to process.");

            Parallel.ForEach(book.Files, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (file) =>
            {
                var errors = new List<string>();

                var fileStr = File.ReadAllText(file, Encoding.UTF8);

                if (Config.FixArabicYeKe)
                    fileStr = FixArabicKeYe(fileStr);

                if (Config.FixVirtualSpaceAndPrefixSuffixes)
                    fileStr = new SpellChecker().FixString(fileStr, errors);

                if (Config.PersianShape)
                    fileStr = PersianShape(fileStr);

                if (errors.Count > 0)
                    spellErrors.Add(file, errors);

                File.WriteAllText(file, fileStr);

                _logger.Info("processing ...");
            });

            // out paramter
            wrongSpells = spellErrors;

            _logger.Info("Proecss done");

            return book;
        }
        #endregion
    }
}
