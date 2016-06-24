using Coypu;
using findly.TestAutomation.Analytics.Helpers;
using NUnit.Framework;

namespace findly.TestAutomation.Analytics.PageObjects
{
    public class FindlyCRM
    {
        private readonly BrowserSession _browser = FeatureContextWrapper.BrowserSession;

        public void NavigateToWaggle()
        {
            _browser.Visit(TestSettings.WaggleUrl);
        }

        public void LogIn(string userName, string password)
        {
            if (IsCorrectUserSignedIn(userName)) return;
            if (!IsBrowserOnSignInPage())
            {
                NavigateToWaggle();
            }
            _browser.FindId("EmailAddress").Exists();
            _browser.FindId("EmailAddress").FillInWith(userName);
            _browser.FindId("Password").FillInWith(password);
            _browser.FindId("btnSubmit").Click();

            FeatureContextWrapper.IsLoggedIn = true;
            FeatureContextWrapper.LoggedInUser = userName;
        }

        public void SignOut()
        {
            _browser.FindCss("ul.navbar-nav a[data-id=settings]", CoypuOptions.Timeout(15)).Exists();
            _browser.FindCss("ul.navbar-nav a[data-id=settings]").Click();
            _browser.FindCss("[data-id='logout']").Exists();
            _browser.FindCss("[data-id='logout']").Click();
        }

        private bool IsCorrectUserSignedIn (string userName)
        {
            if (!FeatureContextWrapper.IsLoggedIn) return false;
            if (FeatureContextWrapper.LoggedInUser != userName)
            {
                SignOut();
                return false;
            }
            NavigateToWaggle();
            return true;
        }

        public bool IsBrowserOnSignInPage()
        {
            return _browser.Location.ToString().Contains("SignIn") && _browser.FindId("EmailAddress").Exists();
        }

        public void NavigateToAnalytics()
        {
            _browser.FindCss("ul.navbar-nav a[data-id=settings]").Click(CoypuOptions.Timeout(15));
            _browser.FindCss("[data-id='analytics']").Click(CoypuOptions.Timeout(15));
        }

        public void AssertIsAnalyticsPage()
        {
            Assert.True(_browser.FindWindow("Findly Analytics", CoypuOptions.Timeout(15)).Exists(), "The user did not re-direct to Analytics page");
        }

        public void AssertNoAccessToAnalytics()
        {
            _browser.FindCss("ul.navbar-nav a[data-id=settings]", CoypuOptions.Timeout(15)).Exists();
            _browser.FindCss("ul.navbar-nav a[data-id=settings]").Click();
            Assert.False(_browser.FindCss("[data-id='analytics']").Exists(), "Link to analytics is available to the user");
        }
    }
}
