using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;


namespace Capstone.Web.PageObjects
{
    public class SurveyPage : BasePage
    {
        public SurveyPage(IWebDriver driver)
            : base(driver, "/Home/Survey")
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Name, Using = "ParkCode")]
        public IWebElement ParkName { get; set; }

        [FindsBy(How = How.Name, Using = "EmailAddress")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "State")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using = "ActivityLevel")]
        public IWebElement ActivityLevel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form button")]
        public IWebElement SubmitButton { get; set; }

        public SurveyResultPage FillOutForm(string parkName, string email, string state, string activityLevel)
        {
        
            SelectElement favoriteParkDropDown = new SelectElement(ParkName);
            favoriteParkDropDown.SelectByText(parkName);

            Email.SendKeys(email.ToString());

            //string idd = $"State_{(string)state}";
            //IWebElement radioButton1 = driver.FindElement(By.Id(idd));
            //radioButton1.Click

            SelectElement stateDropDown = new SelectElement(State);
            stateDropDown.SelectByText(state);

            SelectElement activityLevelDropDown = new SelectElement(ActivityLevel);
            activityLevelDropDown.SelectByText(activityLevel);


            SubmitButton.Click();

            return new SurveyResultPage(driver);
        }
    }

}


