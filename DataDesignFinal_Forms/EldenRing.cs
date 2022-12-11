using DataDesignFinal_Forms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataDesignFinal_Forms
{
    public partial class EldenRing : Form
    {
        Service service = new Service();

        public EldenRing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// on load, clear the charts and panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //on load, clear the charts and UI
            ClearAllCharts();
        }

        /// <summary>
        /// Create the Strengths chart and get the data to populate it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StrengthsChartButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                //clear previous charts and panel
                ClearAllCharts();

                //get data
                var models = service.GetChartData("get-chart-two").Result;

                //add chart
                panel1.Controls.Add(strengthChart);

                //title and size config
                strengthChart.Titles.Add("Bosses by Strengths");
                strengthChart.Size = new Size(panel1.Width, panel1.Height);

                //add area and configure
                var strengthArea = strengthChart.ChartAreas.Add("strengthArea");
                strengthArea.AxisX.Title = "Strengths";
                strengthArea.AxisY.Title = "Boss Count";
                strengthArea.AxisX.TitleAlignment = StringAlignment.Center;
                strengthArea.AxisY.TitleAlignment = StringAlignment.Center;
                strengthArea.AxisX.Interval = 1;

                //add series for data
                var strengthSeries = strengthChart.Series.Add("Number of Bosses");
                strengthSeries.ChartType = SeriesChartType.Column;
                strengthSeries.IsValueShownAsLabel = true;
                strengthSeries.BorderWidth = 3;

                //add data to chart
                foreach (var model in models)
                {
                    strengthSeries.Points.AddXY(model.X, model.Y);
                }
            }
            catch (IOException exc)
            {
                MessageBox.Show("Could not generate Strength Chart (make sure API is running", "Error");
                Error.ErrorList.Add(new Error("Could not generate Strength Chart (make sure API is running", "StrengthsChartButton_OnClick"));
                return;
            }
            catch (NullReferenceException exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "StrengthChartButton_OnClick"));
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "StrengthChartButton_OnClick"));
                return;
            }
        }

        /// <summary>
        /// Create the Types chart and get the data to populate it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeChartButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                //clear previous charts and panel
                ClearAllCharts();

                //get data
                var models = service.GetChartData("get-chart-one").Result;

                //add chart
                panel1.Controls.Add(typeChart);

                //title and size config
                typeChart.Titles.Add("Bosses by Types");
                typeChart.Size = new Size(panel1.Width, panel1.Height);

                //add area and configure
                var typeArea = typeChart.ChartAreas.Add("typeArea");
                typeArea.AxisX.Title = "Types";
                typeArea.AxisY.Title = "Boss Count";
                typeArea.AxisX.TitleAlignment = StringAlignment.Center;
                typeArea.AxisY.TitleAlignment = StringAlignment.Center;
                typeArea.AxisX.Interval = 1;

                //add series for data
                var typeSeries = typeChart.Series.Add("Number of Bosses");
                typeSeries.ChartType = SeriesChartType.Pie;
                typeSeries.IsValueShownAsLabel = true;
                typeSeries.BorderWidth = 3;

                //add data to chart
                foreach (var model in models)
                {
                    typeSeries.Points.AddXY(model.X, model.Y);
                }
            }
            catch (IOException exc)
            {
                MessageBox.Show("Could not generate Type Chart (make sure API is running", "Error");
                Error.ErrorList.Add(new Error("Could not generate Type Chart (make sure API is running", "TypeChartButton_OnClick"));
                return;
            }
            catch (NullReferenceException exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "TypeChartButton_OnClick"));
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "TypeChartButton_OnClick"));
                return;
            }
        }

        /// <summary>
        /// Get full report of elden ring bosses and export as CSV to OutputFiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullReportButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                //column names for the file to exported
                string columnNames = "id,Name,Type,Location,Strength,Weakness";

                //This message will be what shows in the messagebox after the data has been exported.
                //This also passes in a list of strings, which are transformed from a list of BossModel records that are recieved from the API
                string message = service.ExportToFile(service.GetFullReportData().Result, "FullReport.csv", columnNames);

                MessageBox.Show(message, "Export Result");
            }
            catch (IOException exc)
            {
                MessageBox.Show("Could not export full report (make sure API is running", "Error");
                Error.ErrorList.Add(new Error("Could not export full report (make sure API is running", "FullReportButton_OnClick"));
                return;
            }
            catch (NullReferenceException exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "FullReportButton_OnClick"));
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "FullReportButton_OnClick"));
                return;
            }
        }

        /// <summary>
        /// Get location table and export as csv to OutputFiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocationsInfoButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Column names for exported csv
                string columnNames = "id,Location";

                //same as FullReport message, but for location csv
                string message = service.ExportToFile(service.GetLocationReportData().Result, "LocationInfo.csv", columnNames);

                MessageBox.Show(message, "Export Result");
            }
            catch (IOException exc)
            {
                MessageBox.Show("Could not export location data (make sure API is running", "Error");
                Error.ErrorList.Add(new Error("Could not export location data (make sure API is running", "LocationsInfoButton_OnClick"));
                return;
            }
            catch (NullReferenceException exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "LocationsInfoButton_OnClick"));
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "LocationsInfoButton_OnClick"));
                return;
            }
        }

        /// <summary>
        /// Get damage table and export to csv in OutputFiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DamageTypeInfoButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                //column names for exported csv
                string columnNames = "id,Damage_Type";

                //same as full report message, but for damage info csv
                string message = service.ExportToFile(service.GetDamageReportData().Result, "DamageInfo.csv", columnNames);

                MessageBox.Show(message, "Export Result");
            }
            catch (IOException exc)
            {
                MessageBox.Show("Could not export damage-type data (make sure API is running", "Error");
                Error.ErrorList.Add(new Error("Could not export damage-type data (make sure API is running", "DamageTypeInfoButton_OnClick"));
                return;
            }
            catch (NullReferenceException exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "DamageTypeInfoButton_OnClick"));
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message} (make sure API is running)", "Error");
                Error.ErrorList.Add(new Error(exc.Message, "DamageTypeInfoButton_OnClick"));
                return;
            }
        }

        /// <summary>
        /// clear all charts and clear the panel so it is ready for the next chart
        /// </summary>
        private void ClearAllCharts()
        {
            //clear all charts present to keep UI clean and prevent overlapping
            strengthChart.Series.Clear();
            strengthChart.ChartAreas.Clear();
            typeChart.Series.Clear();
            typeChart.ChartAreas.Clear();
            panel1.Controls.Clear();
        }
    }


}
