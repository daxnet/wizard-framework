using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WizardFramework;
using InstallerSample.Properties;
using System.IO;

namespace InstallerSample.WizardPages
{
    public partial class LicensePage : WizardPage
    {
        public LicensePage(Wizard wizard)
            : base(Resources.LicensePageTitle, Resources.LicensePageDescription, wizard)
        {
            InitializeComponent();
        }

        private void UpdateControlState()
        {
            this.CanGoNextPage = rbAccept.Checked;
        }

        private void RadioButtonClicked(object sender, EventArgs e)
        {
            this.UpdateControlState();
        }

        protected override Image Logo
        {
            get
            {
                return Resources.installer_logo;
            }
        }

        protected override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            var bytes = Encoding.ASCII.GetBytes(Resources.Apache20);
            using (var memoryStream  = new MemoryStream(bytes))
            {
                this.txtLicense.LoadFile(memoryStream, RichTextBoxStreamType.RichText);
            }
            
            rbNotAgree.Checked = true;
            this.UpdateControlState();

            return base.ExecuteShowAsync(fromPage);
        }
    }
}
