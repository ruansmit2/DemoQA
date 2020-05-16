using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Checkboxradio
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void CheckboxradioPage()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Checkboxradio";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Checkboxradio")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Radio Button
            _driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/fieldset[1]/label[2]")).Click();

            //Checkbox
            _driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/fieldset[2]/label[4]/span[1]")).Click();

            _driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/fieldset[3]/label[3]")).Click();
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
