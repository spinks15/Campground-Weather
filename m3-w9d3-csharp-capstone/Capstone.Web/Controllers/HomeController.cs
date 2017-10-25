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
            if (Session["Fahrenheit"] == null)
            {
                Session["Fahrenheit"] = true;
            }

            //int x = applicationDal.TestMethod();
            List<Park> allParks = applicationDal.GetAllParks();
            return View("Index", allParks);
        }

        public ActionResult Detail(string id)
        {
            Park specificPark = applicationDal.GetSpecificPark(id);
            //Park specificParkForDetail = allParks.Find(x => x.ParkCode == id.ToLower());
            return View("Detail", specificPark);
        }
        
        //public ActionResult FiveDayForcast(string id)
        //{

        //}
    }
}