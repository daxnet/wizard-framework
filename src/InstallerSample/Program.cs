using InstallerSample.WizardPages;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace InstallerSample
{
    internal static class Program
    {
        #region Private Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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

        #endregion Private Methods
    }
}