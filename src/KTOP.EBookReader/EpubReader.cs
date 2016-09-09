using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using KTOP.Helper;


namespace KTOP.EBookReader
{
    public class EPubReader : IEBook, IEpubReader
    {
        #region fields
        private string _tempDir;
        private string _opfPath;
        private readonly List<string> _files;
        private string _rootPath;
        private bool _isLoaded = false;
        #endregion

        #region properties
        public FileInfo FileName { get; set; }

        public List<string> Files => _files;

        #endregion

        #region constructors
        public EPubReader()
        {
            _files = new List<string>();
            _tempDir = Helper.FileHelper.CreateTempDir();
        }
        #endregion

        #region methods


        public void LoadFile(string epubPath)
        {
            FileName = new FileInfo(epubPath);

            // Unzip the file
            UnPack();
            FindTextFiles();

            _isLoaded = true;
        }

        /// <summary>
        /// Epub is actually a zip file, first we need to extract its file
        /// </summary>
        private void UnPack()
        {
            ZipFile.ExtractToDirectory(FileName.FullName, _tempDir);
        }

        /// <summary>
        /// Will find book files from OPF file
        /// </summary>
        private void FindTextFiles()
        {
            // ContainerXML
            var container = XDocument.Load(FileHelper.FixPathSeperator(_tempDir + @"META-INF\container.xml"));
            var rootFile = container.XPathSelectElement("//*[local-name()='rootfile']");
            _opfPath = _tempDir + rootFile.Attribute("full-path").Value;

            // Find xhtmls
            var opf = XDocument.Load(_opfPath);
            var textItems = opf.Descendants().Where((i) => i.Attribute("media-type") != null &&
                                i.Attribute("media-type").Value == "application/xhtml+xml").ToList();

            _rootPath = new FileInfo(_opfPath).DirectoryName;

            textItems.ForEach((i) =>
            {
                var attr = i.Attribute("href");
                if (attr != null && !string.IsNullOrEmpty(attr.Value))
                {
                    var path = FileHelper.FixPathSeperator(Path.Combine(_rootPath, attr.Value));
                    if (File.Exists(path))
                        _files.Add(path);
                }
            });
        }

        /// <summary>
        /// Craete a new copy of the book
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SaveAs(string path = null)
        {
            if (!_isLoaded)
                throw new Exception("Ebook file isn't loaded yet.");

            path = string.IsNullOrEmpty(path) ? FileHelper.FileNameWithTimeStamp(FileName.FullName) : path;

            ZipFile.CreateFromDirectory(_tempDir, path, CompressionLevel.Optimal, false);
            return path;
        }
        #endregion
    }
}
