﻿using System.Linq;
using findly.TestAutomation.Analytics.PageObjects;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class FilterTypesSteps
    {
        [When(@"I type (.*) on the search field")]
        public void WhenITypeOnTheSearchField(string value)
        {
            Websites.AnalyticsPage.EnterCriteriaInSearchField(value);
        }

        [Then(@"I should be able to see all filters (.*)")]
        public void ThenIShouldBeAbleToSeeAllFilters(string filters)
        {
            var filterList = filters.Replace(", ", ",").Split(',').ToList();
            Websites.AnalyticsPage.AssertAllFiltersExist(filterList);
        }
    }
}
