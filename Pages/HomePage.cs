using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BuggyCarsDemo.Pages
{
    public class HomePage : BasePage
    {
        private readonly By UserName = By.XPath("//span[contains(text(),'Hi')]");
        private readonly By ProfileLink = By.LinkText("Profile");
        private readonly By LogoutLink = By.LinkText("Logout");
        private readonly By PopularModelLink = By.XPath("//a[contains(@href,'/model/')]");
        private readonly By HomeLink = By.CssSelector("header > nav > div > a");
        private readonly By MyHomeArea = By.XPath("//my-home");
        public HomePage(IWebDriver driver) : base(driver)
        { }

        public bool VerifyUserLoggedIn(string expectedMessage)
        {
            var result = FindElement(UserName).Text.Contains(expectedMessage) ? true : false;
            return result;
        }

        public void UserLogout()
        {
            ClickElement(LogoutLink);
        }

        public void NavigateToProfile()
        {
            ClickElement(ProfileLink);
        }

        public void NavigateToPopularModel()
        {
            ClickElement(PopularModelLink);
        }

        public void NavigateToHome()
        {
            ClickElement(HomeLink);
        }

        public bool VerifyHomePage()
        {
            var result = FindElement(MyHomeArea).Displayed ? true : false;
            return result;
        }

    }
}
