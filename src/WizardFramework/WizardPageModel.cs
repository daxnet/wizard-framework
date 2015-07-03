namespace WizardFramework
{
    using System;

    /// <summary> The wizard page model. </summary>
    public abstract class WizardPageModel : IWizardPageModel
    {
        private readonly WeakReference<IWizardModel> wizardModelReference = new WeakReference<IWizardModel>(null);

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageModel"/> class.
        /// </summary>
        protected WizardPageModel()
        {
        }

        /// <summary>
        /// Gets the wizard model. Since this property is a weak reference to wizard model, 
        /// please check null before using it.
        /// </summary>
        public IWizardModel WizardModel
        {
            get
            {
                IWizardModel model = null;
                wizardModelReference.TryGetTarget(out model);
                return model;
            }

            internal set
            {
                wizardModelReference.SetTarget(value);
            }
        }
    }
}
