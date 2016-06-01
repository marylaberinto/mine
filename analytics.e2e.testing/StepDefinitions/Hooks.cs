using System;
using System.Configuration;
using System.IO;

using findly.FunctionalAutomation;
using findly.TestAutomation.Analytics.Helpers;
using findly.TestAutomation.Analytics.DiscoveryUI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BoDi;
using Findly.FunctionalAutomation.FeatureToggle;

namespace findly.TestAutomation.Analytics.StepDefinitions
{
    [Binding]
    public static class Hooks
    {
        private static IObjectContainer ObjectContainer
        {
            get
            {
                return (IObjectContainer)ScenarioContext.Current.GetBindingInstance(typeof(IObjectContainer));
            }
        }

        [BeforeFeature]
        public static void FeatureSetup ()
        {
            FeatureContextWrapper.ClearSignedInUser();

        }

        [AfterFeature]
        public static void FeatureTearDown ()
        {
            if (FeatureContextWrapper.BrowserSession == null) return;
            FeatureContextWrapper.BrowserSession.Dispose();
        }

        [BeforeScenario]
        public static void ScenarioSetUp ()
        {
            ObjectContainer.RegisterTypeAs<FeatureToggleService, IFeatureToggleService>();
            FeatureContextWrapper.BrowserSession = BrowserFactory.GetBrowser();
            FeatureContextWrapper.BrowserSession.MaximiseWindow();

            if (FeatureContext.Current.ContainsKey("BrowserHasBeenRefreshed"))
            {
                FeatureContextWrapper.ClearSignedInUser();
            }

            DiscoveryPortal.Demographics = new Demographics();
        }

        [AfterScenario]
        public static void ScenarioTearDown ()
        {
            var sauceLabsEnabled = bool.Parse(ConfigurationManager.AppSettings["SauceLabs.Enabled"]);
            var browserSession = FeatureContextWrapper.BrowserSession;
            var isScenarioFailed = ScenarioContext.Current.TestError != null;

            if (isScenarioFailed && !sauceLabsEnabled)
            {
                try
                {
                    var driver = browserSession.Native;
                    var scenarioName = ScenarioContext.Current.ScenarioInfo.Title.Replace(" ", "_") +
                                       DateTime.UtcNow.Day +
                                       DateTime.UtcNow.Month +
                                       DateTime.UtcNow.Year +
                                       DateTime.UtcNow.Minute +
                                       DateTime.UtcNow.Second;

                    // Save HTML source to file
                    var source = ((IWebDriver)driver).PageSource;
                    var sourceFileName = scenarioName + ".html";
                    var sourceFileLocation = TestSettings.ScreenShotDirectory + sourceFileName;
                    var sourceUrl = ConfigurationManager.AppSettings["HttpUrlForScreenShot"] + sourceFileName;
                    File.WriteAllText(sourceFileLocation, source);
                    Console.WriteLine("\r\nHtml source saved to: " + sourceFileLocation);
                    Console.WriteLine("\r\nHtml Available at: " + sourceUrl);

                    // Save screenshot to file
                    var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    var screenshotFilename = scenarioName + ".png";
                    var screenshotFileLocation = TestSettings.ScreenShotDirectory + screenshotFilename;
                    var screenshotUrl = ConfigurationManager.AppSettings["HttpUrlForScreenShot"] + screenshotFilename;
                    screenShot.SaveAsFile(screenshotFileLocation, TestSettings.ScreenShotImageFormat);
                    Console.WriteLine("\r\nScenario Screenshot saved to: " + screenshotFileLocation);
                    Console.WriteLine("\r\nScenario Available at: " + screenshotUrl);
                } finally
                {
                    FeatureContextWrapper.ClearSignedInUser();
                    FeatureContextWrapper.BrowserSession.Dispose();
                }
            }

            if (!sauceLabsEnabled) return;
            try
            {
                FeatureContextWrapper.BrowserSession.ExecuteScript(isScenarioFailed
                    ? "sauce:job-result=failed"
                    : "sauce:job-result=passed");
            } finally
            {
                FeatureContextWrapper.ClearSignedInUser();
                FeatureContextWrapper.BrowserSession.Dispose();
            }
        }
    }
}
