using Capstone.Web.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;


namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {


        
        private readonly IParkWeatherDal applicationDal;

        public HomeController(IParkWeatherDal applicationDal)
        {
            this.applicationDal = applicationDal;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Park> allParks = applicationDal.GetAllParks();
            return View("Index", allParks);
        }

        //  GET: Detail
        public ActionResult Detail(string id)
        {
            Park specificPark = applicationDal.GetSpecificPark(id);
            //Park specificParkForDetail = allParks.Find(x => x.ParkCode == id.ToLower());
            return View("Detail", specificPark);
        }

        //  GET: Forecast 
        public ActionResult Forecast(string id)
        {
            if (HttpContext.Session["Fahrenheit"] == null)
            {
                Session["Fahrenheit"] = true;
            }
            List<Weather> weather = applicationDal.Get5dayWeatherForSpecificPark(id);
            return View("Forecast", weather);
        }

        //  POST: Forecast w/ Temp Scale Toggle
        public ActionResult ForecastToggle(string id, bool fahrenheit)
        {
            Session["Fahrenheit"] = fahrenheit;
            
            if (fahrenheit == false)
            {
                Session["Fahrenheit"] = false;
            }
            if (fahrenheit == true)
            {
                Session["Fahrenheit"] = true;
            }
            List<Weather> weather = applicationDal.Get5dayWeatherForSpecificPark(id);
            return View("Forecast", weather);
        }

        //  GET:  Survey

        public ActionResult Survey()
        {
            return View("Survey");
        }

        // POST:  Survey

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            // Save the Survey
            bool Survey = applicationDal.SaveSurvey(survey);

            // Redirect the user to the Confirmation Page
            return RedirectToAction("SurveyResults");
        }


        // GET: Survey Results
        public ActionResult SurveyResults()
        {
            List<Park> surveyResults = applicationDal.SurveyResults();
            return View("SurveyResults", surveyResults);
        }
    }

}