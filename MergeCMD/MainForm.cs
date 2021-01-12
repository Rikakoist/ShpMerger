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
        MgSettings MS = new MgSettings();

        private void FormLoad(object sender, EventArgs e)
        {
            RootDirTextBox.Text = MS.RootDir;
            FileNameTextBox.Text = MS.Filename;
            //RootDirTextBox.DataBindings.Add(nameof(TextBox.Text), MS, nameof(MS.RootDir));
            //FileNameTextBox.DataBindings.Add(nameof(TextBox.Text), MS, nameof(MS.Filename));
        }

        private void SelectFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog()
            {
                Description = "Select root path..."
            };
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                MS.RootDir = RootDirTextBox.Text = FBD.SelectedPath;
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
                MS.Filename =FileNameTextBox.Text =new FileInfo(OFD.FileName).Name;
            }
            OFD.Dispose();
        }

        private void ExecMerge(object sender, EventArgs e)
        {
            RootDir = RootDirTextBox.Text;
            Filename = FileNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(RootDir) || (!Directory.Exists(RootDir)))
            {
                MessageBox.Show("Invalid folder path.");
                return;
            }
            if (string.IsNullOrWhiteSpace(Filename) || (Filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0))
            {
                MessageBox.Show("Invalid filename.");
                return;
            }
            MS.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
