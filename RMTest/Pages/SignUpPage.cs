using OpenQA.Selenium;
using RMAutoFramework.Base;
using RMAutoFramework.Extensions;
using System;

namespace RMTest.Pages
{
    public class SignUpPage : BasePage
    {
        public SignUpPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        private IWebElement btnSignUp => parallelConfig.Driver.FindElement(By.CssSelector("input.btn[value='Sign Up']"));

        private IWebElement txtEmailAddress => parallelConfig.Driver.FindElement(By.Name("email"));

        private IWebElement txtPassword => parallelConfig.Driver.FindElement(By.Name("passwordencrypted"));

        private IWebElement registrationErrorMsg => parallelConfig.Driver.FindElement(By.Id("registererror"));

        public string GetValidationError()
        {
            return registrationErrorMsg.GetElementText();
        }

        public void SignUp(string emailAddress, string password)
        {
            txtEmailAddress.SendKeys(emailAddress);
            txtPassword.SendKeys(password);
        }

        public CompleteRegistrationPage ClickSignUpButton()
        {
            btnSignUp.Click();
            return new CompleteRegistrationPage(parallelConfig);
        }
    }
}
