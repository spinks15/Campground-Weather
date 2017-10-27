using Capstone.Web.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capstone.Web.Tests.SeleniumTests
{
    [TestClass]
    public class CalculatorTests
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:55601/");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void Selenium_SubmitSurvey_WithValidData_GoToResultPage()
        {
            SurveyPage entryPage = new SurveyPage(driver);
            entryPage.Navigate();

            SurveyResultPage resultPage = entryPage.FillOutForm("Cuyahoga Valley National Park", "bobRoss@gmail.com", "Ohio", "Extremely Active");

            Assert.AreEqual("Cuyahoga Valley National Park", resultPage.ParkName.Text);
            //Assert.AreEqual("6", resultPage.NumberOfVotes.Text);
            //Assert.AreEqual("bobRoss@gmail.com", resultPage.Email.Text);
            //Assert.AreEqual("Ohio", resultPage.State.Text);
            //Assert.AreEqual("ExtremlyActive", resultPage.SatisfactionScore.Text);
        }
        //[TestMethod]
        //public void Salenium_SubmitSurvey2()
        //{
        //    SurveyPage entryPage = new SurveyPage(driver);
        //    entryPage.Navigate();

        //    SurveyResultPage resultPage = entryPage.FillOutForm
        //}
    }
}
