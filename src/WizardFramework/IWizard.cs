using System;
using System.Collections.Generic;

namespace WizardFramework
{
    /// <summary>
    /// Represents that the implemented classes are wizards. 
    /// </summary>
    public interface IWizard : ICollection<_WizardPage>
    {
        #region Public Properties

        /// <summary>
        /// Gets a list of <see cref="IWizardModel" /> instances that represent the data model for
        /// each wizard page in the wizard.
        /// </summary>
        /// <value> The list of <see cref="IWizardModel" /> instances. </value>
        IEnumerable<IWizardModel> Models { get; }

        /// <summary>
        /// Gets or sets the text of the wizard. Usually this text will be displayed as the title of
        /// the wizard form.
        /// </summary>
        /// <value> The text of the wizard. </value>
        string Text { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// The factory method for creating a wizard page with specific wizard type. 
        /// </summary>
        /// <typeparam name="T"> The type of the wizard page to be created. </typeparam>
        /// <returns> A <see cref="WizardPage" /> instance that is created. </returns>
        T CreatePage<T>() where T : _WizardPage;

        /// <summary>
        /// Gets the data model from the wizard with specified model type. 
        /// </summary>
        /// <typeparam name="T"> The <see cref="Type" /> of the model. </typeparam>
        /// <returns> The data model for the particular wizard page. </returns>
        T GetWizardModel<T>() where T : class, IWizardModel;

        #endregion Public Methods
    }
}