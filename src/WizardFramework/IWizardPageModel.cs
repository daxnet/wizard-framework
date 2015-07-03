namespace WizardFramework
{
    /// <summary>
    /// Represents that the implemented classes are data models for wizard page.
    /// </summary>
    public interface IWizardPageModel
    {
        /// <summary>
        /// Gets the wizard model.
        /// </summary>
        IWizardModel WizardModel { get; }
    }
}
