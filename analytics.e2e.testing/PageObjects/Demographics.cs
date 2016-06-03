using Coypu;
using findly.TestAutomation.Analytics.Helpers;
using NUnit.Framework;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public class Demographics
    {
        private readonly BrowserSession _browser = FeatureContextWrapper.BrowserSession;

        public void AssertDiscoveryuiLoaded()
        {
            Assert.True(_browser.FindId("search").Exists(), "Discovery UI Search bar failed to load");
        }
    }
}
