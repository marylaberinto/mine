﻿using findly.TestAutomation.Analytics.PageObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class TabSteps
    {
        [Then(@"I should be able to see the tabs (.*)")]
        public void ThenIShouldBeAbleToSeeTheTabs(string tabNames)
        {
            var tabNameList = tabNames.Replace(", ", ",").Split(',').ToList();
            Websites.AnalyticsPage.AssertHasTabsLoaded(tabNameList);
        }

        [When(@"I click on Demographics tab")]
        public void ClickOnDemographicsTab()
        {
            Websites.AnalyticsPage.ClickOnDemographicsTab();
        }

        [Then(@"the Demographics tab should be selected")]
        public void ThenTheDemographicsTabShouldBeSelected()
        {
            Websites.AnalyticsPage.AssertDemographicsTabisSelected();
        }

    }
}