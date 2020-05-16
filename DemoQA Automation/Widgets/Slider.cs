using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;

namespace DemoQA_Automation
{
    [TestClass]
    public class Slider
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void SliderPage()
        {
            //Navigate to correct page
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Slider";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Slider")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Slider initial value
            string value = _driver.FindElement(By.XPath("//*[@id='slider']/span")).GetCssValue("left");
            Assert.AreEqual("0px", value);

            //Slider move
            Actions actions = new Actions(_driver);
            IWebElement SliderButton = _driver.FindElement(By.XPath("//*[@id='slider']/span"));
            actions.ClickAndHold(SliderButton)
                .MoveByOffset(400, 0)
                .Release().Perform();

            //Check sliders new value
            value = _driver.FindElement(By.XPath("//*[@id='slider']/span")).GetCssValue("left");
            Assert.AreEqual("400.172px", value);

        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
