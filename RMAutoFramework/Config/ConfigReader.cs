using RMAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace RMAutoFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings(string testSetting)
        {
            Settings.AUT = RMTestConfiguration.Settings.TestSettings[testSetting].AUT;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), RMTestConfiguration.Settings.TestSettings[testSetting].Browser);
            Settings.TestType = RMTestConfiguration.Settings.TestSettings[testSetting].TestType;
            Settings.IsLog = RMTestConfiguration.Settings.TestSettings[testSetting].IsLog;
            Settings.LogPath = RMTestConfiguration.Settings.TestSettings[testSetting].LogPath;
        }
    }
}
