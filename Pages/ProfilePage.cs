using OpenQA.Selenium;

namespace BuggyCarsDemo.Pages
{
    public class ProfilePage : BasePage
    {
        private readonly By FirstNameInput = By.Id("firstName");
        private readonly By LastNameInput = By.Id("lastName");
        private readonly By GenderInput = By.Id("gender");
        private readonly By AgeInput = By.Id("age");
        private readonly By AddressInput = By.Id("address");
        private readonly By PhoneInput = By.Id("phone");
        private readonly By HpbbyDropDown = By.Id("hobby");
        private readonly By CurrentPasswordInput = By.Id("currentPassword");
        private readonly By NewPasswordInput = By.Id("newPassword");
        private readonly By ConfirmPasswordInput = By.Id("newPasswordConfirmation");
        private readonly By SaveButton = By.XPath("//button[@type='submit'][text()='Save']");
        private readonly By ResponseMessage = By.CssSelector("my-profile > div > form > div.row.hidden-lg-up > div");

        public ProfilePage(IWebDriver driver) : base(driver)
        {

        }

        public void UpdateFirstname(string firstName)
        {
            SendKeys(FirstNameInput, firstName);
        }

        public void UpdatePassword(string currentPassword, string newPassword)
        {
            SendKeys(CurrentPasswordInput, currentPassword);
            SendKeys(NewPasswordInput, newPassword);
            SendKeys(ConfirmPasswordInput, newPassword);
        }

        public void SaveUpdatedProfile()
        {
            ClickElement(SaveButton);
        }

        public bool VerifySavedFirstName(string firstName)
        {
            var result = FindElement(FirstNameInput).Text == firstName ? true : false;
            return result;
        }

        public bool VerifyProfileDataSaved()
        {
            var result = FindElement(ResponseMessage).Text == "The profile has been saved successful" ? true : false;
            return result;
        }
    }
}
