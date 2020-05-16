using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace DemoQA_Automation
{
    [TestClass]
    public class Spinner
    {
        IWebDriver _driver = new ChromeDriver();
         
        [TestMethod]
        public void Spinner_Page()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Spinner";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Spinner")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Click on enabled/Disabled button
            IWebElement spinnerTextbox = _driver.FindElement(By.Id("spinner"));
            string spinnerTextboxClassName = spinnerTextbox.GetAttribute("class");
            bool isEnabled = _driver.FindElement(By.Id("spinner")).Enabled;
            _driver.FindElement(By.Id("disable")).Click();
            isEnabled = _driver.FindElement(By.Id("spinner")).Enabled;

            bool isDisplayedUp = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/p[1]/span/a[1]")).Displayed;
            bool isDisplayedDown = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/p[1]/span/a[2]")).Displayed;

            _driver.FindElement(By.Id("destroy")).Click();

            spinnerTextboxClassName = spinnerTextbox.GetAttribute("class");
            Assert.AreEqual("",spinnerTextboxClassName);

            //Alert with text entered
            _driver.FindElement(By.Id("destroy")).Click();
            _driver.FindElement(By.Id("spinner")).SendKeys("9");
            _driver.FindElement(By.Id("getvalue")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IAlert okAlert = _driver.SwitchTo().Alert();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("9",okAlert.Text);
            okAlert.Dismiss();

            //Set Value from textbox
            _driver.FindElement(By.Id("setvalue")).Click();
            IWebElement spinnerTextboxValue = _driver.FindElement(By.Id("spinner"));
            string TextboxValue = spinnerTextbox.GetAttribute("value");
            Assert.AreEqual("5", TextboxValue);

        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
