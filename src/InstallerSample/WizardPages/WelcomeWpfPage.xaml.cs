namespace InstallerSample.WizardPages
{
    using System.Windows.Controls;

    using WizardFramework;
    using WizardFramework.WPF;

    /// <summary>
    /// Interaction logic for WelcomWpfPage.xaml
    /// </summary>
    public partial class WelcomeWpfPage : UserControl
    {
        public WelcomeWpfPage()
        {
            InitializeComponent();
        }
    }

    public class WelcomePageModel : WpfWizardPageModel
    {
        public WelcomePageModel() :
            base(
            "Welcome to the software Installer Wizard",
            "Welcome to the software installer wizard. This wizard will guide you through the steps of installing the software to your computer. Please click Next button to get started.",
            WizardPageType.Expanded)
        {
        }
    }
}
