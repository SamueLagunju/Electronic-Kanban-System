﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


/*
* FILE:			WorkSTation.cs
* PROJECT:		WorkstationSimulation
* PROGRAMMER:	Oloruntoba Lagunju.
* DATE:			April 1st 2019
* DESCRIPTION:	This is an abstract representation of a workstation
*               and its simulation to build a fog lamp
*/

namespace WorkstationSimulation
{
    
/*
*	Class		:	WorkStation
*	Description	:	An abstract represention of simulation that supports
*	                a simple Kanban system
*/
    class WorkStation
    {
        private int workStationID;  //ID that identifies the workstation
        private string experience;  //Variable that determines if the workstation is New, Experienced, or Very Experienced
        private float defectRate;   //Percentage of output that fails to meet a quality target
        private float speed;        //How fast it takes to build a fog lamp 
        private bool activeStatus;  //Status that determines if the workstation is currently working or not
        public string isActive;     //Variable that determines if the workstation is currently working or not

        /*
        * Function		:   public WorkStation(int stationIDBuffer, string experienceBuffer, int experienceLevel)
        * Description	:   Constructor for the workstation. 
        *                   Based on the experience level, it creates either a New/Rookie, Experienced, or Very Experienced
        *                   workstation
        * Parameters	:   int     stationIDBuffer
        *                   string  experienceBuffer
        *                   int     experienceLevel
        * Returns		:   N/A
        */
        public WorkStation(int stationIDBuffer, string experienceBuffer, int experienceLevel)
        {
            this.workStationID = stationIDBuffer;   //Setting the workstation to the user's input
            //Based on the experience level, the defect rate and speed are calculated.
            switch(experienceLevel)
            {
                //If the experience level is New/Rookie
                case 1:
                    this.experience = experienceBuffer;  //Setting the experience to New/Rookie
                    this.defectRate = (float)0.85;       //Setting the defect rate to 85%
                    //Speed is calculated by multiplying the time scale by a random number between 0.9-1.1 and 1.5
                    this.speed = (float)(GetTimeScale() * 1.5 * GenerateRandomNumber(0.9, 1.1));
                    this.SetWorkStationStatus(false);   //Setting the workstation status to false
                    break;
                //If the experience level is Experienced/Normal
                case 2:
                    this.experience = experienceBuffer; //Setting the experience level to Normal
                    this.defectRate = (float)0.5;       //Setting the defect rate to 50%
                    //Speed is calcualted by multiplying the time scale by a random number between 0.9-1.1
                    this.speed = (float)(GetTimeScale() * GenerateRandomNumber(0.9, 1.1));
                    this.SetWorkStationStatus(false);   //Setting the workstation status to false
                    break;
                //If the experience level is Very Experienced
                case 3:
                    this.experience = experienceBuffer; //Setting the experience level to Very Experienced
                    this.defectRate = (float)0.15;  //Setting the defect rate to 15%
                    //Speed is calculated by multiplying the time scale by a random number between 0.9-1.1 and 0.85
                    this.speed = (float)(GetTimeScale() * 0.85 *GenerateRandomNumber(0.9, 1.1));
                    this.SetWorkStationStatus(false);   //Setting the active status to false
                    break;
            }
        }

