using Coypu;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.Helpers
{
    public static class FeatureContextWrapper
    {
        public static BrowserSession BrowserSession
        {
            get { return (BrowserSession)FeatureContext.Current["BrowserSession"]; }
            set { FeatureContext.Current.Set(value, "BrowserSession"); }
        }

        public static bool IsLoggedIn
        {
            get { return (bool)FeatureContext.Current["IsLoggedIn"]; }
            set { FeatureContext.Current.Set(value, "IsLoggedIn"); }
        }

        public static string WaggleUserName
        {
            get { return (string)FeatureContext.Current["WaggleUserName"]; }
            set { FeatureContext.Current.Set(value, "WaggleUserName"); }
        }

        public static string WagglePassword
        {
            get { return (string)FeatureContext.Current["WagglePassword"]; }
            set { FeatureContext.Current.Set(value, "WagglePassword"); }
        }

        public static string LoggedInUser
        {
            get { return (string)FeatureContext.Current["LoggedInUser"]; }
            set { FeatureContext.Current.Set(value, "LoggedInUser"); }
        }

        public static void ClearSignedInUser ()
        {
            IsLoggedIn = false;
            LoggedInUser = null;
            if (ScenarioContext.Current != null)
            {
                ScenarioContextWrapper.SignUpEmail = null;
            }

            new CookieHelper().DeleteAllCookies();
        }
    }
}
