namespace WizardFramework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents that the implemented classes are data models for wizard page.
    /// </summary>
    public interface IWizardModel : IEnumerable<Tuple<Type, WizardPageModel>>
    {
        /// <summary>
        /// Gets a list of <see cref="WizardPageModel" /> instances that represent the data model for
        /// each wizard page in the wizard.
        /// </summary>
        /// <value> The list of <see cref="WizardPageModel" /> instances. </value>
        IEnumerable<WizardPageModel> PageModels { get; }

        /// <summary>
        /// Gets the number of elements contained in the model collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <typeparam name="T"> The type of wizard page. </typeparam>
        /// <param name="model">
        /// The wizard page model to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </param>
        void Add<T>(WizardPageModel model) where T : WizardPageBase;

        /// <summary>
        /// Add an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="type">
        /// The wizard page type to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <param name="model">
        /// The wizard page model to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        void Add(Type type, WizardPageModel model);

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />. 
        /// </summary>
        void Clear();

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
        bool Contains(WizardPageModel model);

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
        bool Remove(WizardPageModel model);
    }
}