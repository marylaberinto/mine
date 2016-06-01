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

        public static string TestUserName
        {
            get { return (string)FeatureContext.Current["TestUserName"]; }
            set { FeatureContext.Current.Set(value, "TestUserName"); }
        }

        public static string TestUserPassword
        {
            get { return (string)FeatureContext.Current["TestUserPassword"]; }
            set { FeatureContext.Current.Set(value, "TestUserPassword"); }
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
