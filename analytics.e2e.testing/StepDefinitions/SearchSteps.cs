using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using findly.TestAutomation.Analytics.PageObjects;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        [When(@"I enter qualifier (.*)")]
        public void WhenIEnterQualifier (string value)
        {
            Websites.AnalyticsPage.EnterQualifier(value);
        }

        [When(@"I search with the criteria (.*)")]
        public void WhenISearchWithTheCriteria (string value)
        {
            Websites.AnalyticsPage.EnterCriteria(value);
        }

        [Then(@"I should see the search tag (.*)")]
        public void ThenIShouldSeeTheSearchTag (string parameter)
        {
            Websites.AnalyticsPage.AssertSearchTag(parameter);           
        }

        [Then(@"I should see the query containing (.*)")]
        public void ThenIShouldSeeTheQueryContaining (string query)
        {
            Websites.AnalyticsPage.AssertSearchQuery(query);
        }
    }
}
