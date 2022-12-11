using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataDesignFinal_Forms.Services
{
    internal class Error
    {
        public string Message { get; set; }
        public string MethodSource { get; set; }
        public static List<Error> ErrorList = new List<Error>();

        public Error(string message, string methodSource)
        {
            this.Message = message;
            this.MethodSource = methodSource;
        }

        public static void ExportErrorsToFile(object sender, EventArgs e)
        {
            //Get the output path
            string outPath = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\OutputFiles\ErrorReport.txt";

            //If the file exists in the output path, delete it
            if (File.Exists(outPath))
            {
                File.Delete(outPath);
            }

            //Only create the file if there are errors to report
            if (ErrorList.Count > 0)
            {
                //Streamwriter for writing the passed in logs
                using (StreamWriter sw = new StreamWriter(outPath, true))
                {
                    if (ErrorList.Count > 0)
                    {
                        //For every log, write it out on a new line
                        foreach (var error in ErrorList)
                        {
                            sw.WriteLine($"{error.Message} -> {error.MethodSource}");
                            sw.WriteLine("-----------------------------------------------------------------------------------");
                        }
                    }
                }

                MessageBox.Show($"ErrorReport.txt exported to {outPath}");
            }
        }
    }
}
