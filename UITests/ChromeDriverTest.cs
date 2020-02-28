using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace UITests
{
    [TestClass]
    public class ChromeDriverTest
    {        
        private RemoteWebDriver _driver;

        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            // Initialize driver 
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            options.AddArguments("headless");
            
            _driver = new RemoteWebDriver(new Uri("http://seleniumchromedriver:4444/wd/hub"), options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {            
            _driver.Url = "https://www.google.com";
            Assert.AreEqual("Google", _driver.Title);
        }

        [TestCleanup]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
