using System;
using Coypu;

namespace findly.TestAutomation.Analytics.Helpers
{
    public static class CoypuOptions
    {
        public static Options FirstMatch = new Options {Match = Match.First};

        public static Options ConsiderInvisible = new Options {ConsiderInvisibleElements = true};

        public static Options Timeout(int seconds)
        {
            return new Options {Timeout = TimeSpan.FromSeconds(seconds)};
        }
    }
}
