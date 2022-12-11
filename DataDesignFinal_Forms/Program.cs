using DataDesignFinal_Forms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataDesignFinal_Forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //On application exit, export the logs to a file.
            Application.ApplicationExit += new EventHandler(Logger.ExportLogsToFile);
            Application.ApplicationExit += new EventHandler(Error.ExportErrorsToFile);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EldenRing());
        }
    }
}
