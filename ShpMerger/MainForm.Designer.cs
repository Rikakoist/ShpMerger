namespace ShpMerger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.RootDirTextBox = new System.Windows.Forms.TextBox();
            this.RootDirBtn = new System.Windows.Forms.Button();
            this.RootDirLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileNameBtn = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.ExecBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(441, 194);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // RootDirTextBox
            // 
            this.RootDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirTextBox.Location = new System.Drawing.Point(89, 40);
            this.RootDirTextBox.Name = "RootDirTextBox";
            this.RootDirTextBox.Size = new System.Drawing.Size(271, 20);
            this.RootDirTextBox.TabIndex = 1;
            // 
            // RootDirBtn
            // 
            this.RootDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirBtn.Location = new System.Drawing.Point(366, 39);
            this.RootDirBtn.Name = "RootDirBtn";
            this.RootDirBtn.Size = new System.Drawing.Size(75, 23);
            this.RootDirBtn.TabIndex = 0;
            this.RootDirBtn.Text = "Browse...";
            this.RootDirBtn.UseVisualStyleBackColor = true;
            // 
            // RootDirLabel
            // 
            this.RootDirLabel.AutoSize = true;
            this.RootDirLabel.Location = new System.Drawing.Point(32, 44);
            this.RootDirLabel.Name = "RootDirLabel";
            this.RootDirLabel.Size = new System.Drawing.Size(47, 13);
            this.RootDirLabel.TabIndex = 4;
            this.RootDirLabel.Text = "Root dir:";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(32, 106);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(52, 13);
            this.FileNameLabel.TabIndex = 5;
            this.FileNameLabel.Text = "Filename:";
            // 
            // FileNameBtn
            // 
            this.FileNameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameBtn.Location = new System.Drawing.Point(366, 101);
            this.FileNameBtn.Name = "FileNameBtn";
            this.FileNameBtn.Size = new System.Drawing.Size(75, 23);
            this.FileNameBtn.TabIndex = 2;
            this.FileNameBtn.Text = "Browse...";
            this.FileNameBtn.UseVisualStyleBackColor = true;
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(89, 102);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(271, 20);
            this.FileNameTextBox.TabIndex = 4;
            // 
            // ExecBtn
            // 
            this.ExecBtn.Location = new System.Drawing.Point(89, 155);
            this.ExecBtn.Name = "ExecBtn";
            this.ExecBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecBtn.TabIndex = 6;
            this.ExecBtn.Text = "Execute";
            this.ExecBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(285, 155);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 226);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ExecBtn);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.FileNameBtn);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.RootDirLabel);
            this.Controls.Add(this.RootDirBtn);
            this.Controls.Add(this.RootDirTextBox);
            this.Controls.Add(this.axLicenseControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = ".shp file merging applet";
            this.Load += new System.EventHandler(this.FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.TextBox RootDirTextBox;
        private System.Windows.Forms.Button RootDirBtn;
        private System.Windows.Forms.Label RootDirLabel;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Button FileNameBtn;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Button ExecBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}

