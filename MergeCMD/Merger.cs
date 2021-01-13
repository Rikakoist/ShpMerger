using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Framework;
using System.Windows.Forms;
using MergeCMD.Properties;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geoprocessor;
using System.Threading;
using System.Diagnostics;

namespace MergeCMD
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("0ef1163f-f51d-493a-a48a-89d2c336872d")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MergeCMD.Merge")]
    public sealed class Merger : BaseCommand
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper = null;
        IApplication m_application;
        IProgressDialog2 pProDlg;
        IStepProgressor pStepPro;
        Stopwatch SW = new Stopwatch();
        System.Windows.Forms.Timer TM = new System.Windows.Forms.Timer();


        public Merger()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "GraduationProj"; //localizable text
            base.m_caption = "Shapefile merge (batch)";  //localizable text 
            base.m_message = "Merge .shp file in selected directory (recursively).";  //localizable text
            base.m_toolTip = "Batch Shapefile merge tool v1.1(20210113)";  //localizable text
            base.m_name = "ShpMerge";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_application = hook as IApplication;
                m_hookHelper = new HookHelperClass
                {
                    Hook = hook
                };
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            MgSettings MS = new MgSettings();
            if (!Directory.Exists(MS.RootDir))
            {
                MS.RootDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            if(!Directory.Exists(MS.OutDir))
            {
                MS.OutDir = MS.RootDir;
            }
            MS.Save();

            MainForm M = new MainForm();
            if (M.ShowDialog() == DialogResult.OK)
            {
                MergeFunc MF = new MergeFunc(M.RootDir, M.Filename,M.OutDir);
                TM = new System.Windows.Forms.Timer();
                SW.Reset();

                Geoprocessor GP = new Geoprocessor()
                {
                    AddOutputsToMap = M.AddOutputsToMap,
                    OverwriteOutput = M.OverwriteOutput               
                };

                GP.ToolExecuting += GP_ToolExecuting;
                GP.ToolExecuted += GP_ToolExecuted;
                TM.Tick += TM_Tick;

                ITrackCancel pTrackCancel = new CancelTrackerClass();
                IProgressDialogFactory pProgDlgFactory = new ProgressDialogFactoryClass();
                pProDlg = pProgDlgFactory.Create(pTrackCancel, m_application.hWnd) as IProgressDialog2;
                pProDlg.CancelEnabled = true;
                pProDlg.Title = "Merge in progress...";
                pProDlg.Description = "Please wait patiently...";
                pProDlg.Animation = esriProgressAnimationTypes.esriProgressSpiral;

                pStepPro = pProDlg as IStepProgressor;
                pStepPro.MinRange = 0;
                pStepPro.MaxRange = 100;
                pStepPro.StepValue = 1;
                pStepPro.Message = "Initiating...";

                GP.Execute(MF.GetMerge(), pTrackCancel);
            }
            M.Dispose();          
        }

        private void TM_Tick(object sender, EventArgs e)
        {
            pStepPro.Message = string.Format("Merging...({0})", SW.Elapsed.ToString("hh\\:mm\\:ss"));
        }

        private void GP_ToolExecuting(object sender, ToolExecutingEventArgs e)
        {
            pStepPro.Message = "Getting things ready...";
            TM.Start();
            SW.Start();
        }

        private void GP_ToolExecuted(object sender, ToolExecutedEventArgs e)
        {
            TM.Stop();
            SW.Stop();
            pStepPro.Message = string.Format("Finished...({0}), may not respond for a while.", SW.Elapsed.ToString("hh\\:mm\\:ss"));
            TM.Dispose();
            Thread.Sleep(1000);
            pProDlg.HideDialog();
        }

        #endregion
    }
}
