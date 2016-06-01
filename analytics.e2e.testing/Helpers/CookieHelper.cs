using System;
using Coypu;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.Helpers
{
    public class CookieHelper
    {
        public string GetCookie (string name)
        {
            try
            {
                BrowserSession _browser = FeatureContextWrapper.BrowserSession;
                var selenium = ((OpenQA.Selenium.Remote.RemoteWebDriver)_browser.Native);
                return selenium.Manage().Cookies.GetCookieNamed(name).Value;
            } catch
            {
                return "";
            }
        }

        public void DeleteAllCookies ()
        {
            // Only delete cookies if FeatureConterxtWrapper has a BrowserSession
            try
            {
                BrowserSession _browser = FeatureContextWrapper.BrowserSession;
                var selenium = ((OpenQA.Selenium.Remote.RemoteWebDriver)_browser.Native);
                selenium.Manage().Cookies.DeleteAllCookies();
            } catch { }
        }

    }
}
