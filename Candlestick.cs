using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    public class Candlestick
    {
        /// <summary>
        /// Represents a candlestick for financial data.
        /// </summary>
        public DateTime Date { get; set; }  // Date of the candlestick
        public decimal Open { get; set; }    // Opening price
        public decimal Close { get; set; }   // Closing price
        public decimal Low { get; set; }     // Lowest price
        public decimal High { get; set; }    // Highest price
        public ulong Volume { get; set; }    // Trading volume

        /// <summary>
        /// Initializes a new instance using CSV data.
        /// </summary>
        /// <param name="rowOfData">CSV line for stock data.</param>
        public Candlestick(string rowOfData)
        {
            string[] subs = SplitCsvRow(rowOfData);  // Split CSV row

            Date = DateTime.Parse(subs[0]);          // Parse date
            Open = ParseDecimal(subs[1]);            // Parse open price
            High = ParseDecimal(subs[2]);            // Parse high price
            Low = ParseDecimal(subs[3]);             // Parse low price
            Close = ParseDecimal(subs[4]);           // Parse close price
            Volume = ParseUlong(subs[5]);            // Parse volume
        }

        /// <summary>
        /// Splits a CSV row into an array of strings.
        /// </summary>
        /// <param name="rowOfData">The CSV row to split.</param>
        /// <returns>An array of strings.</returns>
        private string[] SplitCsvRow(string rowOfData)
        {
            char[] separators = new char[] { ',', ' ', '"' };  // Define separators
            return rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);  // Split and remove empty entries
        }

        /// <summary>
        /// Parses a string into a decimal value.
        /// </summary>
        /// <param name="value">String value to parse.</param>
        /// <returns>Parsed decimal value or 0 if failed.</returns>
        private decimal ParseDecimal(string value)
        {
            return decimal.TryParse(value, out decimal result) ? decimal.Round(result, 2) : 0;  // Return rounded value or 0
        }

        /// <summary>
        /// Parses a string into an unsigned long value.
        /// </summary>
        /// <param name="value">String value to parse.</param>
        /// <returns>Parsed ulong value or 0 if failed.</returns>
        private ulong ParseUlong(string value)
        {
            return ulong.TryParse(value, out ulong result) ? result : 0;  // Return parsed value or 0
        }
    }
}
