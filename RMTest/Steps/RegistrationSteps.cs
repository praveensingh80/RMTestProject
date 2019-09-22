using RMAutoFramework.Base;
using RMTest.Pages;
using Should.Core.Assertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RMTest.Steps
{
    [Binding]
    public class RegistrationSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public RegistrationSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"I enter EmailAddress and Password to registration form")]
        public void GivenIEnterEmailAddressAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _parallelConfig.CurrentPage.As<SignUpPage>().SignUp(data.EmailAddress, data.Password);
        }

        [Then(@"I should see the complete registration info page")]
        public void ThenIShouldSeeTheCompleteRegistrationInfoPage()
        {
            string expected = "We have sent you an email with an activation link, please check it to complete the registration.";
            Assert.True(expected == _parallelConfig.CurrentPage.As<CompleteRegistrationPage>().GetConfirmationMsg(), "");
        }
    }
}
