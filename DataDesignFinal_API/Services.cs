using DataDesignFinal_API.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataDesignFinal_API
{
    public class Services
    {
        //string for connecting to DB
        private string SqlConString { get; set; } = string.Empty;

        /// <summary>
        /// Make sure the SqlConnection string is not empty
        /// </summary>
        /// <param name="SqlConString"></param>
        /// <returns></returns>
        public void PrepareDBConnection()
        {
            if (SqlConString == string.Empty)
            {
                //Get all the server connection info when the engine is instantiated
                SqlConnectionStringBuilder SqlConBuilder = new SqlConnectionStringBuilder();

                SqlConBuilder["server"] = @"(localdb)\MSSQLLocalDB";
                SqlConBuilder["Trusted_Connection"] = true;
                SqlConBuilder["Integrated Security"] = "SSPI";
                SqlConBuilder["Initial Catalog"] = "PROG260FA22";

                //String for opening connections to the SQL server
                SqlConString = SqlConBuilder.ToString();
            }
        }

        /// <summary>
        /// Get Data for full report
        /// </summary>
        /// <returns></returns>
        public List<BossModel> GetFullReport()
        {
            //list to hold records
            List<BossModel> bossList = new List<BossModel>();

            //using a connection to the DB
            using (SqlConnection conn = new SqlConnection(SqlConString))
            {
                //open the connection
                conn.Open();

                //Sproc used for getting the necessary view
                string sproc = $@"[dbo].[spSelectFromView]";

                using (var command = new SqlCommand(sproc, conn))
                {
                    //add the parameters, which in this case is the viewname
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ViewName", "vw_EldenRingFullReport");

                    //Read the table resulting from Sproc
                    var tableReader = command.ExecuteReader();

                    //An array that is the size of the amount of values in each row
                    Object[] values = new object[tableReader.FieldCount];
                    //String builder for making the record string
                    StringBuilder sb = new StringBuilder();

                    //While there is something to read
                    while (tableReader.Read())
                    {
                        //Map the recieved data to the BossModel and add to the list of records
                        BossModel model = new BossModel();
                        model.Id = (int)tableReader["id"];
                        model.Name = (string)tableReader["Name"];
                        model.Type = (string)tableReader["Type"];
                        model.Location = (string)tableReader["Location"];
                        model.Strength = (string)tableReader["Strength"];
                        model.Weakness = (tableReader["Weakness"] != DBNull.Value ? (string)tableReader["Weakness"] : "No Weakness");

                        bossList.Add(model);
                    }

                    //close the table reader
                    tableReader.Close();
                }

                //close the connection
                conn.Close();
            }

            return bossList;
        }

        /// <summary>
        /// Get data for chart one
        /// </summary>
        /// <returns></returns>
        public List<ChartModel> GetChartOne()
        {
            //get chart data from vw_EldenRingChartOne
            return GetChartData("ChartOne");
        }

        /// <summary>
        /// Get data for chart two
        /// </summary>
        /// <returns></returns>
        public List<ChartModel> GetChartTwo()
        {
            //Get data from vw_EldenRingChartTwo
            return GetChartData("ChartTwo");
        }

        /// <summary>
        /// Get data for charts
        /// </summary>
        /// <param name="viewName">The view that the data will come from. Passed in by GetChartTwo or GetChartOne</param>
        /// <returns></returns>
        private List<ChartModel> GetChartData(string viewName)
        {
            //list for chart data
            List<ChartModel> dataList = new List<ChartModel>();

            using (SqlConnection conn = new SqlConnection(SqlConString))
            {
                //open the connection
                conn.Open();

                //Sproc used for getting data from desired view
                string sproc = $@"[dbo].[spSelectFromView]";

                using (var command = new SqlCommand(sproc, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ViewName", $@"vw_EldenRing{viewName}");

                    //Read the table
                    var tableReader = command.ExecuteReader();

                    //An array that is the size of the amount of values in each row
                    Object[] values = new object[tableReader.FieldCount];
                    //String builder for making the record string
                    StringBuilder sb = new StringBuilder();

                    //While there is something to read
                    while (tableReader.Read())
                    {
                        //Map the recieved data to the ChartModel and add to the list of records
                        ChartModel model = new ChartModel();
                        model.X = (string)tableReader["X"];
                        model.Y = (int)tableReader["Y"];

                        dataList.Add(model);
                    }

                    //close the table reader
                    tableReader.Close();
                }

                //close the connection
                conn.Close();
            }

            return dataList;
        }

        /// <summary>
        /// Get data regarding damage types
        /// </summary>
        /// <returns></returns>
        public List<DamageModel> GetDamageInfo()
        {
            //list for holding the records
            List<DamageModel> damageList = new List<DamageModel>();

            using (SqlConnection conn = new SqlConnection(SqlConString))
            {
                conn.Open();

                //Sproc used for getting all the damage types from the table
                string sproc = $@"[dbo].[spGetAllDamages]";

                using (var command = new SqlCommand(sproc, conn))
                {
                    //no parameters, since the Sproc is just a select statement to get data from EldenRing_Damage table
                    command.CommandType = CommandType.StoredProcedure;

                    //Read the table
                    var tableReader = command.ExecuteReader();

                    //An array that is the size of the amount of values in each row
                    Object[] values = new object[tableReader.FieldCount];
                    //String builder for making the record string
                    StringBuilder sb = new StringBuilder();

                    //While there is something to read
                    while (tableReader.Read())
                    {
                        //Map the recieved data to the DamageModel and add to the list of records
                        DamageModel model = new DamageModel();
                        model.Id = (int)tableReader["id"];
                        model.DamageType = (string)tableReader["damage_type"];

                        damageList.Add(model);
                    }

                    //close the table reader
                    tableReader.Close();
                }

                conn.Close();
            }

            return damageList;
        }

        /// <summary>
        /// Get data regarding locations
        /// </summary>
        /// <returns></returns>
        public List<LocationModel> GetLocationInfo()
        {
            //List for holding location records
            List<LocationModel> locationList = new List<LocationModel>();

            using (SqlConnection conn = new SqlConnection(SqlConString))
            {
                conn.Open();

                //Sproc used for getting all the Locations from the table
                string sproc = $@"[dbo].[spGetAllLocations]";

                using (var command = new SqlCommand(sproc, conn))
                {
                    //no parameters, since sproc is just selecting all from EldenRing_Locations table
                    command.CommandType = CommandType.StoredProcedure;

                    //Read the table
                    var tableReader = command.ExecuteReader();

                    //An array that is the size of the amount of values in each row
                    Object[] values = new object[tableReader.FieldCount];
                    //String builder for making the record string
                    StringBuilder sb = new StringBuilder();

                    //While there is something to read
                    while (tableReader.Read())
                    {
                        //map read data to LocationModel
                        LocationModel model = new LocationModel();
                        model.Id = (int)tableReader["id"];
                        model.Location = (string)tableReader["location"];

                        locationList.Add(model);
                    }

                    //close the table reader
                    tableReader.Close();
                }

                conn.Close();
            }

            return locationList;
        }
    }
}