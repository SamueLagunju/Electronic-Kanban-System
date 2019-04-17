using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

/*
* FILE:			Form1.cs
* PROJECT:		ConfigTool
* PROGRAMMER:	Oloruntoba Lagunju.
* DATE:			March 27th 2019
* DESCRIPTION:	Contains code needed to edit and update the Config Table's keys and values in a SQL database.
*/

namespace ConfigTool
{
    
/*
*	Class		:	Form1
*	Description	:	Abstract representation of a windows forms
*/
    public partial class Form1 : Form
    {
        public string connString;               //Contains the connection string needed to connect to the database
        public SqlDataAdapter dataAdapter;      //Variable to get the data from the source into the dataSet
        public SqlConnection sqlConnToServer;   //Needed to connect to the SQL Server database
        public DataSet databaseDataSet;         //Represents a complete set of data including the table

        public Form1()
        {
            InitializeComponent();
        }

        /*
        * Function		:   Form1_Load(object sender, EventArgs e)
        * Description	:   Inspects the connection with the SQL Server 
        *                   If appropriate, fill the data grid with the SQL table information
        *                   as soon as the form loads. 
        * Parameters	:   object      sender
        *                   EventArgs   e
        * Returns		:   N/A
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            //If testing the SQL connection was succesful, fill the datagrid
            if (TestConnection())
            {
                FillDataGrid();
            }
            //Close application if SQL connection was unsuccessful.
            else { Application.Exit(); }
        }

        /*
        * Function		:   TestConnection()
        * Description	:   Checks the connection between the form and SQL database.
        * Parameters	:   N/A
        * Returns		:   status - Bool value that indicates if it was successful/unsucessful
        */
        private bool TestConnection()
        {
            bool status;
            connString = "Server= localhost; Initial Catalog=Kanban System Data; Integrated Security=SSPI;";
            sqlConnToServer = new SqlConnection(connString);   //Creatinng a connectiong
            try
            {
                sqlConnToServer.Open();  //Opening the connection to the database
                status = true;  //If no exception is thrown, set status to true
                sqlConnToServer.Close(); //Close the connection
            }
            //If any exception was thrown, set status to false
            catch (Exception exceptError) {
                MessageBox.Show("An error occured: " + exceptError.ToString(), "Error", MessageBoxButtons.OK);
                status = false;
            }
            return status;
        }

        /*
        * Function		:   FillDataGrid()
        * Description	:   Fills the data grid from the System Config Table in the SQL database
        * Parameters	:   N/A
        * Returns		:   N/A
        */
        public void FillDataGrid()
        {
            //SQL command to obtain the table values
            string sqlCommand = "SELECT DISTINCT [Item], [Value] FROM [Kanban System Data].[dbo].[Configuration]";


            SqlConnection connection = new SqlConnection(connString);   //Creatinng a connectiong

            try
            {
                //Data adapter to obtain data from the source
                dataAdapter = new SqlDataAdapter(sqlCommand, connection);
                //Generating a single table command used to reconcile changes made to a DataSet with the SQL database
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
                databaseDataSet = new DataSet();    //Collection of DataTables
                dataAdapter.Fill(databaseDataSet);  //Adding rows in the DataSet to match those in the data source
                dataGridDisplay.DataSource = databaseDataSet.Tables[0];   //Adding the infomration from the dataset to the datagrid
            }

            catch (Exception exceptError) { MessageBox.Show("An error occured: " + exceptError.ToString(), "Error", MessageBoxButtons.OK); }
        }
        

        /*
        * Function		:   RefreshBtn_Click(object sender, EventArgs e)
        * Description	:   Refreshes the updated data in the datagrid
        * Parameters	:   object      sender
        *                   EventArgs   e
        * Returns		:   N/A
        */
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FillDataGrid(); 
        }

