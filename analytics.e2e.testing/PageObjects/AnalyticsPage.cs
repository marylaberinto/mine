using System.Collections.Generic;
using System.Linq;
using Coypu;
using findly.TestAutomation.Analytics.Helpers;
using NUnit.Framework;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public class AnalyticsPage
    {
        private readonly BrowserSession _browser = FeatureContextWrapper.BrowserSession;
        private readonly ElementScope _analyticsiFrame;

        //Analytics Constructor
        public AnalyticsPage()
        {
            //In absence of any other attribute, using empty string for finding the frame on the page.
            _analyticsiFrame = _browser.FindWindow("Findly Analytics").FindFrame("");
        }

        public void AssertDiscoveryuiLoaded()
        {
            Assert.True(_analyticsiFrame.FindId("search", CoypuOptions.Timeout(20)).Exists(), "Discovery UI Search bar failed to load");
        }

        public void AssertHasPanelLoaded(List<string> panelNameList)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            var panelElements = _analyticsiFrame.FindAllCss(".card__header-title", null, CoypuOptions.Timeout(60));
            var panelTitles = panelElements.Select(panelElement => panelElement.Text).ToList();
            CollectionAssert.AreEquivalent(panelNameList, panelTitles,
                "Atleast one of the panel titles has not loaded correctly");
        }

        public void EnterCriteriaInSearchField(string value)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            _analyticsiFrame.FindId("search", CoypuOptions.Timeout(20)).FillInWith(value);
        }

        public void AssertAllFiltersExist(List<string> filterList)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            var filterElements = _analyticsiFrame.FindAllCss(".square", null, CoypuOptions.Timeout(60));
            var actualFilters = filterElements.Select(filterElement => filterElement.Text).ToList();
            CollectionAssert.AreEquivalent(filterList, actualFilters,
                "Atleast one of the filters has not loaded correctly");
        }
    }
}