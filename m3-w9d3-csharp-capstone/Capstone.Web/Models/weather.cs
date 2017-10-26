using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public int LowC { get; set; }
        public int HighC { get; set; }
        public string Recommendation { get; set; }
        public string TempRecommendation { get; set; }

        public int FtoC(int TempFahren)
        {
            double celsius = (TempFahren - 32) * 5 / 9;
            return (int)celsius;
        }
        public void PopulateCelsius()
        {
            LowC = FtoC(Low);
            HighC = FtoC(High);
        }

        public void PopulateRecommendations()
        {
            if (Forecast == "snow")
            {
                Recommendation = "Better pack snowshoes.";
            }
            else if (Forecast == "rain")
            {
                Recommendation = "Pack Rain Gear, and Waterproof Shoes";
            }
            else if (Forecast == "thunderstorms")
            {
                Recommendation = "Seek shelter!  Avoid Hiking on Exposed Ridges.";
            }
            else if (Forecast == "sunny")
            {
                Recommendation = "Better pack sunblock.";
            }
            if (High > 75)
            {
                TempRecommendation = "Bring an extra gallon of water";
            }
            if (High-Low>20)
            {
                TempRecommendation += "Wear breathable layers";
            }
            if (Low<20)
            {
                TempRecommendation += "Watch out for frostbite!";
            }
        }
               
    }
}