using findly.TestAutomation.Analytics.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class AutoSuggestSteps
    {
        [Then(@"I should be able to see the autosuggest popup")]
        public void ThenIShouldBeAbleToSeeTheAutosuggestPopup(string popup)
        {
            Websites.AnalyticsPage.AssertAutoSuggestExist();
        }
    }
}
