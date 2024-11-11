using System;

namespace Project_1
{
    partial class Form_Stock
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_load = new System.Windows.Forms.Button();
            this.openFileDialog_load = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.chart_stockDisplay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView_stockDisplay = new System.Windows.Forms.DataGridView();
            this.fileSystemWatcher_load = new System.IO.FileSystemWatcher();
            this.comboBox_companyName = new System.Windows.Forms.ComboBox();
            this.comboBox_filters = new System.Windows.Forms.ComboBox();
            this.label_frequency = new System.Windows.Forms.Label();
            this.label_companyName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_load)).BeginInit();
            this.SuspendLayout();
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(496, 12);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(199, 94);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load Stock(s)";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // openFileDialog_load
            // 
            this.openFileDialog_load.Filter = "All Files|*.csv|Monthly|*Month.csv|Weekly|*Week.csv|Daily|*Day.csv|AAPL|AAPL-*.cs" +
    "v|DIS|DIS-*.csv|IBM|IBM-*.csv|INTC|INTC-*csv|PAYX|PAYX-*csv";
            this.openFileDialog_load.FilterIndex = 2;
            this.openFileDialog_load.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_load_FileOk);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(2, 47);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(467, 38);
            this.dateTimePicker_startDate.TabIndex = 1;
            this.dateTimePicker_startDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(722, 47);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(462, 38);
            this.dateTimePicker_endDate.TabIndex = 2;
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(12, 12);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(202, 32);
            this.label_startDate.TabIndex = 3;
            this.label_startDate.Text = "Pick Start Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(728, 12);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(193, 32);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "Pick End Date";
            // 
            // chart_stockDisplay
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_stockDisplay.ChartAreas.Add(chartArea1);
            this.chart_stockDisplay.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chart_stockDisplay.Legends.Add(legend1);
            this.chart_stockDisplay.Location = new System.Drawing.Point(1083, 139);
            this.chart_stockDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.chart_stockDisplay.Name = "chart_stockDisplay";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Chartreuse";
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series2.ChartArea = "ChartArea_Volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_stockDisplay.Series.Add(series1);
            this.chart_stockDisplay.Series.Add(series2);
            this.chart_stockDisplay.Size = new System.Drawing.Size(1443, 1305);
            this.chart_stockDisplay.TabIndex = 11;
            this.chart_stockDisplay.Text = "chart1";
            this.chart_stockDisplay.Click += new System.EventHandler(this.chart_stockDisplay_Click);
            // 
            // dataGridView_stockDisplay
            // 
            this.dataGridView_stockDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stockDisplay.Location = new System.Drawing.Point(2, 139);
            this.dataGridView_stockDisplay.Name = "dataGridView_stockDisplay";
            this.dataGridView_stockDisplay.RowHeadersWidth = 102;
            this.dataGridView_stockDisplay.RowTemplate.Height = 40;
            this.dataGridView_stockDisplay.Size = new System.Drawing.Size(1076, 1305);
            this.dataGridView_stockDisplay.TabIndex = 6;
            // 
            // fileSystemWatcher_load
            // 
            this.fileSystemWatcher_load.EnableRaisingEvents = true;
            this.fileSystemWatcher_load.SynchronizingObject = this;
            // 
            // comboBox_companyName
            // 
            this.comboBox_companyName.FormattingEnabled = true;
            this.comboBox_companyName.Location = new System.Drawing.Point(1509, 46);
            this.comboBox_companyName.Name = "comboBox_companyName";
            this.comboBox_companyName.Size = new System.Drawing.Size(205, 39);
            this.comboBox_companyName.TabIndex = 10;
            this.comboBox_companyName.SelectedIndexChanged += new System.EventHandler(this.comboBox_companyName_SelectedIndexChanged);
            // 
            // comboBox_filters
            // 
            this.comboBox_filters.FormattingEnabled = true;
            this.comboBox_filters.Location = new System.Drawing.Point(1244, 46);
            this.comboBox_filters.Name = "comboBox_filters";
            this.comboBox_filters.Size = new System.Drawing.Size(220, 39);
            this.comboBox_filters.TabIndex = 11;
            this.comboBox_filters.SelectedIndexChanged += new System.EventHandler(this.comboBox_filters_SelectedIndexChanged);
            // 
            // label_frequency
            // 
            this.label_frequency.AutoSize = true;
            this.label_frequency.Location = new System.Drawing.Point(1238, 9);
            this.label_frequency.Name = "label_frequency";
            this.label_frequency.Size = new System.Drawing.Size(122, 32);
            this.label_frequency.TabIndex = 12;
            this.label_frequency.Text = "Duration";
            // 
            // label_companyName
            // 
            this.label_companyName.AutoSize = true;
            this.label_companyName.Location = new System.Drawing.Point(1503, 9);
            this.label_companyName.Name = "label_companyName";
            this.label_companyName.Size = new System.Drawing.Size(135, 32);
            this.label_companyName.TabIndex = 13;
            this.label_companyName.Text = "Company";
            // 
            // Form_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2521, 1443);
            this.Controls.Add(this.label_companyName);
            this.Controls.Add(this.label_frequency);
            this.Controls.Add(this.comboBox_filters);
            this.Controls.Add(this.comboBox_companyName);
            this.Controls.Add(this.dataGridView_stockDisplay);
            this.Controls.Add(this.chart_stockDisplay);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_load);
            this.Name = "Form_Stock";
            this.Text = "Input Form to Load Stock";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void chart_stockDisplay_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.OpenFileDialog openFileDialog_load;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockDisplay;
        private System.Windows.Forms.DataGridView dataGridView_stockDisplay;
        private System.IO.FileSystemWatcher fileSystemWatcher_load;
        private System.Windows.Forms.ComboBox comboBox_companyName;
        private System.Windows.Forms.ComboBox comboBox_filters;
        private System.Windows.Forms.Label label_companyName;
        private System.Windows.Forms.Label label_frequency;
    }
}

