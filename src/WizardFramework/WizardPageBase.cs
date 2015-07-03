using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardFramework
{
    /// <summary>
    /// Represents the base class of wizard pages. 
    /// </summary>
    public abstract partial class WizardPageBase : UserControl, IWizardPage
    {
        #region Private Fields

        private readonly string description;

        private readonly IWizardPageModel model;

        private readonly string title;

        private readonly Wizard wizard;

        /// <summary>
        /// Represents the empty task.
        /// </summary>
        protected readonly Task TaskEmpty = Task.Factory.StartNew(() => { });

        /// <summary>
        /// Represents the task that simply returns the <c>False</c> value.
        /// </summary>
        protected readonly Task<bool> TaskFalse = Task.Factory.StartNew(() => false);

        /// <summary>
        /// Represents the task that simply returns the <c>False</c> value.
        /// </summary>
        protected readonly Task<bool> TaskTrue = Task.Factory.StartNew(() => true);

        private bool canGoCancel;

        private bool canGoFinishPage;

        private bool canGoNextPage;

        private bool canGoPreviousPage;

        #endregion Private Fields

        #region Public Events

        /// <summary>
        /// Occurs when the navigation states have been updated via <c> CanGoCancel </c>, <c>
        /// CanGoFinishPage </c>, <c> CanGoNextPage </c> and <c> CanGoPreviousPage </c> properties.
        /// </summary>
        public event EventHandler NavigationStateUpdated;

        #endregion Public Events

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageBase" /> class. 
        /// </summary>
        protected WizardPageBase()
        {
            InitializeComponent();
            this.CanGoFinishPage = false;
            this.CanGoNextPage = true;
            this.CanGoPreviousPage = true;
            this.CanGoCancel = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageBase" /> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page. </param>
        /// <param name="description"> The description of the current wizard page. </param>
        /// <param name="wizard">
        /// The <see cref="Wizard" /> instance which contains the current wizard page.
        /// </param>
        /// <param name="model"> The data model of the current wizard page. </param>
        protected WizardPageBase(string title, string description, Wizard wizard, IWizardPageModel model)
            : this(title, description, wizard, model, WizardPageType.Standard)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageBase" /> class. 
        /// </summary>
        /// <param name="title"> The title of the current wizard page. </param>
        /// <param name="description"> The description of the current wizard page. </param>
        /// <param name="wizard">
        /// The <see cref="Wizard" /> instance which contains the current wizard page.
        /// </param>
        /// <param name="model"> The data model of the current wizard page. </param>
        /// <param name="type"> The type of the current wizard page. </param>
        protected WizardPageBase(string title, string description, Wizard wizard, IWizardPageModel model, WizardPageType type)
            : this()
        {
            this.title = title;
            this.description = description;
            this.wizard = wizard;
            this.model = model;
            this.Type = type;
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the wizard operation can be cancelled and the wizard
        /// form can be closed.
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard operation can be cancelled and the wizard form can be
        /// closed; otherwise, <c> false </c>.
        /// </value>
        [Browsable(false)]
        public bool CanGoCancel
        {
            get { return this.canGoCancel; }
            protected set
            {
                if (this.canGoCancel != value)
                {
                    this.canGoCancel = value;
                    this.OnNavigationStateUpdated();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the wizard can finish directly and the wizard form can
        /// be closed.
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard can finish directly and the wizard form can be closed;
        /// otherwise, <c> false </c>.
        /// </value>
        [Browsable(false)]
        public bool CanGoFinishPage
        {
            get { return this.canGoFinishPage; }
            protected set
            {
                if (this.canGoFinishPage != value)
                {
                    this.canGoFinishPage = value;
                    this.OnNavigationStateUpdated();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the wizard can go to the next page. 
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard can go to the next page; otherwise, <c> false </c>.
        /// </value>
        [Browsable(false)]
        public bool CanGoNextPage
        {
            get { return this.canGoNextPage; }
            protected set
            {
                if (this.canGoNextPage != value)
                {
                    this.canGoNextPage = value;
                    this.OnNavigationStateUpdated();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the wizard can go to the previous page. 
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard can go to the previous page; otherwise, <c> false </c>.
        /// </value>
        [Browsable(false)]
        public bool CanGoPreviousPage
        {
            get { return this.canGoPreviousPage; }
            protected set
            {
                if (this.canGoPreviousPage != value)
                {
                    this.canGoPreviousPage = value;
                    this.OnNavigationStateUpdated();
                }
            }
        }

        /// <summary>
        /// Gets the description of the current wizard page. This description text will be displayed
        /// on top of the wizard.
        /// </summary>
        /// <value> The description of the current wizard page. </value>
        [Browsable(false)]
        public string Description
        {
            get { return this.description; }
        }

        /// <summary>
        /// Gets the data model of the wizard page. 
        /// </summary>
        /// <value> The data model. </value>
        [Browsable(false)]
        public IWizardPageModel Model
        {
            get { return this.model; }
        }

        /// <summary>
        /// Gets the presentation of the wizard page. The presentation is a <see cref="UserControl"
        /// /> which can be designed in Windows Forms designer.
        /// </summary>
        /// <value> The presentation of the wizard page. </value>
        [Browsable(false)]
        public UserControl Presentation
        {
            get { return this; }
        }

        /// <summary>
        /// Gets the title of the current wizard page. This title text will be displayed on top of
        /// the wizard.
        /// </summary>
        /// <value> The title of the current wizard page. </value>
        [Browsable(false)]
        public string Title
        {
            get { return this.title; }
        }

        /// <summary>
        /// Gets the type of the current wizard page. 
        /// </summary>
        /// <value> The type of the current wizard page. </value>
        [Browsable(false)]
        public WizardPageType Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the instance of <see cref="Wizard" /> class, which contains the current wizard page. 
        /// </summary>
        /// <value> The wizard that contains the current wizard page. </value>
        [Browsable(false)]
        public Wizard Wizard
        {
            get { return this.wizard; }
        }

        #endregion Public Properties

        #region Protected Internal Properties

        /// <summary>
        /// Gets the focusing control, which will be focused when the wizard page is showing.
        /// </summary>
        /// <value>
        /// The focusing control.
        /// </value>
        protected internal abstract Control FocusingControl { get; }

        /// <summary>
        /// Gets the logo image to be shown on the title area of the wizard.
        /// </summary>
        /// <value>
        /// The logo image.
        /// </value>
        protected internal abstract Image Logo { get; }

        #endregion Protected Internal Properties

        #region Protected Internal Methods

        /// <summary>
        /// The callback method being executed when user clicks the Finish button on the wizard,
        /// but before the wizard is going to finish and close.
        /// </summary>
        /// <returns><c>True</c> if the wizard can go to the finish page, otherwise, <c>false</c>.</returns>
        protected internal abstract Task<bool> ExecuteBeforeGoingFinishAsync();

        /// <summary>
        /// The callback method being executed when user clicks the Next button on the wizard, but
        /// before the wizard is opening the next page.
        /// </summary>
        /// <returns><c>True</c> if the wizard can go to the next page, otherwise, <c>false</c>.</returns>
        protected internal abstract Task<bool> ExecuteBeforeGoingNextAsync();

        /// <summary>
        /// The callback method being executed when user clicks the Previous button on the wizard,
        /// but before the wizard is opening the previous page.
        /// </summary>
        /// <returns><c>True</c> if the wizard can go to the previous page, otherwise, <c>false</c>.</returns>
        protected internal abstract Task<bool> ExecuteBeforeGoingPreviousAsync();
        /// <summary>
        /// The callback method being executed when the current wizard page is showing. 
        /// </summary>
        protected internal abstract Task ExecuteShowAsync(IWizardPage fromPage);

        /// <summary>
        /// Persists the values on current wizard page to the data model. 
        /// </summary>
        protected internal abstract void PersistValuesToModel();

        #endregion Protected Internal Methods

        #region Protected Methods

        /// <summary>
        /// Converts the data model of current page to a strongly typed value. 
        /// </summary>
        /// <typeparam name="T">
        /// The type of the model to which the data model should be converted.
        /// </typeparam>
        /// <returns> The strongly typed data model. </returns>
        protected T ModelAs<T>() where T : WizardPageModel
        {
            return this.model as T;
        }

        /// <summary>
        /// Goes to the next page asynchronously.
        /// </summary>
        /// <returns></returns>
        protected async Task NextAsync()
        {
            await wizard.GoNextPageAsync();
        }

        /// <summary>
        /// Goes to the previous page asynchronously.
        /// </summary>
        /// <returns></returns>
        protected async Task PreviousAsync()
        {
            await wizard.GoPreviousPageAsync();
        }

        #endregion Protected Methods

        #region Private Methods

        private void OnNavigationStateUpdated()
        {
            var handler = this.NavigationStateUpdated;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion Private Methods

    }
}