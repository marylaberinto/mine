using System.Collections.Generic;
using Findly.FunctionalAutomation.FeatureToggle;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public static class FeatureToggleFeatureHooks
    {
        private static List<FeatureToggle> _beforeFeatureStartedValue;

        private static readonly FeatureToggleService FeatureToggleService = new FeatureToggleService();
            // can't use ObjectContainer as it can only be used in scenario blocks

        [BeforeFeature("PersistExistingFeatureToggle")]
        public static void FeatureSetup_FeatureToggle()
        {
            _beforeFeatureStartedValue = FeatureToggleService.GetFeaturesStateForProduct();
        }

        [AfterFeature("PersistExistingFeatureToggle")]
        public static void FeatureTearDown_FeatureToggle()
        {
            //Here we make sure we re-set all the toggles the same way they were before we started the test
            foreach (var featureToggle in _beforeFeatureStartedValue)
            {
                FeatureToggleService.SetFeatureToggle(featureToggle.Feature, featureToggle.IsShowing);
            }
        }
    }
}

