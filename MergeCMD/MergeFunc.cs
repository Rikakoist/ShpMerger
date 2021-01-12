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
        public MergeFunc(string rootDir, string fileName)
        {
            if (!Directory.Exists(rootDir))
                throw new DirectoryNotFoundException("Directory doesn't exist.");

           OutPutDir= this.rootDir = RootDir = rootDir;
            FileName = fileName;
            GP.ProgressChanged += GPProgressChanged;
            GP.ToolExecuted += GPExecuted;
        }

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
        /// Geoprocessor.
        /// </summary>
        Geoprocessor GP = new Geoprocessor()
        {
            OverwriteOutput = true
        };

        public delegate void ProgressChangedEventHander(object sender, ProgressChangedEventArgs e);
        public event ProgressChangedEventHander ProgressChanged;

        public delegate void ExecutedEventHander(object sender, ToolExecutedEventArgs e);
        public event ExecutedEventHander Executed;

        private void GPProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(sender, e);
        }

        private void GPExecuted(object sender, ToolExecutedEventArgs e)
        {
            Executed?.Invoke(sender, e);
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
            Mg.output = Path.Combine(OutPutDir,string.Concat(DT(),"_merge_",FileName)); 
            
            try
            {
                //Create a CancelTracker.
                ITrackCancel pTrackCancel = new CancelTrackerClass();

                //Create the ProgressDialog. This automatically displays the dialog
                IProgressDialogFactory pProgDlgFactory = new ProgressDialogFactoryClass();
                IProgressDialog2 pProDlg = pProgDlgFactory.Create(pTrackCancel, 0) as IProgressDialog2;
                pProDlg.CancelEnabled = true;
                pProDlg.Title = "Merging...";
                pProDlg.Description = "Please wait patiently...";

                pProDlg.Animation = esriProgressAnimationTypes.esriProgressSpiral;

                IStepProgressor pStepPro = pProDlg as IStepProgressor;
                pStepPro.MinRange = 0;
                pStepPro.MaxRange = 100;
                pStepPro.StepValue = 1;
                pStepPro.Message = "Initiating...";


                GP.Execute(Mg,pTrackCancel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Executed?.Invoke(null, null);
            }
        }

        private static string DT()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
