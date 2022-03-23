using TechTalk.SpecFlow;
using BuggyCarsDemo.Modal;
using OpenQA.Selenium.Support.Events;
using BuggyCarsDemo.Pages;
using NUnit.Framework;

namespace BuggyCarsDemo.StepDefs
{
    [Binding]
    public class RatingsSteps : BaseSteps
    {
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        private readonly RegistrationPage registrationPage;
        private readonly ModelPage modelPage;
        public RatingsSteps(ContextObject context) : base(context)
        {
            Context.Users = JasonHandler.DeserializeJasonArray<UserProfile>(context.TestDataPath);
            var eventDriver = new EventFiringWebDriver(context.Driver);
            loginPage = new LoginPage(eventDriver);
            homePage = new HomePage(eventDriver);
            registrationPage = new RegistrationPage(eventDriver);
            modelPage = new ModelPage(eventDriver);
        }

        [Given(@"User is registered and logged in")]
        public void GivenUserIsRegisteredAndLoggedIn()
        {
            BrowserSupport.InitDriver(Context.Driver, Context.BaseUrl + "register");
            var newUsername = registrationPage.ReigsterNewUser("Test","FirstName","LastName", "Password@123") ;
            loginPage.EnterLoginCredentials(newUsername, "Password@123");
            loginPage.Login();

        }
        
        [When(@"User navigates to most popular modal")]
        public void WhenUserNavigatesToMostPopularModal()
        {
            homePage.NavigateToHome();
            homePage.NavigateToPopularModel();
        }
        
        [When(@"User adds a comment")]
        public void WhenUserAddsAComment()
        {
            modelPage.AddComments("New Vote added");
        }
        
        [Then(@"User should see the increased vote count")]
        public void ThenUserShouldSeeTheIncreasedVoteCount()
        {
            Assert.IsTrue(modelPage.VerifyVoteIsCounted());
        }
        
        [Then(@"User cannot make more comments")]
        public void ThenUserCannotMakeMoreComments()
        {
            Assert.IsTrue(modelPage.VerifyResponseMessage());
        }
    }
}
