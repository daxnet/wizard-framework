using System;
using System.ComponentModel;

namespace WizardFramework
{
    /// <summary>
    /// Represents a component which can be responsible for disposing non-component objects during
    /// its dispose phase.
    /// </summary>
    internal sealed class Disposer : Component
    {
        #region Private Fields

        private readonly Action<bool> disposeDelegation;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Disposer" /> class. 
        /// </summary>
        /// <param name="disposeDelegation"> The dispose delegation. </param>
        public Disposer(Action<bool> disposeDelegation)
        {
            this.disposeDelegation = disposeDelegation;
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Releases the unmanaged resources used by the <see
        /// cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.disposeDelegation(disposing);
        }

        #endregion Protected Methods
    }
}