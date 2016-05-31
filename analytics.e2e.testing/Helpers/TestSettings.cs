using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Findly.FunctionalAutomation.Settings;

namespace findly.TestAutomation.Analytics.Helpers
{
    public static class TestSettings
    {
        private static ISettingsProvider Settings { get; set; }
        public static string WaggleUserName
        {
            get { return Settings["Waggle.User.Name"]; }
        }

        public static string WagglePassword
        {
            get { return Settings["Waggle.User.Password"]; }
        }

        public static string WaggleUrl
        {
            get { return Settings["Waggle.Url"]; }
        }

        public static string ScreenShotDirectory
        {
            get { return Settings["ScreenShotDirectory"]; }
        }

        public static ImageFormat ScreenShotImageFormat
        {
            get { return ImageFormat.Jpeg; }
        }

        public static string Environment
        {
            get { return Settings["ENV"].TrimEnd('-'); }
        }
    }
}
