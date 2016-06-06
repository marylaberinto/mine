using System;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class FilterTypesSteps
    {
        [When(@"I click on the search field")]
        public void WhenIClickOnTheSearchField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I type '(.*)'")]
        public void WhenIType(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to see all (.*)")]
        public void ThenIShouldBeAbleToSeeAll(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
