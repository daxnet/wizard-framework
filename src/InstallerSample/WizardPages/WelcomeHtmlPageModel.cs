namespace InstallerSample.WizardPages
{
    using System;

    using WizardFramework.HTML;

    public class WelcomeHtmlPageModel : HtmlWizardPageModel
    {
        public WelcomeHtmlPageModel()
        {
        }

        public WelcomeHtmlPageModel(string html)
            : base(html)
        {
        }
        public WelcomeHtmlPageModel(Uri pageUrl)
            : base(pageUrl)
        {
        }

        public bool WelcomePageFlag { get; set; }
    }
}
