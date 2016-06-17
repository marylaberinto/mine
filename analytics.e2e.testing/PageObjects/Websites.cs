using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public static class Websites
    {
        public static AnalyticsPage AnalyticsPage
        {
            get { return (AnalyticsPage)ScenarioContext.Current["AnalyticsPage"]; }
            set { ScenarioContext.Current.Set(value, "AnalyticsPage"); }
        }

        public static FindlyCRM FindlyCRM
        {
            get { return (FindlyCRM)ScenarioContext.Current["FindlyCRM"]; }
            set { ScenarioContext.Current.Set(value, "FindlyCRM"); }
        }

    }
}
