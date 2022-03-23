using TechTalk.SpecFlow;
using BuggyCarsDemo.Pages;
using BuggyCarsDemo.Modal;
using OpenQA.Selenium.Support.Events;

namespace BuggyCarsDemo.StepDefs
{
    [Binding]
    public class NavigationSteps : BaseSteps
    {
        private readonly ModelPage modelPage;
        private readonly HomePage homePage;
        public NavigationSteps(ContextObject context) : base(context)
        {
            Context.Users = JasonHandler.DeserializeJasonArray<UserProfile>(context.TestDataPath);
            var eventDriver = new EventFiringWebDriver(context.Driver);
            homePage = new HomePage(eventDriver);
            modelPage = new ModelPage(eventDriver);
        }
        [Given(@"User navigates to ""(.*)""")]
        public void GivenUserNavigatesTo(string newPage)
        {
            BrowserSupport.InitDriver(Context.Driver, Context.BaseUrl + newPage); 
        }
        
        [When(@"User clicks on Home link")]
        public void WhenUserClicksOnHomeLink()
        {
            homePage.NavigateToHome();
        }
        
        [Then(@"User should be back to Home Page")]
        public void ThenUserShouldBeBackToHomePage()
        {
            homePage.VerifyHomePage();
        }
    }
}
