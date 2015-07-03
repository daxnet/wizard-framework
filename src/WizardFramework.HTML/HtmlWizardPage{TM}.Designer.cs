namespace WizardFramework.HTML
{
    partial class HtmlWizardPage<TM>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowNavigation = false;
            this.webView.AllowWebBrowserDrop = false;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.IsWebBrowserContextMenuEnabled = false;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.MinimumSize = new System.Drawing.Size(20, 20);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(150, 150);
            this.webView.TabIndex = 0;
            this.webView.WebBrowserShortcutsEnabled = false;
            // 
            // HtmlWizardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.webView);
            this.Name = "HtmlWizardPage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webView;
    }
}
