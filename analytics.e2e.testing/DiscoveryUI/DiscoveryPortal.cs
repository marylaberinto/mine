using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace findly.TestAutomation.Analytics.DiscoveryUI
{
    public static class DiscoveryPortal
    {
        public static Demographics Demographics
        {
            get { return (Demographics)ScenarioContext.Current["Demographics"]; }
            set { ScenarioContext.Current.Set(value, "Demographics"); }
        }

    }
}
