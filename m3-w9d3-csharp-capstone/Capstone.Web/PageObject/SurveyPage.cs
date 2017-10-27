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


        [FindsBy(How = How.Name, Using = "FavoritePark")]
        public IWebElement FavoritePark { get; set; }

        [FindsBy(How = How.Name, Using = "Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "State")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using = "SatisfactionScore")]
        public IWebElement SatisfactionScore { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form button")]
        public IWebElement SubmitButton { get; set; }

        public SurveyResultPage FillOutForm(string favortiePark, string email, string state, string satisfactionScore)
        {
            SelectElement favoriteParkDropDown = new SelectElement(FavoritePark);
            favoriteParkDropDown.SelectByText(favortiePark);

            Email.SendKeys(email.ToString());

            string id = $"State_{(string)state}";
            IWebElement radioButton = driver.FindElement(By.Id(id));
            radioButton.Click();

            SelectElement satisfactionScoreDropDown = new SelectElement(SatisfactionScore);
            satisfactionScoreDropDown.SelectByText(satisfactionScore);


            SubmitButton.Click();

            return new SurveyResultPage(driver);
        }
    }

}


