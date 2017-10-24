using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString; 

        public HomeController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["NationalParkWeatherDB"].ConnectionString;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}