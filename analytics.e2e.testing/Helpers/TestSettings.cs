using System.Drawing.Imaging;
using Findly.FunctionalAutomation.Settings;

namespace findly.TestAutomation.Analytics.Helpers
{
    public static class TestSettings
    {
        private static ISettingsProvider Settings { get; set; }

        static TestSettings ()
        {
            // Half-way house - once DI is set up, we should inject the entire TestSettings object
            Settings = new AppSettingsProvider();
        }

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
