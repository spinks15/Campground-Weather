using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Web.Models;
using System;


namespace Capstone.Web.Dal
{
    public class ParkWeatherSqlDal : IParkWeatherDal
    {
        private readonly string connectionString;
        private const string SQL_InsertSurvey = "INSERT INTO survey_result VALUES(@surveryId, @parkCode, @emailAddress, @state, @activityLevel);";

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
       


    }
}

