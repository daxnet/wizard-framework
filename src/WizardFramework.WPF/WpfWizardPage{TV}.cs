namespace WizardFramework.WPF
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using WizardFramework;

    /// <summary> The WPF wizard page. </summary>
    /// <typeparam name="TV"> The WPF view page. </typeparam>
    public partial class WpfWizardPage<TV> : WizardPageBase
        where TV : System.Windows.Controls.UserControl, new()
    {
        #region Constructor

        /// <summary> Initializes a new instance of the <see cref="WpfWizardPage{TV}"/> class. </summary>
        /// <param name="wizard">
        /// The <see cref="Wizard" /> instance which contains the current wizard page.
        /// </param>
        /// <param name="pageModel"> The data/view model of the current wizard page. </param>
        public WpfWizardPage(Wizard wizard, IWizardPageModel pageModel)
            : this(
                pageModel == null ? "" : ((WpfWizardPageModel)pageModel).Title,
                pageModel == null ? "" : ((WpfWizardPageModel)pageModel).Description, 
                wizard, 
                pageModel,
                pageModel == null ? WizardPageType.Standard : ((WpfWizardPageModel)pageModel).PageType)
        {
        }

        #endregion

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWizardPage{TV}"/> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page. </param>
        /// <param name="description"> The description of the current wizard page. </param>
        /// <param name="wizard">
        /// The <see cref="Wizard" /> instance which contains the current wizard page.
        /// </param>
        /// <param name="pageModel"> The data/view model of the current wizard page. </param>
        protected WpfWizardPage(string title, string description, Wizard wizard, IWizardPageModel pageModel)
            : base(title, description, wizard, pageModel, WizardPageType.Standard)
        {
            InitializeWpfView(pageModel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWizardPage{TV}"/> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page.  </param>
        /// <param name="description"> The description of the current wizard page.  </param>
        /// <param name="wizard"> The <see cref="Wizard"/> instance which contains the current wizard page. </param>
        /// <param name="type"> The type of the current wizard page.  </param>
        protected WpfWizardPage(string title, string description, Wizard wizard, WizardPageType type)
            : base(title, description, wizard, null, type)
        {
            InitializeWpfView(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWizardPage{TV}"/> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page.  </param>
        /// <param name="description"> The description of the current wizard page.  </param>
        /// <param name="wizard"> The <see cref="Wizard"/> instance which contains the current wizard page. </param>
        /// <param name="pageModel"> The data/view model of the current wizard page.  </param>
        /// <param name="type"> The type of the current wizard page.  </param>
        protected WpfWizardPage(string title, string description, Wizard wizard, IWizardPageModel pageModel, WizardPageType type)
            : base(title, description, wizard, pageModel, type)
        {
            InitializeWpfView(pageModel);
        }

        #endregion Protected Constructors

        #region Private Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="WpfWizardPage{TV}" /> class from being created. 
        /// </summary>
        private WpfWizardPage()
        {
            InitializeComponent();
        }

        #endregion Private Constructors

        #region Protected Internal Properties

        /// <summary>
        /// Gets the focusing control, which will be focused when the wizard page is showing.
        /// </summary>
        /// <value>
        /// The focusing control.
        /// </value>
        protected internal override Control FocusingControl
        {
            get { return this.eleHost; }
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

        #region Properties

        /// <summary>
        /// Gets the view.
        /// </summary>
        protected TV WpfView { get; private set; }

        #endregion

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
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (this.eleHost != null && this.eleHost.Child != null)
                {
                    this.eleHost.Child = null;
                }

                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion Protected Internal Methods

        #region Private Methods

        private void InitializeWpfView(IWizardPageModel model)
        {
            InitializeComponent();

            this.WpfView = new TV();
            if (model != null)
            {
                var wpfModel = model as WpfWizardPageModel;
                if (wpfModel == null)
                {
                    throw new InvalidCastException("The page model should be a WpfWizardPageModel.");
                }

                wpfModel.Dispatcher = this.WpfView.Dispatcher;
                this.WpfView.DataContext = wpfModel;
            }

            this.eleHost.Child = WpfView;
        }

        #endregion
    }
}
