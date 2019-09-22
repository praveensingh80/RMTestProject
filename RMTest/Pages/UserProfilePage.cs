using OpenQA.Selenium;
using RMAutoFramework.Base;
using RMAutoFramework.Extensions;
using TechTalk.SpecFlow;

namespace RMTest.Pages
{
    public class UserProfilePage : BasePage
    {
        public UserProfilePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        private IWebElement lblUserEmail => parallelConfig.Driver.FindElement(By.Id("lbl-email"));

        internal string GetLoggedInUser()
        {
            return lblUserEmail.GetElementText();
        }
    }
}
