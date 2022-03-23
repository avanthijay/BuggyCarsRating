using OpenQA.Selenium;

namespace BuggyCarsDemo.Pages
{
    public class RegistrationPage : BasePage
    {
        private readonly By UsernameInput = By.Id("username");
        private readonly By FirstNameInput = By.Id("firstName");
        private readonly By LastNameInput = By.Id("lastName");
        private readonly By PasswordInput = By.Id("password");
        private readonly By ConfirmPasswordInput = By.Id("confirmPassword");
        private readonly By RegisterButton = By.XPath("//button[@type='submit'][text()='Register']");
        private readonly By ResultMessage = By.ClassName("result");
        private string newUsername;


        public RegistrationPage(IWebDriver driver) : base(driver)
        { 
        }


        public void EnterRegistrationDetails(string username, string firstName, string lastName, string password)
        {
            newUsername = username + GetRandomNumber();
            SendKeys(UsernameInput,newUsername);
            RegisterUser(firstName, lastName, password);
        }

        public void EnterExistingRegistrationDetails(string username, string firstName, string lastName, string password)
        {
            SendKeys(UsernameInput, username);
            RegisterUser(firstName, lastName, password);
        }

 
        public bool VerifyRegistrationResult(string expectedMessage)
        {
            var result = FindElement(ResultMessage).Text == expectedMessage ?  true :  false;
            return result;            
        }

        public string ReigsterNewUser(string username, string firstName, string lastName, string password)
        {
            newUsername = username + GetRandomNumber();
            SendKeys(UsernameInput, newUsername);
            RegisterUser(firstName, lastName, password);

            return newUsername;
        }

        private void RegisterUser(string firstName, string lastName, string password)
        {
            SendKeys(FirstNameInput, firstName);
            SendKeys(LastNameInput, lastName);
            SendKeys(PasswordInput, password);
            SendKeys(ConfirmPasswordInput, password);
            ClickElement(RegisterButton);
        }


    }
}
