using TechTalk.SpecFlow;
using BuggyCarsDemo.Modal;
using BuggyCarsDemo.Pages;
using OpenQA.Selenium.Support.Events;
using NUnit.Framework;

namespace BuggyCarsDemo.StepDefs
{
    [Binding]
    public class RegistrationSteps: BaseSteps
    {
        private readonly RegistrationPage registrationPage;
        public RegistrationSteps(ContextObject context) : base(context)
        {
            var eventDriver = new EventFiringWebDriver(context.Driver);
            registrationPage = new RegistrationPage(eventDriver);
        }

        [Given(@"User is on Registration page")]
        public void GivenUserIsOnRegistrationPage()
        {
            BrowserSupport.InitDriver(Context.Driver, Context.BaseUrl+ "register");
        }
        
        [When(@"User enters  ""(.*)"", First Name ""(.*)"", Last Name ""(.*)"", Password ""(.*)""")]
        public void WhenUserEntersFirstNameLastNamePassword(string username, string firstName, string lastName, string password)
        {
            registrationPage.EnterRegistrationDetails(username,firstName,lastName,password);
        }

        [When(@"User enters existing data for ""(.*)"", First Name ""(.*)"", Last Name ""(.*)"", Password ""(.*)""")]
        public void WhenUserEntersExistingDataForFirstNameLastNamePasswordstring (string username, string firstName, string lastName, string password)
        {
            registrationPage.EnterExistingRegistrationDetails(username, firstName, lastName, password);
        }


        [Then(@"User should be able to see the message ""(.*)""")]
        public void ThenUserShouldBeAbleToSeeTheMessage(string expectedMessage)
        {
            Assert.IsTrue(registrationPage.VerifyRegistrationResult(expectedMessage));
        }


    }
}
