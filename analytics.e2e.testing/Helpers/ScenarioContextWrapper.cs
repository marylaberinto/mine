using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.Helpers
{
    public static class ScenarioContextWrapper
    {
        //Scenario variables
        public static string SignUpEmail
        {
            get { return (string)ScenarioContext.Current["SignUpEmail"]; }
            set { ScenarioContext.Current.Set(value, "SignUpEmail"); }
        }
    }
}
