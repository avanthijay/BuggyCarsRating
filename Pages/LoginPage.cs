using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BuggyCarsDemo.Pages
{
    public class LoginPage : BasePage
    {

        private readonly By Form = By.ClassName("form-inline");
        private readonly By LoginInput = By.Name("login");
        private readonly By PasswordInput = By.Name("password");
        private readonly By LoginButton = By.XPath("//button[@type='submit'][text()='Login']");
        private readonly By errorMessage = By.XPath("//span[contains(text(), 'Invalid username/password')]");
        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public void EnterLoginCredentials(string username, string password)
        {
            SendKeys(LoginInput, username);
            SendKeys(PasswordInput,password);
            ClickElement(LoginButton);
        }

        public void Login()
        {
            ClickElement(LoginButton);
        }

        public bool VerifyLoginResult(string expectedMessage)
        {
            var result = FindElement(errorMessage).Text == expectedMessage ? true : false;
            return result;

        }

        public bool VerifyLoginPage()
        {
            var result = FindElement(LoginButton).Displayed ? true : false;
            return result;
        }
    }
}
