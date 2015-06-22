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
    public partial class FinishPage : WizardPage
    {
        public FinishPage(Wizard wizard)
            : base(Resources.FinishPageTitle, Resources.FinishPageDescription, wizard, WizardPageType.Expanded)
        {
            InitializeComponent();
        }

        protected override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            CanGoPreviousPage = false;
            CanGoCancel = false;
            this.lblTitle.Text = Title;
            this.lblDescription.Text = Description;
            return base.ExecuteShowAsync(fromPage);
        }
    }
}
