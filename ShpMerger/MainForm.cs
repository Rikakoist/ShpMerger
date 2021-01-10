using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShpMerger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            string RD = @"D:\Desktop\teatdt";
            string FN = @"aanp.shp";
            MergeFunc MF = new MergeFunc(RD,FN);
            MF.GetAllChildDir();
            MF.GetShpFileNameList();
            MF.Merge();
        }
    }
}
