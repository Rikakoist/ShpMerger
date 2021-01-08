using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.DataManagementTools;
using System.IO;

namespace ShpMerger
{
    public class MergeFunc
    {
        /// <summary>
        /// Root directory.
        /// </summary>
        public string RootDir;
        /// <summary>
        /// Temp root directory.
        /// </summary>
        private string rootDir;
        /// <summary>
        /// Directory list.
        /// </summary>
        public List<string> DirList = new List<string>();
        /// <summary>
        /// Specified filename.
        /// </summary>
        public string FileName;
        /// <summary>
        /// List of filenames.
        /// </summary>
        public List<string> FileList = new List<string>();
        /// <summary>
        /// Output dataset.
        /// </summary>
        public string OutPutDir;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootDir">Root directory.</param>
        /// <param name="fileName">Specified filename.</param>
        public MergeFunc(string rootDir, string fileName)
        {
            if (!Directory.Exists(rootDir))
                throw new DirectoryNotFoundException("Directory doesn't exist.");

            this.rootDir = RootDir = rootDir;
            FileName = fileName;
        }

        /// <summary>
        /// Get directories recursively.
        /// </summary>
        public void GetAllChildDir()
        {
            if (!Directory.Exists(rootDir))
                throw new DirectoryNotFoundException("Directory doesn't exist.");

            DirectoryInfo directoryInfo = new DirectoryInfo(rootDir);
            foreach (DirectoryInfo d in directoryInfo.GetDirectories())
            {
                DirList.Add(d.FullName);
                rootDir = d.FullName;
                GetAllChildDir();
            }
        }

        /// <summary>
        /// Search specified filename in given directories.
        /// </summary>
        public void GetShpFileNameList()
        {
            if (DirList.Count <= 0)
                return;

            FileList.Clear();
            foreach (string S in DirList)
            {
                DirectoryInfo DI = new DirectoryInfo(S);
                //FileInfo FI = DI.GetFiles(filename);
                //if(FI!=null)
                foreach (FileInfo FI in DI.GetFiles())
                {
                    if (FI.Name == FileName)
                        FileList.Add(FI.FullName);
                }
            }
        }

        public void Merge()
        {
            Merge Mg = new Merge();
            Mg.inputs = string.Join(";", FileList);
            Mg.output = @"D:\Documents\ArcGIS\Default.gdb\test_Merge";
            
        }
    }
}
