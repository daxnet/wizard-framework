namespace WizardFramework.WPF
{
    partial class WpfWizardPage<TV>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eleHost = new System.Windows.Forms.Integration.ElementHost();
            this.wpfViewPanel = new System.Windows.Forms.Panel(); ;
            this.wpfViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // eleHost
            // 
            this.eleHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eleHost.Location = new System.Drawing.Point(0, 0);
            this.eleHost.Name = "eleHost";
            this.eleHost.Size = new System.Drawing.Size(617, 424);
            this.eleHost.TabIndex = 0;
            this.eleHost.Text = "Element Host";
            this.eleHost.Child = null;
            // 
            // wpfViewPanel
            // 
            this.wpfViewPanel.Controls.Add(this.eleHost);
            this.wpfViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpfViewPanel.Location = new System.Drawing.Point(0, 0);
            this.wpfViewPanel.Name = "wpfViewPanel";
            this.wpfViewPanel.Size = new System.Drawing.Size(617, 424);
            this.wpfViewPanel.TabIndex = 1;
            //
            // WpfWizrdPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wpfViewPanel);
            this.wpfViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            components = new System.ComponentModel.Container();
        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost eleHost;
        private System.Windows.Forms.Panel wpfViewPanel;
    }
}
