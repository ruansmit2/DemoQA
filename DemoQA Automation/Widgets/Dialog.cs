using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Dialog
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void DialogPage()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Dialog";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Dialog")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Interact with dialog
            string dialogText =_driver.FindElement(By.Id("ui-id-1")).Text;
            Assert.AreEqual("Basic dialog", dialogText);

            string beforeValue = _driver.FindElement(By.XPath("/html/body/div[6]")).GetCssValue("display");
            Assert.AreEqual("block", beforeValue);

            _driver.FindElement(By.XPath("/html/body/div[6]/div[1]/button/span[1]")).Click();

            string afterValue = _driver.FindElement(By.XPath("/html/body/div[6]")).GetCssValue("display");
            Assert.AreEqual("none", afterValue);

        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
