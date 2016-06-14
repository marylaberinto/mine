using System.Collections.Generic;
using Coypu;
using findly.TestAutomation.Analytics.Helpers;
using NUnit.Framework;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public class Demographics
    {
        private readonly BrowserSession _browser = FeatureContextWrapper.BrowserSession;
        private readonly ElementScope _analyticsiFrame;

        //Analytics Constructor
        public Demographics()
        {
            //In absence of any other attribute, using empty string for finding the frame on the page.
            _analyticsiFrame = _browser.FindWindow("Findly Analytics").FindFrame("");
        }

        public void AssertDiscoveryuiLoaded()
        {
            Assert.True(_browser.FindId("search").Exists(), "Discovery UI Search bar failed to load");
        }

        public void AssertHasPanelLoaded(List<string> panelNameList)
        {
            if (_analyticsiFrame.Exists(CoypuOptions.Timeout(60)))
            {
                var panelTitles = new List<string>();
                var panelElements = _analyticsiFrame.FindAllCss(".card__header-title", null, CoypuOptions.Timeout(60));
                foreach (var panelElement in panelElements)
                {
                    panelTitles.Add(panelElement.Text);
                }
                CollectionAssert.AreEquivalent(panelNameList, panelTitles,
                    "Atleast one of the panel titles has not loaded correctly");
            }
        }

        public void EnterCriteriaInSearchField(string value)
        {
            if (_analyticsiFrame.Exists(CoypuOptions.Timeout(60)))
            {
                _analyticsiFrame.FindId("search", CoypuOptions.Timeout(20)).FillInWith(value);
            }
        }

        public void AssertAllFiltersExist(List<string> filterList)
        {
            if (_analyticsiFrame.Exists(CoypuOptions.Timeout(60)))
            {
                var actualFilters = new List<string>();
                var filterElements = _analyticsiFrame.FindAllCss(".square", null, CoypuOptions.Timeout(60));
                foreach (var filterElement in filterElements)
                {
                    actualFilters.Add(filterElement.Text);
                }
                CollectionAssert.AreEquivalent(filterList, actualFilters, "Atleast one fo the filters has not loaded correctly");
            }
        }
    }
}