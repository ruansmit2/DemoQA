using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace DemoQA_Automation
{
    [TestClass]
    public class Tooltip
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void Tooltips()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Tooltip";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Tooltip")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Tooltip
            Actions actions = new Actions(_driver);
            IWebElement tooltipTextBox = _driver.FindElement(By.Id("age"));

            string tooltipText = tooltipTextBox.GetAttribute("title");

            Assert.AreEqual("We ask for your age only for statistical purposes.", tooltipText);
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
