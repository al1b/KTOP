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
        /// Fix path seperator character in paths
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FixPathSeperator(string path)
        {
            return path.Replace('\\', Path.DirectorySeparatorChar)
                       .Replace('/', Path.DirectorySeparatorChar);

        }

        /// <summary>
        /// Craete a folder in temp dir
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CreateTempDir(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = Guid.NewGuid().ToString();

            var dir = Directory.CreateDirectory(Path.GetTempPath() + name + Path.DirectorySeparatorChar);

            return dir.FullName;
        }

        /// <summary>
        /// Create a new file name with timestamp.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string FileNameWithTimeStamp(string filePath)
        {
            filePath = FixPathSeperator(filePath);

            var file = new FileInfo(filePath);
            var nameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

            var pathBuilder = new StringBuilder();
            pathBuilder.Append(file.DirectoryName);

            if (file.DirectoryName[file.DirectoryName.Length - 1] != Path.DirectorySeparatorChar)
                pathBuilder.Append(Path.DirectorySeparatorChar);

            pathBuilder.Append(nameWithoutExt);
            pathBuilder.Append("--");
            pathBuilder.Append(DateTime.Now.ToFileTime());
            pathBuilder.Append(file.Extension);

            return pathBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="logSuffix"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string LogFileName(string filePath, string logSuffix)
        {
            filePath = FixPathSeperator(filePath);
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + logSuffix);
        }
    }
}
