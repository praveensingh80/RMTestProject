using System.Configuration;

namespace RMAutoFramework.Config
{
    public class RMTestConfiguration : ConfigurationSection
    {
        private static RMTestConfiguration _testConfig = (RMTestConfiguration)ConfigurationManager.GetSection("RMTestConfiguration");

        public static RMTestConfiguration Settings { get { return _testConfig; } }

        [ConfigurationProperty("testSettings")]
        public RMFrameworkElementCollection TestSettings { get { return (RMFrameworkElementCollection)base["testSettings"]; } }


    }
}
