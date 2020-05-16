using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class HTML_Contact_Form
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void NavigateToContactForm()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "HTML contact form";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("HTML contact form")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Fill in HTML contact form
            _driver.FindElement(By.PartialLinkText("Google Link")).Click();
            _driver.Navigate().Back();

            _driver.FindElement(By.ClassName("firstname")).SendKeys("Ruan");
            _driver.FindElement(By.Id("lname")).SendKeys("Smit");
            _driver.FindElement(By.Name("country")).SendKeys("South Africa");
            _driver.FindElement(By.Id("subject")).SendKeys("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
            _driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            Assert.AreEqual("Oops! That page can’t be found.", _driver.FindElement(By.ClassName("page-title")).Text);
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
