using findly.TestAutomation.Analytics.Helpers;
using findly.TestAutomation.Analytics.PageObjects;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class AuthenticationSteps
    {
        [Given(@"I log into CRM as an authenticated user")]
        public void GivenILogIntoCrmAsAnAuthenticatedUser()
        {
            Websites.FindlyCRM.LogIn(TestSettings.WaggleUserName, TestSettings.WagglePassword);
        }
        
        [When(@"I navigate to the analytics portal")]
        public void WhenINavigateToTheAnalyticsPortal()
        {
            Websites.FindlyCRM.NavigateToAnalytics();
        }
        
        [Then(@"I should be able to see the analytics page")]
        public void ThenIShouldBeAbleToSeeTheAnalyticsPage()
        {
            Websites.FindlyCRM.AssertIsAnalyticsPage();
        }
        
        [Then(@"I should be able to view Discovery UI")]
        public void ThenIShouldBeAbleToViewDiscoveryUi()
        {
            Websites.Demographics.AssertDiscoveryuiLoaded();
        }

        [Then(@"I should not be able to navigate to the analytics portal")]
        public void ThenIShouldNotBeAbleToNavigateToTheAnalyticsPortal ()
        {
            Websites.FindlyCRM.AssertNoAccessToAnalytics();
        }

        [Then(@"I should not be able to see the analytics page")]
        public void ThenIShouldNotBeAbleToSeeTheAnalyticsPage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
