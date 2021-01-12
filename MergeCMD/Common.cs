using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeCMD
{
    public class Common
    {
        /// <summary>
        /// Get child directories recursively.
        /// </summary>
        /// <param name="rootDir">Root directory where the search begins.</param>
        /// <param name="dirList">The directory list.</param>
        public static void GetAllChildDir(string rootDir, ref List<string> dirList)
        {
            if (!Directory.Exists(rootDir))
                throw new DirectoryNotFoundException("Directory doesn't exist.");

            DirectoryInfo directoryInfo = new DirectoryInfo(rootDir);
            foreach (DirectoryInfo d in directoryInfo.GetDirectories())
            {
                dirList.Add(d.FullName);
                rootDir = d.FullName;
                GetAllChildDir(rootDir, ref dirList);
            }
        }

        /// <summary>
        /// Search specified filename in given directories.
        /// </summary>
        /// <param name="dirList">The directory list that search in.</param>
        /// <param name="filename">Specified filename with extension.</param>
        /// <returns></returns>
        public static List<string> GetFileNameList(List<string> dirList, string filename)
        {
            if (dirList.Count <= 0)
                throw new Exception("Empty directory list.");

            var fileList = new List<string>();
            foreach (string s in dirList)
            {
                DirectoryInfo dI = new DirectoryInfo(s);
                //FileInfo FI = DI.GetFiles(filename);
                //if(FI!=null)
                foreach (FileInfo fI in dI.GetFiles())
                {
                    if (fI.Name == filename)
                        fileList.Add(fI.FullName);
                }
            }
            return fileList;
        }

        /// <summary>
        /// Check if the given path is invalid.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Path invalid.</returns>
        public static bool IsPathInValid(string path)
        {
            return (string.IsNullOrWhiteSpace(path)) || (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0);
        }

        /// <summary>
        /// Check if the given filename is invalid.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>Filename invalid.</returns>
        public static bool IsFileInValid(string filename)
        {
            return (string.IsNullOrWhiteSpace(filename)) || (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0);
        }

        /// <summary>
        /// Get time.
        /// </summary>
        /// <returns>Time in "yyyyMMddHHmmss" format.</returns>
        public static string DT()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
