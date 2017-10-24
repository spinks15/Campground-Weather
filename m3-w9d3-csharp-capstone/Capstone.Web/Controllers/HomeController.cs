using Capstone.Web.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            int x = applicationDal.TestMethod();
            return View("Index");
        }
    }
}