        /*
        * Function		:   UpdateBtn_Click(object sender, EventArgs e)
        * Description	:   Updates the content in the database with the user's input
        * Parameters	:   object      sender
        *                   EventArgs   e
        * Returns		:   N/A
        */
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //If the text boxes aren't empty, then proceed
                if ((categoryTxtBox.Text != "") && (valueTxtBox.Text != ""))
                {
                    //Creating a connection to the database
                    SqlConnection connection = new SqlConnection(connString);
                    connection.Open();  //Opening the connection
                    //SQL command used to update the relevant information with the user's input
                    SqlCommand sqlCommand = new SqlCommand("Update [Configuration] SET Value = @UpdatingValue Where Item = @ExistingItem", connection);

                    //sqlCommand = new SqlCommand("Update [Configuration] set [Value]=@newValue WHERE Item = @ExitingItem", connection);
                    sqlCommand.Parameters.AddWithValue("@UpdatingValue", valueTxtBox.Text.ToString());   //Adding the value from the value text box
                    sqlCommand.Parameters.AddWithValue("@ExistingItem", categoryTxtBox.Text.ToString());   //Adding the value from the value text box

                    if (sqlCommand.ExecuteNonQuery() > 0) { MessageBox.Show("Update Successful!", "Alert", MessageBoxButtons.OK); }

                    //sqlCommand.Parameters.AddWithValue("@newValue", valueTxtBox.Text.ToString());   //Adding the value from the value text box
                    //If the ExecuteNonQuery returned 1, then go ahead and insert the new data
                    //if (sqlCommand.ExecuteNonQuery() > 0) {
                    //    sqlCommand = new SqlCommand("Insert into [Configuration] (Item, Value)" +
                    //                                        " Values (@newItem, @newValue)", connection);
                    //    sqlCommand.Parameters.AddWithValue("@newItem", categoryTxtBox.Text.ToString()); //Adding the value from the category text box
                    //    sqlCommand.Parameters.AddWithValue("@newValue", valueTxtBox.Text.ToString());   //Adding the value from the value text box

                    //    if (sqlCommand.ExecuteNonQuery() > 0) { MessageBox.Show("Update Successful!", "Alert", MessageBoxButtons.OK); }
                    //}

                    connection.Close(); //Closing the connection
                }

                else { MessageBox.Show("Error! Input Invalid", "Input Error", MessageBoxButtons.OK); }
            }
            //Catch all for anything error that might happen
            catch (Exception exceptError) { MessageBox.Show("An error occured: " + exceptError.ToString(), "Error", MessageBoxButtons.OK); }
        }

        /*
        * Function		:   InsertBtn_Click(object sender, EventArgs e)
        * Description	:   Inserts new content in the database with the user's input
        * Parameters	:   object      sender
        *                   EventArgs   e
        * Returns		:   N/A
        */
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //If the text boxes aren't empty, then proceed
                if ((categoryTxtBox.Text != "") && (valueTxtBox.Text != ""))
                {
                    //Creating a connection to the database
                    SqlConnection connection = new SqlConnection(connString);
                    connection.Open();  //Opening the connection
                    //SQL query string used to insert the relevant information with the user's input
                    SqlCommand sqlCommand = new SqlCommand("Insert into [Configuration] (Item, Value)" +
                                                            " Values (@newItem, @newValue)", connection);
                    sqlCommand.Parameters.AddWithValue("@newItem", categoryTxtBox.Text.ToString()); //Adding the value from the category text box
                    sqlCommand.Parameters.AddWithValue("@newValue", valueTxtBox.Text.ToString());   //Adding the value from the value text box
                    //If the ExecuteNonQuery returned 1, then it succeded with updating the SQL database
                    if (sqlCommand.ExecuteNonQuery() > 0) { MessageBox.Show("Insert Successful!", "Alert", MessageBoxButtons.OK); }

                    connection.Close(); //Closing the connection
                }

                else { MessageBox.Show("Error! Input Invalid", "Input Error", MessageBoxButtons.OK); }
            }
            catch (Exception exceptError) { MessageBox.Show("An error occured: " + exceptError.ToString(), "Error", MessageBoxButtons.OK); }

        }

        /*
        * Function		:   DeleteBtn_Click(object sender, EventArgs e)
        * Description	:   Deletes existing content in the database with the user's input
        * Parameters	:   object      sender
        *                   EventArgs   e
        * Returns		:   N/A
        */
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //If the text boxes aren't empty, then proceed
                if ((categoryTxtBox.Text != "") && (valueTxtBox.Text != ""))
                {
                    //Creating a connection to the database
                    SqlConnection connection = new SqlConnection(connString);
                    connection.Open();  //Opening the connection
                    //SQL command used to update the relevant information with the user's input
                    SqlCommand sqlCommand = new SqlCommand("Delete from [Configuration] where Item = @ExistingItem", connection);

                    //sqlCommand = new SqlCommand("Update [Configuration] set [Value]=@newValue WHERE Item = @ExitingItem", connection);
                    sqlCommand.Parameters.AddWithValue("@ExistingItem", categoryTxtBox.Text.ToString());   //Adding the value from the value text box
                    //sqlCommand.Parameters.AddWithValue("@newValue", valueTxtBox.Text.ToString());   //Adding the value from the value text box
                    //If the ExecuteNonQuery returned 1, then go ahead and insert the new data
                    if (sqlCommand.ExecuteNonQuery() > 0) { MessageBox.Show("Delete Successful!", "Alert", MessageBoxButtons.OK); }

                    connection.Close(); //Closing the connection
                }

                else { MessageBox.Show("Error! Input Invalid", "Input Error", MessageBoxButtons.OK); }
            }
            //Catch all for anything error that might happen
            catch (Exception exceptError) { MessageBox.Show("An error occured: " + exceptError.ToString(), "Error", MessageBoxButtons.OK); }
        }
    }


}
