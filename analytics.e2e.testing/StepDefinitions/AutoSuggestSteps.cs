using findly.TestAutomation.Analytics.PageObjects;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class AutoSuggestSteps
    {
        [When(@"I enter the criteria (.*)")]
        public void WhenIEnterTheCriteria (string value)
        {
            Websites.AnalyticsPage.EntertheCriteria(value);
        }

        [Then(@"I should be able to see the autosuggest popup")]
        public void ThenIShouldBeAbleToSeeTheAutosuggestPopup()
        {
            Websites.AnalyticsPage.AssertAutoSuggestExist();
        }
    }
}
