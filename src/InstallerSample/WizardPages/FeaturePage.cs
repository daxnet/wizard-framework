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
    public partial class FeaturePage : WizardPage
    {
        public FeaturePage(Wizard wizard)
            : base(Resources.FeaturePageTitle, Resources.FeaturePageDescription, wizard, new Model())
        {
            InitializeComponent();
        }

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

        protected override Image Logo
        {
            get
            {
                return Resources.installer_logo;
            }
        }

        public sealed new class Model : IWizardModel
        {
            public string SelectedFeature { get; set; }
            public string SelectedFolder { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format(Resources.SelectedFeaturePattern, SelectedFeature));
                sb.AppendLine(string.Format(Resources.InstallationFolderPattern, SelectedFolder));
                return sb.ToString();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtInstPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtInstPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
