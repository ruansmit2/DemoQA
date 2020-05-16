using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Iframe
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void IframePage()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "IFrame practice page";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("IFrame practice page")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Switch to iframe
            _driver.SwitchTo().Frame(0);
            _driver.FindElement(By.LinkText("Skip to content")).Click();
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
