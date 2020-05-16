using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA_Automation
{
    [TestClass]
    public class Browse
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void NavigateToURL()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
