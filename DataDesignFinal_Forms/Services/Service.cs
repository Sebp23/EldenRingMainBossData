using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataDesignFinal_Forms.Models;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace DataDesignFinal_Forms.Services
{
    internal class Service
    {
        /// <summary>
        /// Get the data for the charts
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChartModel>> GetChartData(string endpoint)
        {
            //list to hold the data
            List<ChartModel> models = new List<ChartModel>();

            //invoke the endpoint of the api that provides the data for charts
            using (HttpClient client = new HttpClient())
            {
                //Set the base url and the request headers
                client.BaseAddress = new Uri("https://localhost:7216/EldenRing/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Invoke the end point
                HttpResponseMessage response = client.GetAsync(($"{endpoint}")).Result;
                models = JsonConvert.DeserializeObject<List<ChartModel>>(await response.Content.ReadAsStringAsync());

                //add a log
                Logger.Logs.Add(new Logger($"Get Chart Data: {response.StatusCode}", (int)response.StatusCode, DateTime.Now));
            }

            return models;
        }

        /// <summary>
        /// Get the data for full report csv
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetFullReportData()
        {
            //list to hold the data
            List<BossModel> models = new List<BossModel>();
            List<string> stringRecords = new List<string>();

            //invoke the endpoint of the api that provides the data for chart 1
            using (HttpClient client = new HttpClient())
            {
                //Set the base url and the request headers
                client.BaseAddress = new Uri("https://localhost:7216/EldenRing/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Invoke the end point
                HttpResponseMessage response = client.GetAsync(("get-full-report")).Result;
                models = JsonConvert.DeserializeObject<List<BossModel>>(await response.Content.ReadAsStringAsync());

                foreach (var model in models)
                {
                    //convert to string with ',' delimiter for exporting to csv file
                    string modelStr = $"{model.Id},{model.Name},{model.Type},{model.Location},{model.Strength},{model.Weakness}";
                    stringRecords.Add(modelStr);
                }

                //add a log
                Logger.Logs.Add(new Logger($"Get Full Report: {response.StatusCode}", (int)response.StatusCode, DateTime.Now));
            }

            return stringRecords;
        }

        /// <summary>
        /// Get the data for location csv
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetLocationReportData()
        {
            //list to hold the data
            List<LocationModel> models = new List<LocationModel>();
            List<string> stringRecords = new List<string>();

            //invoke the endpoint of the api that provides the data for location info
            using (HttpClient client = new HttpClient())
            {
                //Set the base url and the request headers
                client.BaseAddress = new Uri("https://localhost:7216/EldenRing/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Invoke the end point
                HttpResponseMessage response = client.GetAsync("get-location-info").Result;
                models = JsonConvert.DeserializeObject<List<LocationModel>>(await response.Content.ReadAsStringAsync());

                foreach (var model in models)
                {
                    //convert to string with ',' delimiter for exporting to csv file
                    string modelStr = $"{model.Id},{model.Location}";
                    stringRecords.Add(modelStr);
                }

                //add a log
                Logger.Logs.Add(new Logger($"Get Location Info: {response.StatusCode}", (int)response.StatusCode, DateTime.Now));
            }

            return stringRecords;
        }
        
        /// <summary>
        /// Get the data for Damage csv
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetDamageReportData()
        {
            //list to hold the data
            List<DamageModel> models = new List<DamageModel>();
            List<string> stringRecords = new List<string>();

            //invoke the endpoint of the api that provides the data for Damage info
            using (HttpClient client = new HttpClient())
            {
                //Set the base url and the request headers
                client.BaseAddress = new Uri("https://localhost:7216/EldenRing/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Invoke the end point
                HttpResponseMessage response = client.GetAsync("get-damage-info").Result;
                models = JsonConvert.DeserializeObject<List<DamageModel>>(await response.Content.ReadAsStringAsync());

                foreach (var model in models)
                {
                    //convert to string with ',' delimiter for exporting to csv file
                    string modelStr = $"{model.Id},{model.DamageType}";
                    stringRecords.Add(modelStr);
                }

                //add a log
                Logger.Logs.Add(new Logger($"Get Damage Info: {response.StatusCode}", (int)response.StatusCode, DateTime.Now));
            }

            return stringRecords;
        }

        /// <summary>
        /// Use this to export tables to files
        /// </summary>
        /// <param name="recordList">The list of rows from the joined table</param>
        /// <param name="outName">The name of the output file</param>
        /// <param name="columNames">The names of the columns that will be in the output file</param>
        public string ExportToFile(List<string> recordList, string outName, string columNames)
        {
            try
            {
                //Get the output path
                string outPath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\OutputFiles\{outName}";

                //If the file exists in the output path, delete it
                if (File.Exists(outPath))
                {
                    File.Delete(outPath);
                }

                //Streamwriter for writing the passed in records
                using (StreamWriter sw = new StreamWriter(outPath, true))
                {
                    //The column names
                    sw.WriteLine(columNames);

                    //For every record, write the record on a new line
                    foreach (var record in recordList)
                    {
                        sw.WriteLine(record);
                    }
                }

                //Message to be returned for message box if it is successful.
                //If not, then the message will be based on the catches below.
                return $"File {outName} succesfully exported to {outPath}";
            }
            catch (IOException e)
            {
                return $"Could not write to file {outName} -> ExportToFile()";
            }
            catch (NullReferenceException e)
            {
                return $"{e.Message} -> ExportToFile()";
            }
            catch (Exception e)
            {
                return $"{e.Message} -> ExportToFile()";
            }
        }
    }
}
