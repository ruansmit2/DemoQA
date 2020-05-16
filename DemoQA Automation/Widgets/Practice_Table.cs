using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation
{
    [TestClass]
    public class Practice_Table
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void PracticeTable()
        {
            string actualResult;
            string ExpectedResult = "ToolsQA – Demo Website to Practice Automation – Demo Website to Practice Automation";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            actualResult = _driver.Title;

            Assert.AreEqual(actualResult, ExpectedResult);

            string expectedResult = "Automation practice table";

            //Navigate to HTML contact form
            _driver.FindElement(By.LinkText("Automation practice table")).Click();

            //Asser that correct page was selected
            Assert.AreEqual(expectedResult, _driver.FindElement(By.ClassName("entry-title")).Text);

            //Get values from Table
            string StructureName = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/th")).Text;
            string Country = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/td[1]")).Text;
            string City = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/td[2]")).Text;
            string Height = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/td[3]")).Text;
            string Built = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/td[4]")).Text;
            string Rank = _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/td[5]")).Text;

            _driver.FindElement(By.XPath("//*[@id='content']/div[2]/table/tbody/tr[1]/td[6]/a")).Click();

            Assert.AreEqual("Burj Khalifa", StructureName);
            Assert.AreEqual("UAE", Country);
            Assert.AreEqual("Dubai", City);
            Assert.AreEqual("829m", Height);
            Assert.AreEqual("2010", Built);
            Assert.AreEqual("1", Rank);
        }

        [TestCleanup]
        public void Close()
        {
            _driver.Close();
        }
    }
}
