using BuggyCarsDemo.Modal;
using BuggyCarsDemo.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.Events;
using TechTalk.SpecFlow;


namespace BuggyCarsDemo.StepDefs
{
    [Binding]
    public class ProfileSteps : BaseSteps
    {

        private readonly ProfilePage profile;
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        public ProfileSteps(ContextObject context) : base(context)
        {
            Context.Users = JasonHandler.DeserializeJasonArray<UserProfile>(context.TestDataPath);
            var eventDriver = new EventFiringWebDriver(context.Driver);
            profile = new ProfilePage(eventDriver);
            homePage = new HomePage(eventDriver);
            loginPage = new LoginPage(eventDriver);
        }
        [When(@"User update profile details")]
        public void WhenUserUpdateProfileDetails()
        {
            homePage.NavigateToProfile();
            profile.UpdatePassword(Context.CurrentUser.Password, "Password@222");
            profile.SaveUpdatedProfile();
            profile.VerifyProfileDataSaved();
        }
        
        [Then(@"User is logged in with new password")]
        public void ThenUserIsLoggedInWithNewPassword()
        {
            loginPage.EnterLoginCredentials(Context.CurrentUser.Username,"Password@222") ;
        }
        
        //[Then(@"User should see updated profile data is saved")]
        //public void ThenUserShouldSeeUpdatedProfileDataIsSaved()
        //{
        //   Assert.IsTrue( profile.VerifySavedFirstName("Test"));
        //}

        [Then(@"User change the password back to original password")]
        public void ThenUserChangeThePasswordBackToOriginalPassword()
        {
            homePage.NavigateToProfile();
            profile.UpdatePassword("Password@222", Context.CurrentUser.Password);
            profile.SaveUpdatedProfile();
            profile.VerifyProfileDataSaved();
        }

        [When(@"User updates profile ""(.*)"" as ""(.*)"" and save")]
        public void WhenUserUpdatesProfileAsAndSave(string key, string value)
        {
            switch (key)
            {
                case ("firstName"):
                    profile.UpdateFirstname(value);
                    break;
                case ("lastName"):
                   // profile.UpdateLastName(value);
                    break;
                case ("age"):
                    // profile.UpdateAge(value);
                    break;
                default:
                    break;
            }
            profile.SaveUpdatedProfile();
        }

        [Then(@"User should see the update successfull message")]
        public void ThenUserShouldSeeTheUpdateSuccessfullMessage()
        {
            Assert.IsTrue(profile.VerifyProfileDataSaved());
        }

        [Given(@"User is on Profile Page")]
        public void GivenUserIsOnProfilePage()
        {
            homePage.NavigateToProfile();
        }


    }
}
