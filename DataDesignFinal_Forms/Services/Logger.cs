using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignFinal_Forms.Services
{
    internal class Logger
    {
        public string ResponseStatusMessage { get; set; }
        public int ResponseStatusCode { get; set; }
        public DateTime ResponseStatusDate { get; set; }

        public static List<Logger> Logs = new List<Logger>();

        public Logger(string message, int code, DateTime responseStatusDate)
        {
            this.ResponseStatusMessage = message;
            this.ResponseStatusCode = code;
            this.ResponseStatusDate = responseStatusDate;
        }

        /// <summary>
        /// Export all logs of API interactions to a file
        /// As it may be useful for possible troubleshooting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ExportLogsToFile(object sender, EventArgs e)
        {
            //Get the output path
            string outPath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\OutputFiles\LogReport.txt";

            //If the file exists in the output path, delete it
            if (File.Exists(outPath))
            {
                File.Delete(outPath);
            }

            //Streamwriter for writing the passed in logs
            using (StreamWriter sw = new StreamWriter(outPath, true))
            {
                //For every log, write it out on a new line
                foreach (var log in Logs)
                {
                    sw.WriteLine($"{log.ResponseStatusMessage}, {log.ResponseStatusCode}, {log.ResponseStatusDate}");
                    sw.WriteLine("-----------------------------------------------------------------------------------");
                }
            }
        }
    }
}
