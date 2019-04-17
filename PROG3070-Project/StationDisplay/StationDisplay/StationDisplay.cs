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

        private List<object> Stations;
        private List<object> StockData;

        private bool loop = false;

        // Method		: Class constructor
        // Description	: Intitializes the class
        // Parameters	: None
        // Returns		: None
        public StationDisplay()
        {
            // Initialize assets
            InitializeComponent();
            Stations = new List<object>();
            StockData = new List<object>();
            StockUpdater.WorkerSupportsCancellation = true;

            // Change form properties
            stockChrt.Titles.Add("Station Stock");
            stockChrt.ChartAreas["ChartArea1"].AxisX.Title = "Part";
            stockChrt.ChartAreas["ChartArea1"].AxisY.Title = "Current Stock";
        }

        // Method		: StationDisplay_Load
        // Description	: Prepares assets when form loads
        // Parameters	: Generic sender info
        // Returns		: None
        private void StationDisplay_Load(object sender, System.EventArgs e)
        {
            // When the form is loaded, populate the list of available stations
            string query = "SELECT DISTINCT Station FROM Station;";
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
            // Set selected station equal to selected item in list
            station = StationLst.SelectedIndex + 1;
        }

        // Method		: RunBtn_Click
        // Description	: Starts/Stops thread and updates button for control
        // Parameters	: Generic sender information
        // Returns		: None
        private void RunBtn_Click(object sender, EventArgs e)
        {
            // If the application is currently running an update loop
            if(loop)
            {
                // Shut it off and allow option to start
                RunBtn.Text = "START";
                StockUpdater.CancelAsync();
                loop = false;
            }
            else
            {
                // Turn it on and allow option to finish
                RunBtn.Text = "STOP";
                StockUpdater.RunWorkerAsync();
                loop = true;
            }
        }

        // Method		: StockUpdater_DoWork
        // Description	: Continually updates parent chart using revised stockdata
        // Parameters	: Sender information from parent thread
        // Returns		: None
        private void StockUpdater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Run endlessly, loop will be ended when thread is closed
            for(; ; )
            {
                // If the worker has been told to close, exit the thread
                if(StockUpdater.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                BackgroundWorker worker = sender as BackgroundWorker;

                // Update the query, including the current station number
                string query = "SELECT DISTINCT P.PartName, S.Stock FROM Stock S ";
                query += "JOIN Part P ON P.PartID = S.Part ";
                query += "WHERE S.Station = " + station;
                StockData = GetData(query); // Update StockData list with current data for selected station

                int x = 0; // Incrementing integer used to change color

                // Invoke to change parent thread form properties
                stockChrt.Invoke(new Action(() =>
                {
                    // Clear series data
                    stockChrt.Series["Stock"].Points.Clear();

                    // Use data inside of list to create chart
                    foreach(object[] record in StockData)
                    {
                        stockChrt.Series["Stock"].Points.AddXY(record[0], record[1]);
                        if((int)record[1] <= 5)
                        {
                            stockChrt.Series["Stock"].Points[x].Color = Color.Red;
                        }
                        x++;
                    }
                }
                ));

                // Delay
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}