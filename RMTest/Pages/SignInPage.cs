using OpenQA.Selenium;
using RMAutoFramework.Base;
using RMAutoFramework.Extensions;

namespace RMTest.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        private IWebElement btnSignIn => parallelConfig.Driver.FindElement(By.CssSelector("input.btn[value='Sign In']"));

        private IWebElement txtEmailAddress => parallelConfig.Driver.FindElement(By.Name("login"));

        private IWebElement txtPassword => parallelConfig.Driver.FindElement(By.Name("password"));

        private IWebElement lnkRegisterAccount => parallelConfig.Driver.FindElement(By.LinkText("Register an account"));

        private IWebElement loginErrorMsg => parallelConfig.Driver.FindElement(By.Id("loginerror"));

        public void SignIn(string emailAddress, string password)
        {
            txtEmailAddress.SendKeys(emailAddress);
            txtPassword.SendKeys(password);
        }

        public UserProfilePage ClickSignInButton()
        {
            btnSignIn.Click();
            return new UserProfilePage(parallelConfig);
        }

        public SignUpPage ClickRegisterAccountLink()
        {
            lnkRegisterAccount.Click();
            return new SignUpPage(parallelConfig);
        }

        public string GetValidationError()
        {
            return loginErrorMsg.GetElementText();
        }

        internal void CheckIfSignInExist() => txtEmailAddress.AssertElementPresent();
    }
}
