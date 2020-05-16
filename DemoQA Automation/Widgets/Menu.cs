using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Menu
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void MenuPage()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Menu";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Menu")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Navigate menu
            Actions actions = new Actions(_driver);
            IWebElement MenuItem1 = _driver.FindElement(By.Id("ui-id-9"));
            actions.MoveToElement(MenuItem1).Perform();

            IWebElement MenuItem2 = _driver.FindElement(By.Id("ui-id-13"));
            actions.MoveToElement(MenuItem2).Perform();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ui-id-14")));

            string menueItem3 = _driver.FindElement(By.Id("ui-id-14")).Text;
            Assert.AreEqual("Freejazz",menueItem3);
            
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
