using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> ParkList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Cuyahoga Valley National Park", Value = "CVNP" },
                    new SelectListItem { Text = "Everglades National Park", Value = "ENP" },
                    new SelectListItem { Text = "Grand Canyon National Park", Value = "GCNP" },
                    new SelectListItem { Text = "Glacier National Park", Value = "GNP" },
                    new SelectListItem { Text = "Great Smoky Mountains National Park", Value = "GSMNP" },
                    new SelectListItem { Text = "Grand Teton National Park", Value = "GTNP" },
                    new SelectListItem { Text = "Mount Rainier National Park", Value = "MRNP" },
                    new SelectListItem { Text = "Rocky Mountain National Park", Value = "RMNP" },
                    new SelectListItem { Text = "Yellowstone National Park", Value = "YNP" },
                    new SelectListItem { Text = "Yosemite National Park", Value = "YNP2" }

                };
            }
        }

        public static List<SelectListItem> States
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Ohio", Value = "OH" },
                    new SelectListItem { Text = "Michigan", Value = "MI" },
                    new SelectListItem { Text = "Indiana", Value = "IN" }
                };
            }
        }
        public static List<SelectListItem> ActivityLevels
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Extremely Active", Value = "4" },
                    new SelectListItem { Text = "Active", Value = "3" },
                    new SelectListItem { Text = "Sedentary", Value = "2" },
                    new SelectListItem { Text = "Inactive", Value = "1" }
                };
            }
        }
    }
}