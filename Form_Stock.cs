/*
Nhi Nguyen - U19914074
COP 4365
Project 1-Program loads and display stock data in candlestick chart format and in DataGridView format
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project_1
{
    /// <summary>
    /// Form for viewing and analyzing stock data with candlestick charts.
    /// </summary>
    public partial class Form_Stock : Form
    {
        // Holds the entire list of Candlestick data loaded from the file
        private List<Candlestick> candlesticks = null;

        // Holds the filtered Candlestick data (within a selected date range) for data binding
        private BindingList<Candlestick> filteredCandlesticks = null;

        private string selectedCompany = ""; // Stores the selected company name
        private string selectedFrequency = ""; // Stores the selected frequency (Daily, Weekly, or Monthly)

        /// <summary>
        /// Initializes a new instance of the Form_Stock class, setting up necessary components.
        /// </summary>
        public Form_Stock()
        {
            InitializeComponent(); // Initializes form components
            candlesticks = new List<Candlestick>(1024); // Preallocate space for 1024 Candlestick objects
            filteredCandlesticks = new BindingList<Candlestick>(); // Initialize filtered candlestick list
            InitializeComboBoxes(); // Populate combo boxes for company names and filter frequency options
        }

        /// <summary>
        /// Populates the combo boxes with company names and frequency filters.
        /// </summary>
        private void InitializeComboBoxes()
        {
            // Add company options to the comboBox_companyName
            comboBox_companyName.Items.AddRange(new string[] { "AAPL", "DIS", "IBM", "INTC", "PAYX" });

            // Add frequency options to the comboBox_filters
            comboBox_filters.Items.AddRange(new string[] { "Daily", "Weekly", "Monthly" });

            // Set default selections
            comboBox_companyName.SelectedIndex = 0; // Default to the first company
            comboBox_filters.SelectedIndex = 0; // Default to the first frequency option
        }

        /// <summary>
        /// Event handler that updates the selected frequency when a new option is chosen.
        /// </summary>
        private void comboBox_filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assign the selected frequency to the variable
            selectedFrequency = comboBox_filters.SelectedItem.ToString();
        }

        /// <summary>
        /// Event handler that updates the selected company when a new option is chosen.
        /// </summary>
        private void comboBox_companyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assign the selected company name to the variable
            selectedCompany = comboBox_companyName.SelectedItem.ToString();
        }

        /// <summary>
        /// Constructs the filter string for OpenFileDialog based on the selected company and frequency.
        /// </summary>
        private string ConstructFilterString()
        {
            // Base filter for showing all files
            string filter = "All Files|*.*";

            // Append specific filter options based on the frequency
            switch (selectedFrequency)
            {
                case "Daily":
                    filter += $"|{selectedCompany} Daily|{selectedCompany}-Day.csv"; // When users opt for Daily duration
                    break;
                case "Weekly":
                    filter += $"|{selectedCompany} Weekly|{selectedCompany}-Week.csv"; // When users opt for Weekly duration
                    break;
                case "Monthly":
                    filter += $"|{selectedCompany} Monthly|{selectedCompany}-Month.csv"; // When users opt for Monthly duration
                    break;
            }

            return filter; // Return the constructed filter string
        }

        /// <summary>
        /// Handles the event when the load button is clicked.
        /// </summary>
        private void button_load_Click(object sender, EventArgs e)
        {
            this.Text = "Loading stock data..."; // Update form title to show loading status
            openFileDialog_load.Filter = ConstructFilterString(); // Apply the dynamic filter string
            openFileDialog_load.ShowDialog(); // Display the OpenFileDialog to the user
        }

        /// <summary>
        /// Event handler for when a file is selected in OpenFileDialog.
        /// </summary>
        private void openFileDialog_load_FileOk(object sender, CancelEventArgs e)
        {
            LoadCandlestickData(); // Load data from the selected file
            ApplyDateFilter(); // Filter data by the chosen date range
            NormalizeChart(); // Adjust chart scale to fit the data range
            BindDataToViews(); // Bind data to both the DataGridView and Chart
        }

        /// <summary>
        /// Reads and parses stock data from the selected file.
        /// </summary>
        private void LoadCandlestickData()
        {
            // Load the file and parse it into a list of Candlestick objects
            candlesticks = ParseFile(openFileDialog_load.FileName);
        }

        /// <summary>
        /// Parses the stock data file and returns a list of Candlestick objects.
        /// </summary>
        private List<Candlestick> ParseFile(string filename)
        {
            var parsedData = new List<Candlestick>(); // Holds the parsed data
            const string header = "Date,Open,High,Low,Close,Volume"; // Expected CSV header format

            using (var reader = new StreamReader(filename))
            {
                parsedData.Clear(); // Clear any existing data
                string line = reader.ReadLine(); // Read the header line

                if (line == header) // Ensure file has the correct format
                {
                    // Read each line, create a Candlestick object, and add it to the list
                    while ((line = reader.ReadLine()) != null)
                    {
                        var candlestick = new Candlestick(line);
                        parsedData.Add(candlestick);
                    }
                }
                else
                {
                    this.Text = $"Invalid File Format: {filename}"; // Show error if header format is wrong
                }
            }

            return parsedData; // Return the parsed list
        }

        /// <summary>
        /// Filters candlestick data by date range and updates the BindingList for data binding.
        /// </summary>
        private void ApplyDateFilter()
        {
            DateTime startDate = dateTimePicker_startDate.Value; // Selected start date
            DateTime endDate = dateTimePicker_endDate.Value; // Selected end date

            // Filter candlesticks within the specified date range and update the filtered list
            filteredCandlesticks = new BindingList<Candlestick>(
                candlesticks.Where(cs => cs.Date >= startDate && cs.Date <= endDate).ToList()
            );
        }

        /// <summary>
        /// Binds the filtered candlestick data to the DataGridView and Chart controls.
        /// </summary>
        private void BindDataToViews()
        {
            dataGridView_stockDisplay.DataSource = filteredCandlesticks; // Bind to DataGridView
            chart_stockDisplay.DataSource = filteredCandlesticks; // Bind to Chart
            chart_stockDisplay.DataBind(); // Refresh the chart display
        }

        /// <summary>
        /// Normalizes the chart display by expanding the Y-axis range slightly.
        /// </summary>
        private void NormalizeChart()
        {
            // Check if filtered data list is empty
            if (filteredCandlesticks.Count == 0)
            {
                // Show error message if there’s no data to display
                MessageBox.Show("Please Check Date Input", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit if there’s no data
            }

            // Normalize chart with the minimum "low" and maximum "high" values from filtered data
            NormalizeChart(
                filteredCandlesticks.Min(obj => obj.Low),
                filteredCandlesticks.Max(obj => obj.High)
            );
        }

        /// <summary>
        /// Adjusts the chart Y-axis based on the min and max values with a 2% margin.
        /// </summary>
        /// <param name="min">The minimum "low" value.</param>
        /// <param name="max">The maximum "high" value.</param>
        private void NormalizeChart(decimal min, decimal max)
        {
            // Calculate adjusted values with a 2% margin
            decimal adjustedMin = min - (min * 0.02m);
            decimal adjustedMax = max + (max * 0.02m);

            // Set Y-axis minimum and maximum in the chart area
            chart_stockDisplay.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = (double)adjustedMin;
            chart_stockDisplay.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = (double)adjustedMax;
        }
    }
}