using System;
using System.Windows.Forms;

namespace WizardFramework
{
    /// <summary>
    /// Represents the class which handles the lengthy operation.
    /// </summary>
    /// <remarks>
    /// This class will set the cursor to the <c>Cursors.WaitCursor</c> before
    /// the lengthy operation is being executing, and set the cursor back to normal
    /// after the lengthy operation has completed.
    /// </remarks>
    internal sealed class LengthyOperation : IDisposable
    {
        #region Private Fields

        private readonly Form form;
        private readonly Action preprocess;
        private readonly Action postprocess;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LengthyOperation"/> class.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="preprocess">The callback method which is executing before the lengthy operation starts.</param>
        /// <param name="postprocess">The callback method which is executed after the lengthy operation has done.</param>
        public LengthyOperation(Form form, Action preprocess = null, Action postprocess = null)
        {
            this.form = form;
            form.Cursor = Cursors.WaitCursor;
            this.preprocess = preprocess;
            this.postprocess = postprocess;
            if (preprocess != null)
            {
                preprocess();
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.postprocess != null)
            {
                this.postprocess();
            }

            this.form.Cursor = Cursors.Default;
        }

        #endregion Public Methods
    }
}