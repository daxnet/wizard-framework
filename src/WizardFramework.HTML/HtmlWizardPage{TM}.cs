namespace WizardFramework.HTML
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.AccessControl;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Microsoft.Win32;

    using Newtonsoft.Json;

    using WizardFramework;
    using WizardFramework.HTML.Properties;

    /// <summary>
    /// The HTML wizard page.
    /// </summary>
    public partial class HtmlWizardPage<TM> : WizardPageBase 
        where TM : HtmlWizardPageModel
    {
        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="HtmlWizardPage"/> class. </summary>
        /// <param name="wizard">
        /// The <see cref="Wizard" /> instance which contains the current wizard page.
        /// </param>
        /// <param name="pageModel"> The data/view model of the current wizard page. </param>
        public HtmlWizardPage(Wizard wizard, IWizardPageModel pageModel)
            : this(
                pageModel == null ? "" : ((HtmlWizardPageModel)pageModel).Title,
                pageModel == null ? "" : ((HtmlWizardPageModel)pageModel).Description,
                wizard,
                pageModel,
                pageModel == null ? WizardPageType.Expanded : ((HtmlWizardPageModel)pageModel).PageType)
        {
        }

        #endregion

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlWizardPage"/> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page. </param>
        /// <param name="description"> The description of the current wizard page. </param>
        /// <param name="wizard">
        /// The <see cref="Wizard" /> instance which contains the current wizard page.
        /// </param>
        /// <param name="pageModel"> The data/view model of the current wizard page. </param>
        protected HtmlWizardPage(string title, string description, Wizard wizard, IWizardPageModel pageModel)
            : base(title, description, wizard, pageModel, WizardPageType.Standard)
        {
            InitializeWebView(pageModel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlWizardPage"/> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page.  </param>
        /// <param name="description"> The description of the current wizard page.  </param>
        /// <param name="wizard"> The <see cref="Wizard"/> instance which contains the current wizard page. </param>
        /// <param name="type"> The type of the current wizard page.  </param>
        protected HtmlWizardPage(string title, string description, Wizard wizard, WizardPageType type)
            : base(title, description, wizard, null, type)
        {
            InitializeWebView(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlWizardPage"/> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page.  </param>
        /// <param name="description"> The description of the current wizard page.  </param>
        /// <param name="wizard"> The <see cref="Wizard"/> instance which contains the current wizard page. </param>
        /// <param name="pageModel"> The data/view model of the current wizard page.  </param>
        /// <param name="type"> The type of the current wizard page.  </param>
        protected HtmlWizardPage(string title, string description, Wizard wizard, IWizardPageModel pageModel, WizardPageType type)
            : base(title, description, wizard, pageModel, type)
        {
            InitializeWebView(pageModel);
        }

        #endregion Protected Constructors

        #region Private Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="HtmlWizardPage" /> class from being created. 
        /// </summary>
        private HtmlWizardPage()
        {
            InitializeComponent();
        }

        #endregion Private Constructors

        #region Protected Internal Properties

        protected TM HtmlModel { get; private set; }

        /// <summary>
        /// Gets the focusing control, which will be focused when the wizard page is showing.
        /// </summary>
        /// <value>
        /// The focusing control.
        /// </value>
        protected internal override Control FocusingControl
        {
            get
            {
                return this.webView;
            }
        }

        /// <summary>
        /// Gets the logo image to be shown on the title area of the wizard.
        /// </summary>
        /// <value>
        /// The logo image.
        /// </value>
        protected internal override System.Drawing.Image Logo
        {
            get { return null; }
        }

        #endregion Protected Internal Properties

        #region Protected Internal Methods

        /// <summary>
        /// The callback method being executed when user clicks the Next button on the wizard, but
        /// before the wizard is opening the next page.
        /// </summary>
        /// <returns>
        ///   <c>True</c> if the wizard can go to the next page, otherwise, <c>false</c>.
        /// </returns>
        protected internal override Task<bool> ExecuteBeforeGoingNextAsync()
        {
            return TaskTrue;
        }

        /// <summary>
        /// The callback method being executed when user clicks the Previous button on the wizard,
        /// but before the wizard is opening the previous page.
        /// </summary>
        /// <returns>
        ///   <c>True</c> if the wizard can go to the previous page, otherwise, <c>false</c>.
        /// </returns>
        protected internal override Task<bool> ExecuteBeforeGoingPreviousAsync()
        {
            return TaskTrue;
        }

        /// <summary>
        /// The callback method being executed when user clicks the Finish button on the wizard,
        /// but before the wizard is going to finish and close.
        /// </summary>
        /// <returns>
        ///   <c>True</c> if the wizard can go to the finish page, otherwise, <c>false</c>.
        /// </returns>
        protected internal override Task<bool> ExecuteBeforeGoingFinishAsync()
        {
            return TaskTrue;
        }

        /// <summary>
        /// The callback method being executed when the current wizard page is showing. 
        /// </summary>
        protected internal override Task ExecuteShowAsync(IWizardPage fromPage)
        {
            return TaskEmpty;
        }

        /// <summary>
        /// Persists the values on current wizard page to the data model. 
        /// </summary>
        protected internal override void PersistValuesToModel()
        {
            var doc = this.webView.Document;
            if (doc != null)
            {
                var jsonModel = doc.InvokeScript("PersistModelToHost", null).ToString();
                var htmlModel = JsonConvert.DeserializeObject<TM>(jsonModel, new JsonSerializerSettings { ContractResolver = new HtmlWizardPageModelContractResolver() });
                if (htmlModel != null)
                {
                    this.HtmlModel = htmlModel;
                }
            }
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion Protected Internal Methods

        #region Private Methods

        /// <summary>
        /// Initialize web view with model, load the HTML page and inject script for model.
        /// </summary>
        /// <param name="model"> The page model. </param>
        /// <exception cref="InvalidCastException">
        /// The page model should be a HtmlWizardPageModel. 
        /// </exception>
        private void InitializeWebView(IWizardPageModel model)
        {
            this.SetBrowserFeatureControl();
            this.InitializeComponent();
            this.webView.DocumentCompleted += WebViewDocumentCompleted;

            if (model != null)
            {
                var htmlModel = model as TM;
                if (htmlModel == null)
                {
                    throw new InvalidCastException("The page model should be a HtmlWizardPageModel.");
                }

                this.HtmlModel = htmlModel;
                if (string.IsNullOrEmpty(htmlModel.Html))
                {
                    this.webView.Navigate(htmlModel.PageUrl);
                }
                else
                {
                    this.webView.DocumentText = htmlModel.Html;
                }
            }
        }

        private void WebViewDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webView.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }

            var doc = this.webView.Document;
            if (doc != null)
            {
                HtmlElement head = doc.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = doc.CreateElement("script");
                if (scriptEl != null)
                {
                    scriptEl.SetAttribute("text", Resources.HtmlWizardPage);
                    head.AppendChild(scriptEl);
                }

                if (this.HtmlModel != null)
                {
                    var modelJson = JsonConvert.SerializeObject(this.HtmlModel, new JsonSerializerSettings { ContractResolver = new HtmlWizardPageModelContractResolver() });
                    doc.InvokeScript("InitializeModel", new object[] { modelJson });
                }
            }
        }

        /// <summary>
        /// Sets the browser feature control.
        /// </summary>
        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (string.Compare(fileName, "devenv.exe", StringComparison.OrdinalIgnoreCase) == 0 ||
                string.Compare(fileName, "XDesProc.exe", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return;
            }

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode());
            //// Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                string.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                if (key != null)
                {
                    key.SetValue(appName, value, RegistryValueKind.DWord);
                }
            }
        }

        private uint GetBrowserEmulationMode()
        {
            int browserVersion;
            using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                RegistryRights.QueryValues))
            {
                if (key == null)
                {
                    throw new ApplicationException("Microsoft Internet Explorer is required!");
                }

                var version = key.GetValue("svcVersion");
                if (null == version)
                {
                    version = key.GetValue("Version");
                    if (null == version)
                    {
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                    }
                }

                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            uint mode;
            //// Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000;
                    //// Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000;
                    //// Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000;
                    //// Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000;
                    //// Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    mode = 11001;
                    //// Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
                    break;
            }

            return mode;
        }

        #endregion
    }
}
