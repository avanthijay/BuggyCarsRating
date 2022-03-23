using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Diagnostics;

namespace BuggyCarsDemo.Modal
{
    public class BrowserSupport
    {

        public static IWebDriver InitDriver(IWebDriver driver, string url)
        {
            if (url != null)
            {
                driver.Navigate().GoToUrl(url);
                driver.SwitchTo().DefaultContent();
            }

            if (driver == null) driver.Manage().Window.Maximize();
            return driver;

        }

        public static void CleanUp(IWebDriver driver, string browser)
        {
            try
            {
                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TakeScreenShot(string resultPath, IWebDriver driver, string testId)
        {
            try
            {
                string fileName = string.Format($"{testId}_{DateTime.Now.ToString("hhmmssff")}.png");
                CreateScreenshot(resultPath + "//" + fileName, driver);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateScreenshot(string file, IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(file, ScreenshotImageFormat.Png);
        }
    }
}
