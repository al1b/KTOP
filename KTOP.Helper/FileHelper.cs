using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Craete a folder in temp dir
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CreateTempDir(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = Guid.NewGuid().ToString();
            
            var dir = Directory.CreateDirectory(Path.GetTempPath() + name + "\\");

            return dir.FullName;            
        }

        /// <summary>
        /// Create a new file name with timestamp.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string FileNameWithTimeStamp(string filePath)
        {
            var file = new FileInfo(filePath);

            var nameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

            return $@"{file.DirectoryName}\{nameWithoutExt}-{DateTime.Now.ToFileTime()}{file.Extension}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="logSuffix"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string LogFileName(string filePath, string logSuffix) => Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + logSuffix);
    }
}
