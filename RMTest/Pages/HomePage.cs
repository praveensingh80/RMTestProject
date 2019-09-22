using OpenQA.Selenium;
using RMAutoFramework.Base;
using RMAutoFramework.Extensions;
using TechTalk.SpecFlow;

namespace RMTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        private IWebElement lnkSigninOrSignup => parallelConfig.Driver.FindElement(By.LinkText("Sign In or Sign Up"));

        public SignInPage ClickSigninOrSignup()
        {
            lnkSigninOrSignup.Click();
            return new SignInPage(parallelConfig);
        }

        public void CheckIfSigninOrSignupExist()
        {
            lnkSigninOrSignup.AssertElementPresent();
        }
    }
}
