using Findly.FunctionalAutomation.FeatureToggle;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public class FeatureToggleSteps
    {
        private readonly IFeatureToggleService _featureToggleService;

        public FeatureToggleSteps(IFeatureToggleService featureToggleService)
        {
            _featureToggleService = featureToggleService;
        }

        [Given(@"(.*) is Feature Toggled (.*)")]
        public void GivenServiceIsFeatureToggled(string toggleKey, string onOrOff)
        {
            var shouldShow = onOrOff == "On";
            _featureToggleService.SetFeatureToggle(toggleKey, shouldShow);
        }
    }
}
