using InstallerSample.Properties;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WizardFramework;

namespace InstallerSample.WizardPages
{
    public partial class FeaturePage : WizardPage
    {
        #region Public Constructors

        public FeaturePage(Wizard wizard, IWizardPageModel pageModel)
            : base(Resources.FeaturePageTitle, Resources.FeaturePageDescription, wizard, pageModel)
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
            if (fromPage is LicensePage)
            {
                rbStandard.Checked = true;
                txtInstPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }
            return base.ExecuteShowAsync(fromPage);
        }

        protected override void PersistValuesToModel()
        {
            var selectedFeature = string.Empty;
            if (rbMinimal.Checked)
                selectedFeature = rbMinimal.Text;
            else if (rbStandard.Checked)
                selectedFeature = rbStandard.Text;
            else if (rbFull.Checked)
                selectedFeature = rbFull.Text;

            ModelAs<Model>().SelectedFeature = selectedFeature;
            ModelAs<Model>().SelectedFolder = txtInstPath.Text;
        }

        #endregion Protected Methods

        #region Private Methods

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtInstPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtInstPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        #endregion Private Methods

        #region Public Classes

        public sealed new class Model : WizardPageModel
        {
            #region Public Properties

            public string SelectedFeature { get; set; }

            public string SelectedFolder { get; set; }

            #endregion Public Properties

            #region Public Methods

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format(Resources.SelectedFeaturePattern, SelectedFeature));
                sb.AppendLine(string.Format(Resources.InstallationFolderPattern, SelectedFolder));
                return sb.ToString();
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}