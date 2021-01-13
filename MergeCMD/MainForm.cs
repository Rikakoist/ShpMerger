using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MergeCMD.Properties;

namespace MergeCMD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string RootDir = string.Empty;
        public string Filename = string.Empty;
        public string OutDir = string.Empty;
        public bool AddOutputsToMap = false;
        public bool OverwriteOutput = false;
        MgSettings MS = new MgSettings();

        private void FormLoad(object sender, EventArgs e)
        { 
            RootDirTextBox.DataBindings.Add(nameof(TextBox.Text), MS, nameof(MS.RootDir));
            FileNameTextBox.DataBindings.Add(nameof(TextBox.Text), MS, nameof(MS.Filename));
            OutDirTextBox.DataBindings.Add(nameof(TextBox.Text), MS, nameof(MS.OutDir));
            OverwriteOptCheckBox.DataBindings.Add(nameof(CheckBox.Checked), MS, nameof(MS.OverwriteOutput));
            AddData2MapCheckBox.DataBindings.Add(nameof(CheckBox.Checked),MS,nameof(MS.AddToMapWhenFinished));
            SaveToRootDirCheckBox.DataBindings.Add(nameof(CheckBox.Checked), MS, nameof(MS.SaveToRootDir));
        }

        private void SelectFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (sender == RootDirBtn)
            {
                FBD.Description= "Select root path...";
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    MS.RootDir = FBD.SelectedPath;
                }
            }
            if (sender == OutDirBtn)
            {
                FBD.Description = "Select out path...";
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    MS.OutDir = FBD.SelectedPath;
                }
            }
            FBD.Dispose();
        }

        private void SelectFile(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog()
            {
                AddExtension = true,
                AutoUpgradeEnabled = true,
                Filter = "shp files (*.shp)|*.shp|All files (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = MS.RootDir,
                Multiselect = false,
                RestoreDirectory = true,
                ValidateNames = true
            };
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                MS.Filename =new FileInfo(OFD.FileName).Name;
            }
            OFD.Dispose();
        }

        private void SaveToRootChanged(object sender, EventArgs e)
        {
            OutDirBtn.Enabled = OutDirTextBox.Enabled = !SaveToRootDirCheckBox.Checked;
            OutDirBtn.Cursor = SaveToRootDirCheckBox.Checked ? Cursors.No : Cursors.Hand;
        }

        private void ExecMerge(object sender, EventArgs e)
        {
            RootDir = RootDirTextBox.Text;
            Filename = FileNameTextBox.Text;
            OutDir = SaveToRootDirCheckBox.Checked ? RootDir : OutDirTextBox.Text;
            AddOutputsToMap = AddData2MapCheckBox.Checked;
            OverwriteOutput = OverwriteOptCheckBox.Checked;
            if (Common.IsPathInValid(RootDir))
            {
                MessageBox.Show("Invalid root folder path.");
                return;
            }
            if (Common.IsFileInValid(Filename))
            {
                MessageBox.Show("Invalid filename.");
                return;
            }
            if (Common.IsPathInValid(OutDir))
            {
                MessageBox.Show("Invalid output folder path.");
                return;
            }
            MS.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
