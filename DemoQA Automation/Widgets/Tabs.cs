using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Tabs
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void Tab()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Tabs";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Tabs")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Tabs
            _driver.FindElement(By.Id("ui-id-1")).Click();
            string tab1Text = _driver.FindElement(By.XPath("//*[@id='tabs-1']/p")).Text;

            string ext = tab1Text.Substring(0, 5);

            Assert.AreEqual("Proin", ext);

            //Tabs
            _driver.FindElement(By.Id("ui-id-2")).Click();
            string tab2Text = _driver.FindElement(By.XPath("//*[@id='tabs-2']/p")).Text;

            ext = tab2Text.Substring(0, 5);

            Assert.AreEqual("Morbi", ext);

            //Tabs
            _driver.FindElement(By.Id("ui-id-3")).Click();
            string tab3Text = _driver.FindElement(By.XPath("//*[@id='tabs-3']/p")).Text;

            ext = tab3Text.Substring(0, 6);

            Assert.AreEqual("Mauris", ext);

        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
