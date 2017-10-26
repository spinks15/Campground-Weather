using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Web.Models;
using System;


namespace Capstone.Web.Dal
{
    public class ParkWeatherSqlDal : IParkWeatherDal
    {
        private readonly string connectionString;


        public ParkWeatherSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }


        // *******************  GET ALL PARKS ***********************

        private const string SQL_GetAllParks = "SELECT * FROM park";

        public List<Park> GetAllParks()
        {
            List<Park> allParks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt16(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt16(reader["yearFounded"]);
                        park.AnnualVistorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt16(reader["numberOfAnimalSpecies"]);
                        allParks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return allParks;
        }

        // *******************  GET SPECIFIC PARK ***********************

        private const string SQL_GetSpecificPark = "SELECT * FROM park WHERE parkCode = @parkCode";

        public Park GetSpecificPark(string ParkCode)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetSpecificPark, conn);
                    cmd.Parameters.AddWithValue("@parkCode", ParkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt16(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt16(reader["yearFounded"]);
                        park.AnnualVistorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt16(reader["numberOfAnimalSpecies"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return park;
        }

        // *******************  GET 5 dAY WEATHER FOR SPECIFIC PARK ***********************

        private const string SQL_Get5dayWeatherForSpecificPark = "SELECT * FROM weather WHERE parkCode = @parkCode";

        public List<Weather> Get5dayWeatherForSpecificPark(string ParkCode)
        {
            List<Weather> weather = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_Get5dayWeatherForSpecificPark, conn);
                    cmd.Parameters.AddWithValue("@parkCode", ParkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        Weather w = new Weather();
                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForecastValue = Convert.ToInt16(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt16(reader["low"]);
                        w.High = Convert.ToInt16(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);
                        w.PopulateCelsius();
                        w.PopulateRecommendations();
                        weather.Add(w);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return weather;

        }

        //  *******************  SUBMIT SURVEY  ***********************
        private const string SQL_SaveSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";

        public bool SaveSurvey(Survey survey)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                // Error Logging that a problem occurred, don't show the user
                throw;
            }
        }

        private const string SQL_SurveyResults = "SELECT park.parkName, COUNT(survey_result.parkCode) AS poop from survey_result LEFT JOIN park ON survey_result.parkCode = park.parkCode group by park.parkName order by poop desc";
        
        public List<Park> SurveyResults()
        {
            List<Park> surveyResults = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SurveyResults, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        Park p = new Park();
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.NumberOfVotes = Convert.ToInt16(reader["poop"]);  //variable name kept in honor of Brian who helped with the SQL command, and requested we keep the variable name
                        surveyResults.Add(p);

                    }

                    return surveyResults;
                   
                }
            }
            catch (SqlException ex)
            {
                // Error Logging that a problem occurred, don't show the user
                throw;
            }
        }
    }
}




