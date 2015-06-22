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

namespace InstallerSample.WizardPages
{
    public partial class SummaryPage : WizardPage
    {
        public SummaryPage(Wizard wizard)
            : base(Resources.SummaryPageTitle, Resources.SummaryPageDescription, wizard)
        {
            InitializeComponent();
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
            this.txtSummary.Text = Wizard.GetWizardModel<FeaturePage.Model>().ToString();
            return base.ExecuteShowAsync(fromPage);
        }
    }
}
