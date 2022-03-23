using BuggyCarsDemo.Modal;
using BuggyCarsDemo.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.Events;
using TechTalk.SpecFlow;

namespace BuggyCarsDemo.StepDefs
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homepage;
        public LoginSteps(ContextObject context) : base(context)
        {
            Context.Users = JasonHandler.DeserializeJasonArray<UserProfile>(context.TestDataPath);
            var eventDriver = new EventFiringWebDriver(context.Driver);
            loginPage = new LoginPage(eventDriver);
            homepage = new HomePage(eventDriver);
        }
        [Given(@"User is on Login page")]
        public void GivenUserIsOnLoginPage()
        {
            BrowserSupport.InitDriver(Context.Driver, Context.BaseUrl);
        }

        [Given(@"User is logged in as ""(.*)""")]
        [When(@"User enter credentials for a ""(.*)""")]
        public void GivenUserEnterValidUsernameAndPassword(string alias)
        {
            Context.CurrentUser = Context.Users.Find(x => x.Alias.Equals(alias));
            loginPage.EnterLoginCredentials(Context.CurrentUser.Username,Context.CurrentUser.Password);
        }
        
        [Given(@"User enter invalid username ""(.*)"" and password ""(.*)""")]
        public void GivenUserEnterInvalidUsernameAndPassword(string username, string password)
        {
            loginPage.EnterLoginCredentials(username, password);
        }
        
      
        [Then(@"User should be logged in")]
        public void ThenUserShouldBeLoggedIn()
        {
            Assert.IsTrue(homepage.VerifyUserLoggedIn(Context.CurrentUser.FirstName));
        }


        [Then(@"User should see the ""(.*)"" message")]
        public void ThenUserShouldSeeTheMessage(string errorMssage)
        {
           loginPage.VerifyLoginResult(errorMssage);
        }

        [When(@"User is logged out")]
        [When(@"User clicks the logut link")]
        public void WhenUserClicksTheLogutLink()
        {
            homepage.UserLogout();
        }

        [Then(@"User shluld be logged out")]
        public void ThenUserShluldBeLoggedOut()
        {
           Assert.IsTrue( loginPage.VerifyLoginPage());
        }

        [Given(@"User is logged in as a ""(.*)"" user")]
        public void GivenUserIsLoggedInAsAUser(string alias)
        {
            BrowserSupport.InitDriver(Context.Driver, Context.BaseUrl);
            Context.CurrentUser = Context.Users.Find(x => x.Alias.Equals(alias));
            loginPage.EnterLoginCredentials(Context.CurrentUser.Username, Context.CurrentUser.Password);

        }

    }
}
