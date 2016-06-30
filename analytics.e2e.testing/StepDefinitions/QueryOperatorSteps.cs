using findly.TestAutomation.Analytics.PageObjects;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class QueryOperatorSteps
    {
        [When(@"I click the (.*) operator")]
        public void WhenIClickTheAndOperator (string op)
        {
            Websites.AnalyticsPage.ClickOnOperator(op);
        }

        [Then(@"I should see a query operator (.*)")]
        public void ThenIShouldSeeAQueryOperator(string op)
        {
            Websites.AnalyticsPage.AssertQueryOperator(op);
        }
    }
}