using InstallerSample.Properties;
using System.Threading.Tasks;
using WizardFramework;

namespace InstallerSample.WizardPages
{
    public partial class WelcomePage : WizardPage
    {
        #region Public Constructors

        public WelcomePage(Wizard wizard)
            : base(Resources.WelcomePageTitle, Resources.WelcomePageDescription, wizard, WizardPageType.Expanded)
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            this.lblTitle.Text = this.Title;
            this.lblDescription.Text = this.Description;
            return base.ExecuteShowAsync(fromPage);
        }

        #endregion Protected Methods
    }
}