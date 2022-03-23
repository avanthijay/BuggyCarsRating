using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BuggyCarsDemo.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

      
        /// <summary>
        /// FInd element by locator
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected IWebElement FindElement(By locator)
        {
            IWebElement element = null;

            Execute(() =>
            {
                var elements = driver.FindElements(locator);
                if (elements.Count == 0) return false;
                element = elements[0];
                return element.Displayed && element.Enabled;
            });
            return element;
        }

        /// <summary>
        /// Send data into Input fields 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="inputData"></param>
        protected void SendKeys(By locator, string inputData)
        {
            if (inputData != null)
            {
                var element = FindElement(locator);
                element.Clear();
                element.SendKeys(inputData);
            }
        }

        /// <summary>
        /// Cleck on element
        /// </summary>
        /// <param name="locator"></param>
        protected void ClickElement(By locator)
        {
            Execute(() =>
            {
                var elements = driver.FindElements(locator);
                if (elements.Count == 0) return false;

                var element = elements[0];
                if (element.Enabled && element.Displayed)
                {
                    element.Click();
                    return true;
                }
                return false;
            });
        }

        /// <summary>
        /// Wait until element is visible before action
        /// </summary>
        /// <param name="locator"></param>
        protected void WaitUntilElementIsVisible(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }


        /// <summary>
        /// Execute function
        /// </summary>
        /// <param name="function"></param>
        /// <param name="retryInterval"></param>
        /// <param name="retryCount"></param>
        /// <param name="exceptionMessage"></param>
        public static void Execute(Func<bool> function, int retryInterval = 500, int retryCount = 20, string exceptionMessage = null)
        {
            int count = 0;
            Exception exception = null;
            object by = null;
            object target = function.Target;
            if (target != null)
            {
                foreach (var field in target.GetType().GetFields())
                {
                    if (field.Name.Trim().ToLower().Equals("locator")) by = field.GetValue(target);
                }
            }

            do
            {
                try
                {
                    if (function()) return;

                    Thread.Sleep(retryInterval);
                    count++;
                }
                catch (Exception ex)
                {
                    exception = ex;
                    Thread.Sleep(retryInterval);
                    count++;
                }
            }
            while (count != retryCount);

            if (exception != null) exceptionMessage = exception.Message;
            exceptionMessage = exceptionMessage ?? $"Retry timed out while trying to execute method - {function.Method.Name}. Unable to locate element: {by}";
            throw new Exception(exceptionMessage, exception);
        }

        /// <summary>
        /// Generate random numbers
        /// </summary>
        /// <returns></returns>
        public string GetRandomNumber()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 999);
            return value.ToString();
        }

    }
}
