using System;
using System.Windows.Forms;

namespace WizardFramework
{
    /// <summary>
    /// Represents that the implemented classes are wizard pages. 
    /// </summary>
    public interface IWizardPage
    {

        #region Public Events

        /// <summary>
        /// Occurs when the navigation states have been updated via <c> CanGoCancel </c>, <c>
        /// CanGoFinishPage </c>, <c> CanGoNextPage </c> and <c> CanGoPreviousPage </c> properties.
        /// </summary>
        event EventHandler NavigationStateUpdated;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the wizard operation can be cancelled and the wizard
        /// form can be closed.
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard operation can be cancelled and the wizard form can be
        /// closed; otherwise, <c> false </c>.
        /// </value>
        bool CanGoCancel { get; }

        /// <summary>
        /// Gets a value indicating whether the wizard can finish directly and the wizard form can
        /// be closed.
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard can finish directly and the wizard form can be closed;
        /// otherwise, <c> false </c>.
        /// </value>
        bool CanGoFinishPage { get; }

        /// <summary>
        /// Gets a value indicating whether the wizard can go to the next page. 
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard can go to the next page; otherwise, <c> false </c>.
        /// </value>
        bool CanGoNextPage { get; }

        /// <summary>
        /// Gets a value indicating whether the wizard can go to the previous page. 
        /// </summary>
        /// <value>
        /// <c> true </c> if the wizard can go to the previous page; otherwise, <c> false </c>.
        /// </value>
        bool CanGoPreviousPage { get; }

        /// <summary>
        /// Gets the description of the current wizard page. This description text will be displayed
        /// on top of the wizard.
        /// </summary>
        /// <value> The description of the current wizard page. </value>
        string Description { get; }

        /// <summary>
        /// Gets the data model of the wizard page. 
        /// </summary>
        /// <value> The data model. </value>
        IWizardModel Model { get; }

        /// <summary>
        /// Gets the presentation of the wizard page. The presentation is a <see cref="UserControl"
        /// /> which can be designed in Windows Forms designer.
        /// </summary>
        /// <value> The presentation of the wizard page. </value>
        UserControl Presentation { get; }

        /// <summary>
        /// Gets the title of the current wizard page. This title text will be displayed on top of
        /// the wizard.
        /// </summary>
        /// <value> The title of the current wizard page. </value>
        string Title { get; }

        /// <summary>
        /// Gets the type of the current wizard page. 
        /// </summary>
        /// <value> The type of the current wizard page. </value>
        WizardPageType Type { get; }

        /// <summary>
        /// Gets the instance of <see cref="Wizard" /> class, which contains the current wizard page. 
        /// </summary>
        /// <value> The wizard that contains the current wizard page. </value>
        Wizard Wizard { get; }

        #endregion Public Properties

    }
}