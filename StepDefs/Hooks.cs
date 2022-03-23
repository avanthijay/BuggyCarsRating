using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using BoDi;
using BuggyCarsDemo.Modal;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace BuggyCarsDemo.StepDefs
{
    public class Hooks : BaseSteps
    {
        private ScenarioContext scenarioContext;
        private IObjectContainer _container;
        private DateTime lastStepStart;
        public Hooks(ContextObject context, IObjectContainer container) : base(context)
        {
            _container = container;
            scenarioContext = _container.Resolve<ScenarioContext>();
        }

        [BeforeStep]
        public void BeforeStepSaveStartTime()
        {
            lastStepStart = DateTime.Now;
        }

        [AfterStep]
        public void AfterStepOutput()
        {
            var stepContext = scenarioContext.StepContext;
            var currentStepText = $"{stepContext.StepInfo.StepDefinitionType}{stepContext.StepInfo.Text}";
            Console.WriteLine(currentStepText);

            var stepTable = stepContext.StepInfo.Table;
            
        }

        [BeforeScenario]
        public void SetUp()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var browser = config.GetRequiredSection("Browser").Value;
            var baseUrl = config.GetRequiredSection("BaseUrl").Value;
            var testResultPath = config.GetRequiredSection("TestResultPath").Value;
            Context.BaseUrl = baseUrl.ToString();
            Context.Browser =browser.ToString();
            Context.TestDataPath = @"TestData\TestData.json";
            Context.TestResultPath = testResultPath.ToString();

            if (Context.Browser == "Chrome") 
            { 
                ChromeOptions options = new ChromeOptions();
                options.SetLoggingPreference(LogType.Browser, LogLevel.All);

                Context.Driver = new ChromeDriver(options);
            }
            else if (Context.Browser == "Firefox")
            {
                Context.Driver = new FirefoxDriver();
            }
            
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (scenarioContext.TestError != null)
            {
                BrowserSupport.TakeScreenShot(Context.TestResultPath, Context.Driver, TestContext.CurrentContext.Test.ID) ;
            }

            BrowserSupport.CleanUp(Context.Driver, Context.Browser);
        }

    }
}
