using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTOP.Helper.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    namespace KTOP.Helper.Tests
    {
        public class FileHelperTest
        {
            [Fact]
            public void CreateTempDirTest()
            {
                var myName = "a-temp-dir";
                var createdDirectory = FileHelper.CreateTempDir(myName);

                Assert.Equal(true, Directory.Exists(createdDirectory));

                // Try to create a directory which already exists, should not throw an error
                createdDirectory = FileHelper.CreateTempDir(myName);
            }

            [Fact]
            public void FileNameWithTimeStampTest()
            {
                var name = FileHelper.FileNameWithTimeStamp("./SampleFiles/Epub.ppub");

                Assert.NotEqual(null, new FileInfo(name));
            }

            [Fact]
            public void LogFileNameTest()
            {
                var name = FileHelper.LogFileName("./SampleFiles/Epub.epub", "-log.txt");

                Assert.Equal(Path.GetFullPath("./SampleFiles/Epub-log.txt"), Path.GetFullPath(name));
            }

            [Fact]
            public void FixDirectorySeperatorTest()
            {
                var windowsBackSlashPath = "d:\\ebooks\\";
                Assert.Equal(FileHelper.FixPathSeperator(windowsBackSlashPath) , windowsBackSlashPath);

                var slashPath = "/ebooks/";
                Assert.Equal(FileHelper.FixPathSeperator(slashPath), "\\ebooks\\");
            }
        }
    }

}
