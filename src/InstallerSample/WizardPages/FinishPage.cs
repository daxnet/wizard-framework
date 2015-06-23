using InstallerSample.Properties;
using System.Threading.Tasks;
using WizardFramework;

namespace InstallerSample.WizardPages
{
    public partial class FinishPage : WizardPage
    {
        #region Public Constructors

        public FinishPage(Wizard wizard)
            : base(Resources.FinishPageTitle, Resources.FinishPageDescription, wizard, WizardPageType.Expanded)
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            CanGoPreviousPage = false;
            CanGoCancel = false;
            this.lblTitle.Text = Title;
            this.lblDescription.Text = Description;
            return base.ExecuteShowAsync(fromPage);
        }

        #endregion Protected Methods
    }
}