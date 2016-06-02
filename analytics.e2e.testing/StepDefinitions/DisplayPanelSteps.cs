using System;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class DisplayPanelSteps
    {
        [Given(@"I log into CRM")]
        public void GivenILogIntoCRM()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to see the Types")]
        public void ThenIShouldBeAbleToSeeTheTypes()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
