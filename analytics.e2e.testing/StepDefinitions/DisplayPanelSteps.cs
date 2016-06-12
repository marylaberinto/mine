using System.Linq;
using findly.TestAutomation.Analytics.PageObjects;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class DisplayPanelSteps
    {
        [Then(@"I should be able to see the panels (.*)")]
        public void ThenIShouldBeAbleToSeeThePanels (string panelNames)
        {
            var panelNameList = panelNames.Replace(", ", ",").Split(',').ToList(); 
            Websites.Demographics.AssertHasPanelLoaded(panelNameList);
        }
    }
}
