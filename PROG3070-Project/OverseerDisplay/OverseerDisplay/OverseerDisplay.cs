using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

//Filename      :
//Project Name  :
//Programmer    : Gabriel Stewart
//Version Date  :
//Description   :
//Sources		:

namespace OverseerDisplay
{
    public partial class OverseerDisplay : Form
    {
        private bool loop = false;
        private List<object> SummaryData;

        public OverseerDisplay()
        {
            InitializeComponent();
            SummaryUpdater.WorkerSupportsCancellation = true;
        }

        private void OverseerDisplay_Load(object sender, EventArgs e)
        {
            GridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                SummaryUpdater.CancelAsync();
                loop = false;
            }
            else
            {
                // Turn it on and allow option to finish
                RunBtn.Text = "STOP";
                SummaryUpdater.RunWorkerAsync();
                loop = true;
            }
        }

        private void SummaryUpdater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Run endlessly, loop will be ended when thread is closed
            for(; ; )
            {
                // If the worker has been told to close, exit the thread
                if(SummaryUpdater.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                BackgroundWorker worker = sender as BackgroundWorker;

                // Update the query, including the current station number
                string query = "SELECT DISTINCT P.PartName, S.Stock FROM Stock S ";
                query += "JOIN Part P ON P.PartID = S.Part ";
                SummaryData = GetData(query); // Update StockData list with current data for selected station

                int x = 0; // Incrementing integer used to change color

                // Invoke to change parent thread form properties
                GridView.Invoke(new Action(() =>
                {
                    // Use data inside of list to create chart
                    foreach(object[] record in SummaryData)
                    {
                        stockChrt.Series["Stock"].Points.AddXY(record[0], record[1]);
                        if((int)record[1] < 5)
                        {
                            stockChrt.Series["Stock"].Points[x].Color = Color.Red;
                        }
                        x++;
                    }
                }
                ));
            }
        }
    }
}