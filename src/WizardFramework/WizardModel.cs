namespace WizardFramework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> The wizard model. </summary>
    public abstract class WizardModel : IWizardModel
    {
        #region Private Fields

        private readonly List<Tuple<Type, WizardPageModel>> wizardPageModels = new List<Tuple<Type, WizardPageModel>>();

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets a list of <see cref="WizardPageModel" /> instances that represent the data model for
        /// each wizard page in the wizard.
        /// </summary>
        /// <value> The list of <see cref="WizardPageModel" /> instances. </value>
        public IEnumerable<WizardPageModel> PageModels
        {
            get { return this.wizardPageModels.Select(p => p.Item2); }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count
        {
            get { return this.wizardPageModels.Count; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns an enumerator that iterates through the collection. 
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate
        /// through the collection.
        /// </returns>
        public IEnumerator<Tuple<Type, WizardPageModel>> GetEnumerator()
        {
            return this.wizardPageModels.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.wizardPageModels.GetEnumerator();
        }

        /// <summary>
        /// Add an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <typeparam name="T"> The type of wizard page. </typeparam>
        /// <param name="model">
        /// The wizard page model to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </param>
        public void Add<T>(WizardPageModel model) where T : WizardPageBase
        {
            if (model != null)
            {
                model.WizardModel = this;
            }
            wizardPageModels.Add(new Tuple<Type, WizardPageModel>(typeof(T), model));
        }

        /// <summary>
        /// Add an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="type">
        /// The wizard page type to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <param name="model">
        /// The wizard page model to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        public void Add(Type type, WizardPageModel model)
        {
            if (model != null)
            {
                model.WizardModel = this;
            }
            wizardPageModels.Add(new Tuple<Type, WizardPageModel>(type, model));
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />. 
        /// </summary>
        public void Clear()
        {
            wizardPageModels.ForEach(i => i.Item2.WizardModel = null);
            wizardPageModels.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" />
        /// contains a specific value.
        /// </summary>
        /// <param name="model">
        /// The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <returns>
        /// true if <paramref name="model" /> is found in the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        public bool Contains(WizardPageModel model)
        {
            return this.wizardPageModels.Exists(p => p.Item2.Equals(model));
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="model">
        /// The wizard page model to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <returns>
        /// true if <paramref name="model" /> was successfully removed from the <see
        /// cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also
        /// returns false if <paramref name="model" /> is not found in the original <see
        /// cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(WizardPageModel model)
        {
            var removable = this.wizardPageModels.FirstOrDefault(t => t.Item2.Equals(model));
            if (removable != null)
            {
                removable.Item2.WizardModel = null;
                return this.wizardPageModels.Remove(removable);
            }

            return false;
        }

        #endregion
    }
}
