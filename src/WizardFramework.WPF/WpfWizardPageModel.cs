namespace WizardFramework.WPF
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Threading;

    using WizardFramework;

    /// <summary>
    /// The WPF wizard page model.
    /// </summary>
    public abstract class WpfWizardPageModel : WizardPageModel, INotifyPropertyChanged
    {
        private string title;

        private string description;

        private WizardPageType pageType;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWizardPageModel"/> class.
        /// </summary>
        protected WpfWizardPageModel()
        {
            this.Dispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWizardPageModel"/> class. 
        /// </summary>
        /// <param name="title"> The title.  </param>
        /// <param name="description"> The description.  </param>
        /// <param name="pageType"> The wizard page Type. </param>
        protected WpfWizardPageModel(string title, string description, WizardPageType pageType = WizardPageType.Standard)
            : this()
        {
            this.Title = title;
            this.Description = description;
            this.PageType = pageType;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the page type.
        /// </summary>
        public WizardPageType PageType
        {
            get
            {
                return pageType;
            }

            set
            {
                pageType = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the dispatcher.
        /// </summary>
        public Dispatcher Dispatcher { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
