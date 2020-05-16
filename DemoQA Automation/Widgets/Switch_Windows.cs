using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace DemoQA_Automation
{
    [TestClass]
    public class Switch_Windows
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void Automation_Practice_Switch_Windows()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Automation Practice Switch Windows";

            //Navigate to alert form
            _driver.FindElement(By.LinkText("Automation Practice Switch Windows")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Get Button color before
            string beforeDisplay = _driver.FindElement(By.Id("colorVar")).GetCssValue("color");
            Assert.AreEqual("rgba(0, 0, 0, 1)", beforeDisplay);

            //visible button
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("invisibility")));

            //Switch Windows by link
            _driver.FindElement(By.PartialLinkText("Demo Website for Practice Automation")).Click();
            var tab = _driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(tab)); // tab was opened
            Assert.AreEqual(_driver.SwitchTo().Window(tab).Url, "https://demoqa.com/"); // url is OK  
            _driver.SwitchTo().Window(_driver.WindowHandles[1]).Close(); // close the tab
            _driver.SwitchTo().Window(_driver.WindowHandles[0]); // get back to the main window

            //New Browser Windows
            _driver.FindElement(By.Id("button1")).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Assert.AreEqual("https://www.toolsqa.com/", _driver.Url);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]).Close(); // close the tab
            _driver.SwitchTo().Window(_driver.WindowHandles[0]); // get back to the main window

            //New tab
            _driver.FindElement(By.XPath("//*[@id='content']/div[2]/button[3]")).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Assert.AreEqual("https://www.toolsqa.com/", _driver.Url);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]).Close(); // close the tab
            _driver.SwitchTo().Window(_driver.WindowHandles[0]); // get back to the main window

            //Random ID
            Assert.AreEqual("I will have random ID", _driver.FindElement(By.TagName("p")).Text);

            //JavaScript Alert
            _driver.FindElement(By.Id("alert")).Click();
            IAlert okAlert = _driver.SwitchTo().Alert();
            okAlert.Dismiss();

            //JavaScript Timing Alert
            _driver.FindElement(By.Id("timingAlert")).Click();
           
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            IAlert timingAlert = _driver.SwitchTo().Alert();
            timingAlert.Dismiss();

            //Get Button color after
            string Afterdisplay = _driver.FindElement(By.Id("colorVar")).GetCssValue("color");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id='colorVar'][contains(@style, 'color: red')]")));
            Assert.AreEqual("rgba(255, 0, 0, 1)", Afterdisplay);

            //Change Color of button
            string doubleClickDisplayBefore = _driver.FindElement(By.Id("doubleClick")).GetCssValue("color");
            Assert.AreEqual("rgba(0, 0, 0, 1)", doubleClickDisplayBefore);

            Actions actions = new Actions(_driver);
            IWebElement doubleClick = _driver.FindElement(By.Id("doubleClick"));
            actions.DoubleClick(doubleClick).Perform();

            string doubleClickDisplayAfter = _driver.FindElement(By.Id("doubleClick")).GetCssValue("color");
            Assert.AreEqual("rgba(255, 165, 0, 1)", doubleClickDisplayAfter);
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
