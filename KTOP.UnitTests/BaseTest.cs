using KTOP.Base;
using KTOP.EBookReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KTOP.UnitTests
{
    public class EBookTests
    {
        [Fact]
        public void EPubTypeDetectionTest()
        {
            var erros = new Dictionary<string, List<string>>();
            var engine = new BookEngine(new ConsoleLogger());
            engine.Config = new BookEngineConfig();
            var book = engine.ProcessBook("./SampleFiles/EPub.epub", out erros);
            
            Assert.NotNull(book);
            Assert.IsType<EPubReader>(book);
        }

        [Fact]
        public void EpubFindFilesTest()
        {
            var erros = new Dictionary<string, List<string>>();
            var engine = new BookEngine(new ConsoleLogger());
            engine.Config = new BookEngineConfig();
            var book = engine.ProcessBook("./SampleFiles/EPub.epub", out erros);

            Assert.Equal(10, book.Files.Count);
        }

        [Fact]
        public void EpubSaveAsTest()
        {
            var erros = new Dictionary<string, List<string>>();
            var engine = new BookEngine(new ConsoleLogger());
            engine.Config = new BookEngineConfig();
            var book = engine.ProcessBook("./SampleFiles/EPub.epub", out erros);

            var path = book.SaveAs();

            Assert.Equal(true, File.Exists(path));

            var book2 = new EPubReader();
            book2.LoadFile(path);

            Assert.Equal(book.Files.Count, book2.Files.Count);
        }
    }
}
