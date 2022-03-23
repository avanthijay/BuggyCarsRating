using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BuggyCarsDemo.Modal
{
    public class ContextObject
    {
        public IWebDriver Driver {get; set;}
        public string Browser { get; set; }

        public string BaseUrl { get; set; }

        public string TestResultPath { get; set; }

        public string TestDataPath { get; set; }

        public UserProfile CurrentUser { get; set; }

        public List<UserProfile> Users { get; set; }
    }
}
