using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace DemoQA_Automation
{
    [TestClass]
    public class Tooltip_Double_Click
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void Tooltip_and_Double_Click()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Tooltip and Double click";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Tooltip and Double click")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

           WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //Double click button
            Actions actionsDouble = new Actions(_driver);
            IWebElement doubleClickButton = _driver.FindElement(By.Id("doubleClickBtn"));
            actionsDouble.DoubleClick(doubleClickButton).Perform();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            IAlert doubleClickButtonAlert = _driver.SwitchTo().Alert();

            string AlertString = doubleClickButtonAlert.Text;
            string ext = AlertString.Substring(0, 18);

            Assert.AreEqual("Double Click Alert", ext);
            doubleClickButtonAlert.Dismiss();

            //Right click button
            Actions actionsRight = new Actions(_driver);
            IWebElement rightClickButton = _driver.FindElement(By.Id("rightClickBtn"));
            actionsRight.ContextClick(rightClickButton).Perform();

            _driver.FindElement(By.XPath("//*[@id='rightclickItem']/div[1]")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            IAlert rightClickButtonAlert = _driver.SwitchTo().Alert();

            Assert.AreEqual("You have selected Edit", rightClickButtonAlert.Text);
            rightClickButtonAlert.Dismiss();

            //Tooltip
            Actions actionsTool = new Actions(_driver);
            IWebElement tooltipLink = _driver.FindElement(By.Id("tooltipDemo"));
            actionsTool.MoveToElement(tooltipLink).Perform();

            IWebElement toolTip = _driver.FindElement(By.XPath("//*[@id='tooltipDemo']/span"));
            Assert.AreEqual("We ask for your age only for statistical purposes.", toolTip.Text);
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
