namespace InstallerSample.WizardPages
{
    partial class LicensePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicensePage));
            this.rbAccept = new System.Windows.Forms.RadioButton();
            this.rbNotAgree = new System.Windows.Forms.RadioButton();
            this.txtLicense = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rbAccept
            // 
            resources.ApplyResources(this.rbAccept, "rbAccept");
            this.rbAccept.Name = "rbAccept";
            this.rbAccept.TabStop = true;
            this.rbAccept.UseVisualStyleBackColor = true;
            this.rbAccept.Click += new System.EventHandler(this.RadioButtonClicked);
            // 
            // rbNotAgree
            // 
            resources.ApplyResources(this.rbNotAgree, "rbNotAgree");
            this.rbNotAgree.Name = "rbNotAgree";
            this.rbNotAgree.TabStop = true;
            this.rbNotAgree.UseVisualStyleBackColor = true;
            this.rbNotAgree.Click += new System.EventHandler(this.RadioButtonClicked);
            // 
            // txtLicense
            // 
            resources.ApplyResources(this.txtLicense, "txtLicense");
            this.txtLicense.BackColor = System.Drawing.SystemColors.Window;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            // 
            // LicensePage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.rbNotAgree);
            this.Controls.Add(this.rbAccept);
            this.Name = "LicensePage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAccept;
        private System.Windows.Forms.RadioButton rbNotAgree;
        private System.Windows.Forms.RichTextBox txtLicense;
    }
}
