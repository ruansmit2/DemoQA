using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Datepicker
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void DatepickerPage()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Datepicker";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Datepicker")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Datepicker compare todays date
            int dateTime = DateTime.UtcNow.Day;
            
            _driver.FindElement(By.Id("datepicker")).Click();
            _driver.FindElement(By.ClassName("ui-datepicker-calendar")).Click();

            IWebElement datepickerToday = _driver.FindElement(By.XPath("//*[@class='ui-state-default ui-state-highlight']"));
            string val = datepickerToday.GetAttribute("innerText");
            Assert.AreEqual(dateTime.ToString("d"), val);

            //Pick date and assert value
            _driver.FindElement(By.Id("datepicker")).Clear();
            _driver.FindElement(By.Id("datepicker")).SendKeys("05/01/2020");

            IWebElement datepicker = _driver.FindElement(By.XPath("//*[@class='ui-state-default ui-state-active']"));
            string pickedVal = datepicker.GetAttribute("innerText");
            Assert.AreEqual("1", pickedVal);

        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
