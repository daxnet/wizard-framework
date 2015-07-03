using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardFramework.HTML
{
    using Newtonsoft.Json.Serialization;

    internal class HtmlWizardPageModelContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            properties = properties.Where(p => p.PropertyName != "WizardModel").ToList();

            return properties;
        }
    }
}
