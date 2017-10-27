﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Capstone.Web.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public string Url { get; set; }

        public BasePage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.Url = url;
        }

        public void Navigate()
        {
            string url = driver.Url;
            Uri currentUri = new Uri(url);
            string baseUrl = currentUri.Authority;
            driver.Navigate().GoToUrl(baseUrl + Url);
        }
    }
}
