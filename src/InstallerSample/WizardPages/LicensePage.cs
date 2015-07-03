using InstallerSample.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WizardFramework;

namespace InstallerSample.WizardPages
{
    public partial class LicensePage : WizardPage
    {
        #region Public Constructors

        public LicensePage(Wizard wizard)
            : base(Resources.LicensePageTitle, Resources.LicensePageDescription, wizard, null)
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Protected Properties

        protected override Image Logo
        {
            get
            {
                return Resources.installer_logo;
            }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            var bytes = Encoding.ASCII.GetBytes(Resources.Apache20);
            using (var memoryStream = new MemoryStream(bytes))
            {
                this.txtLicense.LoadFile(memoryStream, RichTextBoxStreamType.RichText);
            }

            rbNotAgree.Checked = true;
            this.UpdateControlState();

            return base.ExecuteShowAsync(fromPage);
        }

        #endregion Protected Methods

        #region Private Methods

        private void RadioButtonClicked(object sender, EventArgs e)
        {
            this.UpdateControlState();
        }

        private void UpdateControlState()
        {
            this.CanGoNextPage = rbAccept.Checked;
        }

        #endregion Private Methods
    }
}