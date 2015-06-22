namespace InstallerSample.WizardPages
{
    partial class FeaturePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeaturePage));
            this.rbMinimal = new System.Windows.Forms.RadioButton();
            this.rbStandard = new System.Windows.Forms.RadioButton();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.grpInstallationFolder = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInstPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpInstallationFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMinimal
            // 
            resources.ApplyResources(this.rbMinimal, "rbMinimal");
            this.rbMinimal.Name = "rbMinimal";
            this.rbMinimal.TabStop = true;
            this.rbMinimal.UseVisualStyleBackColor = true;
            // 
            // rbStandard
            // 
            resources.ApplyResources(this.rbStandard, "rbStandard");
            this.rbStandard.Name = "rbStandard";
            this.rbStandard.TabStop = true;
            this.rbStandard.UseVisualStyleBackColor = true;
            // 
            // rbFull
            // 
            resources.ApplyResources(this.rbFull, "rbFull");
            this.rbFull.Name = "rbFull";
            this.rbFull.TabStop = true;
            this.rbFull.UseVisualStyleBackColor = true;
            // 
            // grpInstallationFolder
            // 
            resources.ApplyResources(this.grpInstallationFolder, "grpInstallationFolder");
            this.grpInstallationFolder.Controls.Add(this.btnBrowse);
            this.grpInstallationFolder.Controls.Add(this.txtInstPath);
            this.grpInstallationFolder.Name = "grpInstallationFolder";
            this.grpInstallationFolder.TabStop = false;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInstPath
            // 
            resources.ApplyResources(this.txtInstPath, "txtInstPath");
            this.txtInstPath.Name = "txtInstPath";
            this.txtInstPath.ReadOnly = true;
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // FeaturePage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpInstallationFolder);
            this.Controls.Add(this.rbFull);
            this.Controls.Add(this.rbStandard);
            this.Controls.Add(this.rbMinimal);
            this.Name = "FeaturePage";
            this.grpInstallationFolder.ResumeLayout(false);
            this.grpInstallationFolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMinimal;
        private System.Windows.Forms.RadioButton rbStandard;
        private System.Windows.Forms.RadioButton rbFull;
        private System.Windows.Forms.GroupBox grpInstallationFolder;
        private System.Windows.Forms.TextBox txtInstPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
