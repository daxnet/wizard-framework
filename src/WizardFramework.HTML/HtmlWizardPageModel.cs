namespace WizardFramework.HTML
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The html wizard page model.
    /// </summary>
    public class HtmlWizardPageModel : WizardPageModel
    {
        public HtmlWizardPageModel()
        {
        }

        public HtmlWizardPageModel(string html, string title = "", string description = "", WizardPageType pageType = WizardPageType.Expanded)
        {
            Html = html;
            this.Title = title;
            this.Description = description;
            this.PageType = pageType;
        }

        public HtmlWizardPageModel(Uri pageUrl, string title = "", string description = "", WizardPageType pageType = WizardPageType.Expanded)
        {
            PageUrl = pageUrl;
            this.Title = title;
            this.Description = description;
            this.PageType = pageType;
        }
        
        public string Title { get; private set; }

        public string Description { get; private set; }

        public WizardPageType PageType { get; private set; }

        [JsonIgnore]
        public string Html { get; private set; }

        [JsonIgnore]
        public Uri PageUrl { get; private set; }
    }
}
