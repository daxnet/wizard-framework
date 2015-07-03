using InstallerSample.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WizardFramework;

namespace InstallerSample.WizardPages
{
    public partial class InstallingPage : WizardPage
    {
        #region Public Constructors

        public InstallingPage(Wizard wizard)
            : base(Resources.InstallingPageTitle, Resources.InstallingPageDescription, wizard, null)
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Protected Properties

        protected override Image Logo
        {
            get
            {
                return Resources.installer_logo;
            }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override async Task ExecuteShowAsync(IWizardPage fromPage)
        {
            CanGoPreviousPage = false;
            CanGoNextPage = false;
            CanGoFinishPage = false;
            CanGoCancel = false;
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var directoryInfo = new DirectoryInfo(folderPath);
            var files = directoryInfo.GetFiles();
            progressBar.Minimum = 1;
            progressBar.Maximum = files.Length;

            var progressIndicator = new Progress<int>(i =>
            {
                progressBar.Value = i;
                lblFileName.Text = files[i - 1].Name;
                lblFileName.Refresh();
            });

            await UpdateFileProgressAsync(files, progressIndicator);

            await NextAsync();
        }

        #endregion Protected Methods

        #region Private Methods

        private async Task<int> UpdateFileProgressAsync(FileInfo[] files, IProgress<int> progress)
        {
            int totalCount = files.Length;
            int processCount = await Task.Run<int>(() =>
            {
                int tempCount = 0;
                foreach (var file in files)
                {
                    tempCount++;
                    if (progress != null)
                    {
                        progress.Report(tempCount);
                    }
                }

                return tempCount;
            });
            return processCount;
        }

        #endregion Private Methods
    }
}