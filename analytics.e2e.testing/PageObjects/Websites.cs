using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public static class Websites
    {
        public static Demographics Demographics
        {
            get { return (Demographics)ScenarioContext.Current["Demographics"]; }
            set { ScenarioContext.Current.Set(value, "Demographics"); }
        }

        public static FindlyCRM FindlyCRM
        {
            get { return (FindlyCRM)ScenarioContext.Current["FindlyCRM"]; }
            set { ScenarioContext.Current.Set(value, "FindlyCRM"); }
        }

    }
}
