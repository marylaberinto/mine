using System;
using findly.TestAutomation.Analytics.DiscoveryUI;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class AuthenticationSteps
    {
        [Given(@"I log into CRM with approved permission")]
        public void GivenILogIntoCRMWithApprovedPermission()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I navigate to the portal")]
        public void WhenINavigateToThePortal()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to see the analytics page")]
        public void ThenIShouldBeAbleToSeeTheAnalyticsPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to see the search bar")]
        public void ThenIShouldBeAbleToSeeTheSearchBar()
        {
            ScenarioContext.Current.Pending();
        }
        [Given(@"I log into CRM with no approved permission")]
        public void GivenILogIntoCRMWithNoApprovedPermission()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not be able to see the analytics page")]
        public void ThenIShouldNotBeAbleToSeeTheAnalyticsPage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
