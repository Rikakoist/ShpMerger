using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.DataManagementTools;
using System.IO;
using ESRI.ArcGIS.Geoprocessor;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Display;
using System.Diagnostics;

namespace MergeCMD
{
    public class MergeFunc
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootDir">Root directory.</param>
        /// <param name="fileName">Specified filename.</param>
        public MergeFunc(string rootDir, string fileName, string outDir)
        {
            if (!Directory.Exists(rootDir))
                throw new DirectoryNotFoundException("Directory doesn't exist.");

            RootDir = rootDir;
            FileName = fileName;
            OutputDir = Directory.Exists(outDir) ? outDir : Environment.SpecialFolder.Personal.ToString();
        }

        /// <summary>
        /// Root directory.
        /// </summary>
        public string RootDir;
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
        public List<string> FileList;
        /// <summary>
        /// Output dataset.
        /// </summary>
        public string OutputDir;

        /// <summary>
        /// Merge tool.
        /// </summary>
        public Merge Mg = new Merge();

        public Merge GetMerge()
        {
            Common.GetAllChildDir(RootDir, ref DirList);
            FileList = Common.GetFileNameList(DirList, FileName);
            SetMergeParam();
            return Mg;
        }

        /// <summary>
        /// Set params of the tool.
        /// </summary>
        public void SetMergeParam()
        {
            Mg.inputs = string.Join(";", FileList);
            Mg.output = Path.Combine(OutputDir, string.Concat(Common.DT(), "_merge_", FileName));
        }
    }
}
