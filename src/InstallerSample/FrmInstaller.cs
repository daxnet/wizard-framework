using WizardFramework;

namespace InstallerSample
{
    public partial class FrmInstaller : Wizard
    {
        public FrmInstaller(WizardModel model)
            : base(model)
        {
            InitializeComponent();
        }

        public FrmInstaller()
            : this(new InstallerModel())
        {
        }
    }

    public sealed class InstallerModel : WizardModel
    {
    }
}