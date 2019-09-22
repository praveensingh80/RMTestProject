using RMAutoFramework.Base;
using RMAutoFramework.Config;
using RMAutoFramework.Helpers;
using RMTest.Pages;
using Should.Core.Assertions;
using System;
using TechTalk.SpecFlow;

namespace RMTest.Steps
{
    [Binding]
    public class ExtendedSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateSite();
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            _parallelConfig.CurrentPage.As<HomePage>().CheckIfSigninOrSignupExist();
        }

        [Given(@"I click (.*) link")]
        public void GivenIClickLink(string linkName)
        {
            if (linkName == "SigIn or SignUp")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickSigninOrSignup();
            else if (linkName == "Register Account")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<SignInPage>().ClickRegisterAccountLink();
            else
                throw new Exception("Link not defined!");
        }


        [When(@"I click (.*) button")]
        public void WhenIClickButton(string buttonName)
        {
            if (buttonName == "Sign In")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<SignInPage>().ClickSignInButton();
            else if (buttonName == "Sign Up")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<SignUpPage>().ClickSignUpButton();
            else
                throw new Exception("Button not defined!");
        }

        [Then(@"I should see the (.*) page error as (.*)")]
        public void ThenIShouldSeeThePageError(string page, string errorMsg)
        {
            string actualMsg = null;
            if (page == "Sign In")
            {
                _parallelConfig.CurrentPage = new SignInPage(_parallelConfig);
                actualMsg = _parallelConfig.CurrentPage.As<SignInPage>().GetValidationError();
            }
            else if (page == "Sign Up")
            {
                _parallelConfig.CurrentPage = new SignUpPage(_parallelConfig);
                actualMsg = _parallelConfig.CurrentPage.As<SignUpPage>().GetValidationError();
            }
            else
            {
                LogHelpers.Write("Incorrect page!");
                throw new Exception(page+" page not defined!");
            }
            Assert.True(actualMsg == errorMsg, "Expected error msg doesn't match actual msg: " + actualMsg);
            LogHelpers.Write("Correct validation message displayed!");
        }


        public void NavigateSite()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the application");
        }
    }
}
