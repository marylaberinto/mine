using System.Collections.Generic;
using System.Linq;
using Coypu;
using findly.TestAutomation.Analytics.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public class AnalyticsPage
    {
        private readonly BrowserSession _browser = FeatureContextWrapper.BrowserSession;
        private readonly ElementScope _analyticsiFrame;


        //Analytics Constructor
        public AnalyticsPage()
        {
            _analyticsiFrame = _browser.FindWindow("Findly Analytics").FindFrame("iFrameResizer0");
        }

        public void ClickOnDemographicsTab()
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            _analyticsiFrame.FindLink("Demographics").Click();
        }

        public void AssertDemographicsTabisSelected()
        {
            var actualTab = _analyticsiFrame.FindCss(".tab__text--active", CoypuOptions.Timeout(20)).Text;
            StringAssert.AreEqualIgnoringCase("Demographics", actualTab, "Demographics tab is not selected");
        }

        public void AssertDiscoveryuiLoaded()
        {
            Assert.True(_analyticsiFrame.FindId("search", CoypuOptions.Timeout(20)).Exists(),
                "Discovery UI Search bar failed to load");
        }

        public void AssertHasPanelsLoaded(List<string> panelNameList)
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

        public void EnterCriteria(string value)
        {
            EnterCriteriaInSearchField(value);
            _analyticsiFrame.FindId("search", CoypuOptions.Timeout(60)).SendKeys(Keys.Enter, CoypuOptions.Timeout(60));
        }

        public void AssertSearchTag(string parameter)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            var actualParameter = _analyticsiFrame.FindCss(".square--primary").Text;
            Assert.AreEqual(parameter, actualParameter, "The query tag does not match the search parameter");
        }

        public void AssertSearchQuery(string query)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            var actualQuery =
                _analyticsiFrame.FindId("demographic-active-query", new Options {ConsiderInvisibleElements = true})
                    .InnerHTML;
            StringAssert.Contains(query, actualQuery, "The query string does not match the search criteria");
        }

        public void EnterQualifier(string value)
        {
            EnterCriteriaInSearchField(value);
            if (!_analyticsiFrame.FindCss(".search-bar__panel-section").Exists(CoypuOptions.Timeout(60))) return;
            _analyticsiFrame.FindId("search", CoypuOptions.Timeout(60))
                .SendKeys(Keys.Enter, CoypuOptions.Timeout(60));
        }

        public void ClickOnOperator(string op)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            _analyticsiFrame.FindCss(".chip.chip--light").Click();
        }

        public void AssertQueryOperator(string op)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            var actualOperator = _analyticsiFrame.FindCss("a[data-op-key]").Text;
            StringAssert.AreEqualIgnoringCase(op, actualOperator, "Unable to find the expected operator");
        }

        public void AssertHasTabsLoaded(List<string> tabNameList)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            var tabsElements = _analyticsiFrame.FindAllCss(".tabs", null, CoypuOptions.Timeout(60));
            var tabTitles = tabsElements.Select(tabsElement => tabsElement.Text).ToList();
            CollectionAssert.AreEquivalent(tabNameList, tabTitles,
                "Atleast one of the tab titles has not loaded correctly");
        }

        public void SelectPanelEntry(string panelTitle, string parameter)
        {
            if (!_analyticsiFrame.Exists(CoypuOptions.Timeout(60))) return;
            //This should work after DMP-681 
            var rowElement = string.Format("data-item-type={0} data-item-name={1}", panelTitle, parameter);
            _analyticsiFrame.FindCss(rowElement).Click();
        }
    }
}