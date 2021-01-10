using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ShpMerger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        MgSettings MS = new MgSettings();

        private void FormLoad(object sender, EventArgs e)
        {
            RootDirTextBox.DataBindings.Add(nameof(TextBox.Text),MS,nameof(MS.RootDir));
            FileNameTextBox.DataBindings.Add(nameof(TextBox.Text), MS, nameof(MS.Filename));
        }

        private void SelectFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog()
            {
                Description = "Select root path..."
            };
            if(FBD.ShowDialog()==DialogResult.OK)
            {
                MS.RootDir = FBD.SelectedPath;
            }
            FBD.Dispose();
        }

        private void SelectFile(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog()
            {
                AddExtension = true,
                AutoUpgradeEnabled = true,
                InitialDirectory = MS.RootDir,
                Multiselect = false,
                RestoreDirectory = true,
                ValidateNames = true
            };
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                MS.Filename = new FileInfo(OFD.FileName).Name;
            }
            OFD.Dispose();
        }

        private void ExecMerge(object sender, EventArgs e)
        {
            string rootDir = RootDirTextBox.Text;
            string fileName = FileNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(rootDir) || (!Directory.Exists(rootDir)))
            {
                MessageBox.Show("Invalid folder path.");
                return;
            }
            if (string.IsNullOrWhiteSpace(fileName) || (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0))
            {
                MessageBox.Show("Invalid filename.");
                return;
            }
            MS.Save();
            ExecBtn.Enabled = false;
            CancelBtn.Enabled = true;

            MergeFunc MF = new MergeFunc(rootDir, fileName);
            MF.ProgressChanged += MF_ProgressChanged;
            MF.Executed += MF_Executed;
            MF.GetAllChildDir();
            MF.GetShpFileNameList();
            MF.Merge();
        }

        private void MF_Executed(object sender, ESRI.ArcGIS.Geoprocessor.ToolExecutedEventArgs e)
        {
            ExecBtn.Enabled = true;
            CancelBtn.Enabled = false;
        }

        private void MF_ProgressChanged(object sender, ESRI.ArcGIS.Geoprocessor.ProgressChangedEventArgs e)
        {
            MgProgressBar.Value = (int)(e.ProgressPercentage * 100);
            Refresh();
        }
    }
}
