using System.Collections.Generic;
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

        public void AssertHasPanelLoaded (List<string> panelNameList)
        {
            //In absence of any other attribute, using empty string for finding the frame on the page. 
            var analyticsiFrame = _browser.FindWindow("Findly Analytics").FindFrame("");

            if (analyticsiFrame.Exists(CoypuOptions.Timeout(60)))
            {
                var panelTitles = new List<string>();
                var panelElements = analyticsiFrame.FindAllCss(".card__header-title", null, CoypuOptions.Timeout(60));
                foreach (var panelElement in panelElements)
                {
                    panelTitles.Add(panelElement.Text);
                }
                CollectionAssert.AreEquivalent(panelNameList, panelTitles, "Atleast one of the panel titles has not loaded correctly");
            }
        }
    }
}