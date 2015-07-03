using InstallerSample.Properties;
using System.Drawing;
using System.Threading.Tasks;
using WizardFramework;

namespace InstallerSample.WizardPages
{
    public partial class SummaryPage : WizardPage
    {
        #region Public Constructors

        public SummaryPage(Wizard wizard)
            : base(Resources.SummaryPageTitle, Resources.SummaryPageDescription, wizard, null)
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
            this.txtSummary.Text = Wizard.GetWizardModel<FeaturePage.Model>().ToString();
            return base.ExecuteShowAsync(fromPage);
        }

        #endregion Protected Methods
    }
}