using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Selectmenu
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void SelectmenuPage()
        {
            //Navigate to correct page
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Selectmenu";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Selectmenu")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            _driver.FindElement(By.Id("speed-button")).Click();
            _driver.FindElement(By.Id("ui-id-5")).Click();
            _driver.FindElement(By.Id("files-button")).Click();
            _driver.FindElement(By.Id("ui-id-8")).Click();
            _driver.FindElement(By.Id("number-button")).Click();
            _driver.FindElement(By.Id("ui-id-12")).Click();
            _driver.FindElement(By.Id("salutation-button")).Click();
            _driver.FindElement(By.Id("ui-id-32")).Click();
        }

        [TestCleanup]
        public void Close()
        {
            //_driver.Close();
        }
    }
}
