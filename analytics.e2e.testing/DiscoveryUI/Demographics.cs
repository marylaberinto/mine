using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coypu;
using findly.TestAutomation.Analytics.Helpers;

namespace findly.TestAutomation.Analytics.DiscoveryUI
{
    public class Demographics
    {
        private readonly BrowserSession _browser = FeatureContextWrapper.BrowserSession;

        //other page actions
        /*
        public void NavigateToAndGoToSignIn()
        {
            _browser.Visit(TestSettings.TheHiveUrl);
            if (_browser.FindLink("Log in now").Exists())
            {
                _browser.FindLink("Log in now").Click();
            }
        }
        */
    }
}
