using KTOP.EBookReader;
using KTOP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using KTOP.Helper;

namespace KTOP.Base.Tests
{
    public class BaseTests
    {
        [Fact]
        public void EPubTypeDetectionTest()
        {
            var erros = new Dictionary<string, List<string>>();
            var engine = new BookEngine(new ConsoleLogger());
            engine.Config = new BookEngineConfig();
            var book = engine.ProcessBook(FileHelper.FixPathSeperator("./SampleFiles/EPub.epub"));

            Assert.NotNull(book);
            Assert.IsType<EPubReader>(book);
        }

        [Fact]
        public void EpubFindFilesTest()
        {
            var erros = new Dictionary<string, List<string>>();
            var engine = new BookEngine(new ConsoleLogger());
            engine.Config = new BookEngineConfig();
            var book = engine.ProcessBook(FileHelper.FixPathSeperator("./SampleFiles/EPub.epub"));

            Assert.Equal(10, book.Files.Count);
        }

        [Fact]
        public void EpubSaveAsTest()
        {
            var erros = new Dictionary<string, List<string>>();
            var engine = new BookEngine(new ConsoleLogger());
            engine.Config = new BookEngineConfig();
            var book = engine.ProcessBook(FileHelper.FixPathSeperator("./SampleFiles/EPub.epub"));

            var path = book.SaveAs();

            Assert.Equal(true, File.Exists(path));

            var book2 = new EPubReader();
            book2.LoadFile(path);

            Assert.Equal(book.Files.Count, book2.Files.Count);
        }
    }
}
