using InstallerSample.WizardPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallerSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var culture = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentUICulture = culture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var installer = new FrmInstaller();
            installer.Add(installer.CreatePage<WelcomePage>());
            installer.Add(installer.CreatePage<LicensePage>());
            installer.Add(installer.CreatePage<FeaturePage>());
            installer.Add(installer.CreatePage<SummaryPage>());
            installer.Add(installer.CreatePage<InstallingPage>());
            installer.Add(installer.CreatePage<FinishPage>());
            Application.Run(installer);
        }
    }
}