        /*
        * Function		:   GetTimeScale()
        * Description	:   Acquires the Time Scale value from the Configuration table.
        * Parameters	:   N/A
        * Returns		:   TimeScaleBuffer - int
        */
        public int GetTimeScale()
        {
            //Connection string used to connect to the SQL server database
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString; //Connection string to connect to the database
            string commandString = "SELECT [Value] FROM [Configuration] WHERE [ITEM] = 'TimeScale'" ;   //Query string 
            int timeScaleBuffer;    //Value to be assigned from the database query

            using (SqlConnection tempConnection = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandString, tempConnection);  //Command use to execute the query to the system's database

                try
                {
                    tempConnection.Open();  //Opening the connection
                    //Converting the returned result to int and setting it to the timeScaleBuffer
                    timeScaleBuffer = Convert.ToInt32(sqlCommand.ExecuteScalar());  
                }
                //If there are any errors, set the timeScale to the default from the requirements page
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    timeScaleBuffer = 60;   //Default value from the requirements page
                }
            }
            return timeScaleBuffer;
        }

        /*
        * Function		:   GetOrderStatus()
        * Description	:   Acquires the Order value from the Configuration table.
        * Parameters	:   N/A
        * Returns		:   TimeScaleBuffer - int
        */
        static bool GetOrderStatus()
        {
            bool tableResult = true;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString; //Connection string to connect to the database
            string commandString = "SELECT [Value] FROM [Configuration] WHERE [ITEM] = 'Order'";   //Query string 
            int orderValueStatus;    //Value to be assigned from the database query

            using (SqlConnection tempConnection = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandString, tempConnection);  //Command use to execute the query to the system's database

                try
                {
                    tempConnection.Open();  //Opening a connection to the database
                    //Converting the returned value to an int and setting it to the orderValueStatus
                    orderValueStatus = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    //If the result is less than 1, set the result to false since there are no orders yet
                    if(!(orderValueStatus > 0)) { tableResult = false; Console.WriteLine("No orders!"); }
                }
                //If there are any errors, set the result to false for the program to retry again
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tableResult = false;
                }
            }
            return tableResult;
        }

        /*
        * Function		:   public double GenerateRandomNumber(double minValue, double maxValue)
        * Description	:   Generates a randoma value between the minimum value and the max value
        * Parameters	:   minValue    -   double
        *                   maxValue    -   double
        * Returns		:   The random number is returned
        * Source        :   The logic was obtained from https://stackoverflow.com/questions/17786771/random-double-between-given-numbers
        */
        public double GenerateRandomNumber(double minValue, double maxValue)
        {
            Random randomNumer = new Random();  //Generating a random variable
            double randomValue = randomNumer.NextDouble();
            return minValue + (randomValue * (maxValue - minValue));
        }

        //Getters
        public int GetWorkStationID() { return this.workStationID; }
        public string GetWorkStationExperience() { return this.experience; }
        public float GetWorkStationDefectRate() { return this.defectRate; }
        public float GetWorkStationSpeed() { return this.speed; }
        public bool GetWorkStationStatus() { return this.activeStatus; }

        //Setters
        public void SetWorkStationID(int newStationID) { this.workStationID = newStationID; }
        public void SetWorkStationExperience(string newStationExperience) { this.experience = newStationExperience; }
        public void SetWorkStationDefectRate(float newDefectRate) { this.defectRate = newDefectRate; }
        public void SetWorkStationSpeed(float newStationSpeed) { this.speed = newStationSpeed; }
        public void SetWorkStationStatus(bool newStatus)
        {
            if (newStatus) { this.isActive = "Yes"; this.activeStatus = newStatus; }
            else { this.isActive = "No"; this.activeStatus = newStatus; }

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString; //Connection string to connect to the database

            using (SqlConnection tempConnection = new SqlConnection(connString))
            {
                tempConnection.Open();  //Opening connection to the database
                                        //SQL command used to update the relevant information with the user's input
                SqlCommand sqlCommand = new SqlCommand("Update [Station] SET Active = @Status Where Station = @StationNumber", tempConnection);
                sqlCommand.Parameters.AddWithValue("@Status", Convert.ToInt32(this.GetWorkStationStatus()));   //Adding the value from workstation class
                sqlCommand.Parameters.AddWithValue("@StationNumber", this.GetWorkStationID());   //Adding the value from workstation class
                sqlCommand.ExecuteNonQuery();
            }
        }

        /*
        * Function		:   SimulationOperation
        * Description	:   Contains code to simulate the process of creating a fog lamp
        * Parameters	:   N/A
        * Returns		:   N/A
        */
        public void SimulationOperation()
        {
            Console.Clear(); DisplayDetails();
            bool runningStatus = true;  //Variable to keep the loop running
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString; //Connection string to connect to the database
            while (runningStatus & GetOrderStatus()) {
                Console.WriteLine("Lamp being assembled...");
                System.Threading.Thread.Sleep((int)this.GetWorkStationSpeed() * 1000);
                Console.WriteLine("Assembly Done! Adding Part...");
                //Ensuring the sqlConnection variable is disposed correctly
                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {
                    try
                    {
                        sqlConnection.Open();   //Opening connection to the sql database
                                                //Creating a stored procedure command
                        SqlCommand sqlCommand = new SqlCommand("workstation_update", sqlConnection)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
                        //Adding the workstation details as the stored procedure parameters
                        sqlCommand.Parameters.AddWithValue("@StationNumber", this.GetWorkStationID());
                        sqlCommand.Parameters.AddWithValue("@DefectRate", this.GetWorkStationDefectRate());
                        //Executing the stored procedure query
                        int queryResult = sqlCommand.ExecuteNonQuery();
                        //If anything went wrong with the stored procedure, turn off the workstation.
                        if (queryResult < 0) {
                            runningStatus = false;
                            SetWorkStationStatus(false);
                            Console.Clear();
                            Console.WriteLine("Could not complete procedure...Workstation turning off...");
                        }
                    }
                    //If there was an error, let the user know and report back to where the function was called from
                    catch (Exception ExceptionError) { Console.WriteLine(ExceptionError.Message); runningStatus = false; }
                }
            }
        }

        /*
        * Function		:   DisplayDetails()
        * Description	:   Displays current information about the workstation
        * Parameters	:   N/A
        * Returns		:   N/A
        */
        public void DisplayDetails()
        {
            Console.WriteLine("Workstation #" + this.GetWorkStationID());
            Console.WriteLine("Experience: " + this.GetWorkStationExperience());
            Console.WriteLine("Defect Rate: " + this.GetWorkStationDefectRate());
            Console.WriteLine("Speed: " + this.GetWorkStationSpeed());
            Console.WriteLine("Active: " + this.isActive.ToString());

        }
    }
}
