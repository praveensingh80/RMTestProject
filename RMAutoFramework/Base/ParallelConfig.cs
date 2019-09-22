using OpenQA.Selenium.Remote;

namespace RMAutoFramework.Base
{
    public class ParallelConfig
    {
        public RemoteWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }
    }
}
