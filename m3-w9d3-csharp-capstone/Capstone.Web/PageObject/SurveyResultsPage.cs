using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.PageObjects
{
    public class SurveyResultPage : BasePage
    {
        public SurveyResultPage(IWebDriver driver)
            : base(driver, "/Home/SurveyResults")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "ParkName")]
        public IWebElement ParkName { get; set; }

        //[FindsBy(How = How.Name, Using ="NumberOfVotes")]
        //public IWebElement NumberOfVotes { get; set; }

        //[FindsBy(How = How.Name, Using = "Email")]
        //public IWebElement Email { get; set; }

        //[FindsBy(How = How.Name, Using = "State")]
        //public IWebElement State { get; set; }

        //[FindsBy(How = How.Name, Using ="SatisfactionScore")]
        //public IWebElement SatisfactionScore { get; set; }

    }
}

