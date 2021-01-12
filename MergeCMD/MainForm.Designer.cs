namespace MergeCMD
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
            this.RootDirTextBox = new System.Windows.Forms.TextBox();
            this.RootDirBtn = new System.Windows.Forms.Button();
            this.RootDirLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileNameBtn = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.ExecBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OverwriteOptCheckBox = new System.Windows.Forms.CheckBox();
            this.AddData2MapCheckBox = new System.Windows.Forms.CheckBox();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.OutDirBtn = new System.Windows.Forms.Button();
            this.OutDirTextBox = new System.Windows.Forms.TextBox();
            this.OutDirLabel = new System.Windows.Forms.Label();
            this.SaveToRootDirCheckBox = new System.Windows.Forms.CheckBox();
            this.GeneralGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootDirTextBox
            // 
            this.RootDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirTextBox.Location = new System.Drawing.Point(63, 21);
            this.RootDirTextBox.Name = "RootDirTextBox";
            this.RootDirTextBox.Size = new System.Drawing.Size(295, 20);
            this.RootDirTextBox.TabIndex = 1;
            // 
            // RootDirBtn
            // 
            this.RootDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirBtn.Location = new System.Drawing.Point(370, 19);
            this.RootDirBtn.Name = "RootDirBtn";
            this.RootDirBtn.Size = new System.Drawing.Size(75, 23);
            this.RootDirBtn.TabIndex = 0;
            this.RootDirBtn.Text = "Browse...";
            this.RootDirBtn.UseVisualStyleBackColor = true;
            this.RootDirBtn.Click += new System.EventHandler(this.SelectFolder);
            // 
            // RootDirLabel
            // 
            this.RootDirLabel.AutoSize = true;
            this.RootDirLabel.Location = new System.Drawing.Point(6, 25);
            this.RootDirLabel.Name = "RootDirLabel";
            this.RootDirLabel.Size = new System.Drawing.Size(47, 13);
            this.RootDirLabel.TabIndex = 0;
            this.RootDirLabel.Text = "Root dir:";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(6, 64);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(52, 13);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "Filename:";
            // 
            // FileNameBtn
            // 
            this.FileNameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameBtn.Location = new System.Drawing.Point(370, 58);
            this.FileNameBtn.Name = "FileNameBtn";
            this.FileNameBtn.Size = new System.Drawing.Size(75, 23);
            this.FileNameBtn.TabIndex = 2;
            this.FileNameBtn.Text = "Browse...";
            this.FileNameBtn.UseVisualStyleBackColor = true;
            this.FileNameBtn.Click += new System.EventHandler(this.SelectFile);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(63, 60);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(295, 20);
            this.FileNameTextBox.TabIndex = 3;
            // 
            // ExecBtn
            // 
            this.ExecBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExecBtn.Location = new System.Drawing.Point(89, 264);
            this.ExecBtn.Name = "ExecBtn";
            this.ExecBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecBtn.TabIndex = 4;
            this.ExecBtn.Text = "Execute";
            this.ExecBtn.UseVisualStyleBackColor = true;
            this.ExecBtn.Click += new System.EventHandler(this.ExecMerge);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(295, 264);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelMerge);
            // 
            // OverwriteOptCheckBox
            // 
            this.OverwriteOptCheckBox.AutoSize = true;
            this.OverwriteOptCheckBox.Location = new System.Drawing.Point(89, 187);
            this.OverwriteOptCheckBox.Name = "OverwriteOptCheckBox";
            this.OverwriteOptCheckBox.Size = new System.Drawing.Size(104, 17);
            this.OverwriteOptCheckBox.TabIndex = 2;
            this.OverwriteOptCheckBox.Text = "Overwrite output";
            this.OverwriteOptCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddData2MapCheckBox
            // 
            this.AddData2MapCheckBox.AutoSize = true;
            this.AddData2MapCheckBox.Location = new System.Drawing.Point(89, 213);
            this.AddData2MapCheckBox.Name = "AddData2MapCheckBox";
            this.AddData2MapCheckBox.Size = new System.Drawing.Size(172, 17);
            this.AddData2MapCheckBox.TabIndex = 3;
            this.AddData2MapCheckBox.Text = "Add data to map when finished";
            this.AddData2MapCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.Controls.Add(this.OutDirBtn);
            this.GeneralGroupBox.Controls.Add(this.OutDirTextBox);
            this.GeneralGroupBox.Controls.Add(this.OutDirLabel);
            this.GeneralGroupBox.Controls.Add(this.FileNameBtn);
            this.GeneralGroupBox.Controls.Add(this.RootDirTextBox);
            this.GeneralGroupBox.Controls.Add(this.RootDirBtn);
            this.GeneralGroupBox.Controls.Add(this.RootDirLabel);
            this.GeneralGroupBox.Controls.Add(this.FileNameTextBox);
            this.GeneralGroupBox.Controls.Add(this.FileNameLabel);
            this.GeneralGroupBox.Location = new System.Drawing.Point(12, 12);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(451, 134);
            this.GeneralGroupBox.TabIndex = 0;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "General";
            // 
            // OutDirBtn
            // 
            this.OutDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutDirBtn.Location = new System.Drawing.Point(370, 99);
            this.OutDirBtn.Name = "OutDirBtn";
            this.OutDirBtn.Size = new System.Drawing.Size(75, 23);
            this.OutDirBtn.TabIndex = 5;
            this.OutDirBtn.Text = "Browse...";
            this.OutDirBtn.UseVisualStyleBackColor = true;
            // 
            // OutDirTextBox
            // 
            this.OutDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutDirTextBox.Location = new System.Drawing.Point(63, 101);
            this.OutDirTextBox.Name = "OutDirTextBox";
            this.OutDirTextBox.Size = new System.Drawing.Size(295, 20);
            this.OutDirTextBox.TabIndex = 6;
            // 
            // OutDirLabel
            // 
            this.OutDirLabel.AutoSize = true;
            this.OutDirLabel.Location = new System.Drawing.Point(6, 105);
            this.OutDirLabel.Name = "OutDirLabel";
            this.OutDirLabel.Size = new System.Drawing.Size(42, 13);
            this.OutDirLabel.TabIndex = 0;
            this.OutDirLabel.Text = "Output:";
            // 
            // SaveToRootDirCheckBox
            // 
            this.SaveToRootDirCheckBox.AutoSize = true;
            this.SaveToRootDirCheckBox.Location = new System.Drawing.Point(89, 161);
            this.SaveToRootDirCheckBox.Name = "SaveToRootDirCheckBox";
            this.SaveToRootDirCheckBox.Size = new System.Drawing.Size(158, 17);
            this.SaveToRootDirCheckBox.TabIndex = 1;
            this.SaveToRootDirCheckBox.Text = "Save merge result to root dir";
            this.SaveToRootDirCheckBox.UseVisualStyleBackColor = true;
            this.SaveToRootDirCheckBox.CheckedChanged += new System.EventHandler(this.SaveToRootChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 308);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.AddData2MapCheckBox);
            this.Controls.Add(this.SaveToRootDirCheckBox);
            this.Controls.Add(this.OverwriteOptCheckBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ExecBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".shp file merging applet";
            this.Load += new System.EventHandler(this.FormLoad);
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RootDirTextBox;
        private System.Windows.Forms.Button RootDirBtn;
        private System.Windows.Forms.Label RootDirLabel;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Button FileNameBtn;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Button ExecBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox OverwriteOptCheckBox;
        private System.Windows.Forms.CheckBox AddData2MapCheckBox;
        private System.Windows.Forms.GroupBox GeneralGroupBox;
        private System.Windows.Forms.Button OutDirBtn;
        private System.Windows.Forms.TextBox OutDirTextBox;
        private System.Windows.Forms.Label OutDirLabel;
        private System.Windows.Forms.CheckBox SaveToRootDirCheckBox;
    }
}