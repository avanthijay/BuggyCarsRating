using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BuggyCarsDemo.Pages
{
    public class ModelPage : BasePage
    {
        private readonly By CommentField = By.Id("comment");
        private readonly By VoteCount = By.CssSelector("div:nth-child(1) > h4 > strong");
        private readonly By VoteButton = By.XPath("//button[@class='btn btn-success'][text()='Vote!']");
        private readonly By ModelName = By.CssSelector("div:nth-child(2) > h3");
        private readonly By VoteSuccessMessage = By.XPath("//p[@class='card-text']");
        private int voteCountNumber;

        public ModelPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void AddComments(string voteComment)
        {
            voteCountNumber = Int32.Parse(FindElement(VoteCount).Text);
            SendKeys(CommentField, voteComment);
            ClickElement(VoteButton);
        }

        public bool VerifyVoteIsCounted()
        {
            WaitUntilElementIsVisible(VoteSuccessMessage);
            var expectedVoteCount = voteCountNumber + 1;
            var result = Int32.Parse(FindElement(VoteCount).Text) == expectedVoteCount ? true : false;
            return result;

        }

        public bool? VerifyResponseMessage()
        {
            WaitUntilElementIsVisible(VoteSuccessMessage);
            var result = FindElement(VoteSuccessMessage).Text == "Thank you for your vote!" ? true : false;
            return result;
        }
    }
}
