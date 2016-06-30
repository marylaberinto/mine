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

        [When(@"I click on (.*) panel entry (.*)")]
        public void WhenIClickOnAPanelEntry (string panelTitle, string parameter )
        {
            Websites.AnalyticsPage.SelectPanelEntry(panelTitle, parameter);
        }

        [Then(@"I should see the search tag (.*)")]
        public void ThenIShouldSeeTheSearchTag (string parameter)
        {
            Websites.AnalyticsPage.AssertSearchTag(parameter);           
        }

        [Then(@"The search query should contain the string (.*)")]
        public void ThenTheSearchQueryShouldContainTheString (string query)
        {
            Websites.AnalyticsPage.AssertSearchQuery(query);
        }
    }
}
