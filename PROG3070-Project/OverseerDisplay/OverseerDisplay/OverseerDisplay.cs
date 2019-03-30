using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OverseerDisplay
{
    public partial class OverseerDisplay : Form
    {
        public OverseerDisplay()
        {
            InitializeComponent();
        }

        private void OverseerDisplay_Load(object sender, EventArgs e)
        {
            GridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
        }
    }
}