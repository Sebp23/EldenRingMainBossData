namespace DataDesignFinal_Forms
{
    partial class EldenRing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.strengthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.typeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart1Button = new System.Windows.Forms.Button();
            this.Chart2Button = new System.Windows.Forms.Button();
            this.fullReportButton = new System.Windows.Forms.Button();
            this.printLocationsButton = new System.Windows.Forms.Button();
            this.printDamageTypesButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strengthChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.strengthChart);
            this.panel1.Controls.Add(this.typeChart);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1502, 393);
            this.panel1.TabIndex = 0;
            // 
            // strengthChart
            // 
            chartArea1.Name = "ChartArea1";
            this.strengthChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.strengthChart.Legends.Add(legend1);
            this.strengthChart.Location = new System.Drawing.Point(3, 3);
            this.strengthChart.Name = "strengthChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.strengthChart.Series.Add(series1);
            this.strengthChart.Size = new System.Drawing.Size(283, 183);
            this.strengthChart.TabIndex = 5;
            this.strengthChart.Text = "chart1";
            // 
            // typeChart
            // 
            chartArea2.Name = "ChartArea1";
            this.typeChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.typeChart.Legends.Add(legend2);
            this.typeChart.Location = new System.Drawing.Point(3, 3);
            this.typeChart.Name = "typeChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.typeChart.Series.Add(series2);
            this.typeChart.Size = new System.Drawing.Size(283, 183);
            this.typeChart.TabIndex = 4;
            this.typeChart.Text = "chart1";
            // 
            // Chart1Button
            // 
            this.Chart1Button.Location = new System.Drawing.Point(75, 442);
            this.Chart1Button.Name = "Chart1Button";
            this.Chart1Button.Size = new System.Drawing.Size(158, 59);
            this.Chart1Button.TabIndex = 0;
            this.Chart1Button.Text = "Bosses by Type";
            this.Chart1Button.UseVisualStyleBackColor = true;
            this.Chart1Button.Click += new System.EventHandler(this.TypeChartButton_OnClick);
            // 
            // Chart2Button
            // 
            this.Chart2Button.Location = new System.Drawing.Point(376, 442);
            this.Chart2Button.Name = "Chart2Button";
            this.Chart2Button.Size = new System.Drawing.Size(158, 59);
            this.Chart2Button.TabIndex = 1;
            this.Chart2Button.Text = "Bosses by Strengths";
            this.Chart2Button.UseVisualStyleBackColor = true;
            this.Chart2Button.Click += new System.EventHandler(this.StrengthsChartButton_OnClick);
            // 
            // fullReportButton
            // 
            this.fullReportButton.Location = new System.Drawing.Point(697, 442);
            this.fullReportButton.Name = "fullReportButton";
            this.fullReportButton.Size = new System.Drawing.Size(158, 59);
            this.fullReportButton.TabIndex = 1;
            this.fullReportButton.Text = "Full Report to CSV";
            this.fullReportButton.UseVisualStyleBackColor = true;
            this.fullReportButton.Click += new System.EventHandler(this.FullReportButton_OnClick);
            // 
            // printLocationsButton
            // 
            this.printLocationsButton.Location = new System.Drawing.Point(1003, 442);
            this.printLocationsButton.Name = "printLocationsButton";
            this.printLocationsButton.Size = new System.Drawing.Size(158, 59);
            this.printLocationsButton.TabIndex = 2;
            this.printLocationsButton.Text = "Locations to CSV";
            this.printLocationsButton.UseVisualStyleBackColor = true;
            this.printLocationsButton.Click += new System.EventHandler(this.LocationsInfoButton_OnClick);
            // 
            // printDamageTypesButton
            // 
            this.printDamageTypesButton.Location = new System.Drawing.Point(1273, 442);
            this.printDamageTypesButton.Name = "printDamageTypesButton";
            this.printDamageTypesButton.Size = new System.Drawing.Size(177, 59);
            this.printDamageTypesButton.TabIndex = 3;
            this.printDamageTypesButton.Text = "Strengths/Weaknesses to CSV";
            this.printDamageTypesButton.UseVisualStyleBackColor = true;
            this.printDamageTypesButton.Click += new System.EventHandler(this.DamageTypeInfoButton_OnClick);
            // 
            // EldenRing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 546);
            this.Controls.Add(this.printDamageTypesButton);
            this.Controls.Add(this.printLocationsButton);
            this.Controls.Add(this.Chart1Button);
            this.Controls.Add(this.Chart2Button);
            this.Controls.Add(this.fullReportButton);
            this.Controls.Add(this.panel1);
            this.Name = "EldenRing";
            this.Text = "Elden Ring Info";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.strengthChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Chart1Button;
        private System.Windows.Forms.Button Chart2Button;
        private System.Windows.Forms.Button fullReportButton;
        private System.Windows.Forms.Button printLocationsButton;
        private System.Windows.Forms.Button printDamageTypesButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart strengthChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart typeChart;
    }
}

