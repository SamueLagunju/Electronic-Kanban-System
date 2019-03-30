//Filename      : StationDisplay.cs
//Project Name  : Advanced SQL Project
//Programmer    : Gabriel Stewart
//Version Date  : 2019-03-29
//Description   : This contains the source code for the stock data visualizer tool
//Sources		:

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace StationDisplay
{
    // Class	    : StationDisplay
    // Description	: This class creates a visual indication of the selected stations status
    // Programmer	: Gabriel Stewart
    // Methods	    : StationDisplay_Load - Prepares assets when form loads
    //              : GetData - Returns list of records returned from DB using passed query
    public partial class StationDisplay : Form
    {
        // Private class data members
        private int station;

        private List<object> Stations = new List<object>();
        private List<object> StockData = new List<object>();

        private bool loop = false;

        // Method		: Class constructor
        // Description	: Intitializes the class
        // Parameters	: None
        // Returns		: None
        public StationDisplay()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        // Method		: StationDisplay_Load
        // Description	: Prepares assets when form loads
        // Parameters	: Generic sender info
        // Returns		: None
        private void StationDisplay_Load(object sender, System.EventArgs e)
        {
            // When the form is loaded, populate the list of available stations
            string query = "SELECT DISTINCT Station, StationBinID FROM Station;";
            Stations = GetData(query);
            foreach(object[] record in Stations)
            {
                StationLst.Items.Add(record[0]);
            }
        }

        // Method		: GetData
        // Description	: Saves records returned from executing query passes as parameter
        // Parameters	: string query - query string used to gather data from server
        // Returns		: ArrayList - contains data gathered from server
        private List<object> GetData(string query)
        {
            // Grab connection string from config file
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString;
            List<object> Results = new List<object>();

            // Establish connection to database
            using(SqlConnection con = new SqlConnection(constr))
            {
                // Execute command using query
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open(); // Open connection

                    // Execute reader to begin gathering records from db
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        // While there are still results to process
                        while(reader.Read())
                        {
                            // Gather results and add them to the results list
                            object[] records = new object[reader.FieldCount];
                            reader.GetValues(records);
                            Results.Add(records);
                        }
                    }
                }
            }

            // Return the gathered data
            return Results;
        }

        // Method		: StationLst_SelectedIndexChanged
        // Description	: Executes code when station selection changes
        // Parameters	: None
        // Returns		: None
        private void StationLst_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            station = StationLst.SelectedIndex + 1;

            // Create query using selected station
            string query = "SELECT DISTINCT P.PartName, S.Stock FROM Stock S ";
            query += "JOIN Part P ON P.PartID = S.Part ";
            query += "WHERE S.Station = " + station;
            StockData = GetData(query);
        }

        // Method		: ChartLoop
        // Description	: Thread that repeatedly draws the chart using updating data in class
        // Parameters	: None
        // Returns		: None
        private void ChartLoop()
        {
            int x = 0;
            // Recursive call to method, allows access to form element in parent thread
            //if(stockChrt.InvokeRequired)
            //{
            //    stockChrt.Invoke(new Action(() =>
            //    {
            //        ChartLoop();
            //    }
            //    ));
            //}
            //else
            //{
            // Run a loop to update chart data
            for(; ; )
            {
                // Clear series data
                stockChrt.Series["Stock"].Points.Clear();

                // Change chart title
                stockChrt.Titles.Add("Station Stock");

                // Use data inside of list to create chart
                foreach(object[] record in StockData)
                {
                    stockChrt.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    stockChrt.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                    stockChrt.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    stockChrt.Series["Stock"].Points.AddXY(record[0], record[1]);
                    if((int)record[1] < 5)
                    {
                        stockChrt.Series["Stock"].Points[x].Color = Color.Red;
                    }
                    x++;
                }
            }
            //}
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            // Create thread to begin drawing the stock levels
            Thread t = new Thread(ChartLoop);
            if(loop)
            {
                RunBtn.Text = "START";
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
                RunBtn.Text = "STOP";
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int x = 0;

            for(; ; )
            {
                if(worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Clear series data
                    stockChrt.Series["Stock"].Points.Clear();

                    // Change chart title
                    stockChrt.Titles.Add("Station Stock");

                    // Use data inside of list to create chart
                    foreach(object[] record in StockData)
                    {
                        stockChrt.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        stockChrt.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                        stockChrt.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                        stockChrt.Series["Stock"].Points.AddXY(record[0], record[1]);
                        if((int)record[1] < 5)
                        {
                            stockChrt.Series["Stock"].Points[x].Color = Color.Red;
                        }
                        x++;
                    }
                }
            }
        }
    }
}