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
    public partial class WelcomePage : WizardPage
    {
        public WelcomePage(Wizard wizard)
            : base(Resources.WelcomePageTitle, Resources.WelcomePageDescription, wizard, WizardPageType.Expanded)
        {
            InitializeComponent();
        }

        protected override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            this.lblTitle.Text = this.Title;
            this.lblDescription.Text = this.Description;
            return base.ExecuteShowAsync(fromPage);
        }
    }
}
