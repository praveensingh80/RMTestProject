using RMAutoFramework.Base;
using RMAutoFramework.Helpers;
using RMTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RMTest.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public LoginSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"I enter EmailAddress and Password to login form")]
        public void GivenIEnterEmailAddressAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _parallelConfig.CurrentPage.As<SignInPage>().SignIn(data.EmailAddress, data.Password);
        }

        [Then(@"I should see the profile page with emailaddress as label")]
        public void ThenIShouldSeeTheProfilePageWithEmailaddressAsLabel()
        {
            if (_parallelConfig.CurrentPage.As<UserProfilePage>().GetLoggedInUser().Contains("praveen.singh80@yahoo.com"))
                LogHelpers.Write("Successfull login of user");
            else
                LogHelpers.Write("Unsuccessfull login of user");
        }


    }
}
