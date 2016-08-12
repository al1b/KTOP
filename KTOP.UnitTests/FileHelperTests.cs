using KTOP.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KTOP.UnitTests
{
    public class FileHelperTests
    {
        [Fact]
        public void CreateTempDirectoryTest()
        {
            var myName = "a-temp-dir";
            var createdDirectory = FileHelper.CreateTempDir(myName);

            Assert.Equal(true, Directory.Exists(createdDirectory));

            // Try to create a directory which already exists, should not throw an error
            createdDirectory = FileHelper.CreateTempDir(myName);
        }

        [Fact]
        public void NewFileNameWIthTimestampTest()
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
    }
}
