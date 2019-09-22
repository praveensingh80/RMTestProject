using OpenQA.Selenium;
using RMAutoFramework.Base;
using RMAutoFramework.Extensions;
using System;

namespace RMTest.Pages
{
    public class CompleteRegistrationPage : BasePage
    {
        public CompleteRegistrationPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        private IWebElement lblCompleteRegistrationInfo => parallelConfig.Driver.FindElement(By.ClassName("confirmation"));

        public string GetConfirmationMsg()
        {
            return lblCompleteRegistrationInfo.GetElementText();
        }

    }
}
