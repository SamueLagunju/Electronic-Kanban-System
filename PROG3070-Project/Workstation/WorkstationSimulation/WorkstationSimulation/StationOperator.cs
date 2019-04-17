using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

/*
* FILE:			StationOperator
* PROJECT:		WorkstationSimulation
* PROGRAMMER:	Oloruntoba Lagunju.
* DATE:			Apri 1st 2019
* DESCRIPTION:	Contains the main entry point to operate the workstation
*/

namespace WorkstationSimulation
{
    class WorkstationOperator
    {
        //Connection string used to connect the database
        static string connString = "Server= localhost; Initial Catalog=Kanban; Integrated Security=SSPI;";
        static void Main(string[] args)
        {
            bool runningStatus = true;  //Variable to keep track of the operation
            //Variable used to obtain the user's input
            int workStationIDBuffer = 0; string experienceBuffer = ""; int experienceLevel = 0;

            //If the connection to the database failed, close the application.
            if (!TestConnection()) { Console.WriteLine("Could not connect to database! Try Again!"); Environment.Exit(0); }

            //While loop to keep running until the user's input has been determined valid
            while(runningStatus)
            {
                try
                {
                    //Obtaning a workstation ID used to identify the workstation
                    Console.Write("Please input StationID: ");
                    workStationIDBuffer = Convert.ToInt32(Console.ReadLine());

                    while(runningStatus)
                    {
                        //Obtainined the experience level of the workstation
                        Console.WriteLine("1. New/Rookie");
                        Console.WriteLine("2. Experienced");
                        Console.WriteLine("3. Very Experienced");
                        Console.Write("Pick one of the experiences: ");
                        int userChoice = Convert.ToInt32(Console.ReadLine());

                        //Switch statement to set the experienceBuffer to the user's input
                        switch(userChoice)
                        {
                            case 1:
                                experienceBuffer = "New/Rookie";
                                experienceLevel = 1;
                                runningStatus = false;
                                break;
                            case 2:
                                experienceBuffer = "Experienced";
                                experienceLevel = 2;
                                runningStatus = false;
                                break;
                            case 3:
                                experienceBuffer = "Very Experienced";
                                experienceLevel = 3;
                                runningStatus = false;
                                break;
                            default:
                                Console.WriteLine("Invalid Input!");
                                break;
                        }
                    }

                }
                catch (Exception ExceptionError) { Console.WriteLine(ExceptionError.Message); }
            }

            //Instantiating a new workstation with the user's input
            WorkStation newStation = new WorkStation(workStationIDBuffer, experienceBuffer, experienceLevel); runningStatus = true;

            while (runningStatus)
            {
                //If the stored procedure did not work again, obtain a new ID 
                if (!RunInsertStoredProcedure(newStation))
                {
                    try
                    {
                        Console.WriteLine("Workstation currently active!");
                        Console.Write("Please input a new StationID: ");
                        newStation.SetWorkStationID(Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception exceptError)
                    {
                        Console.WriteLine(exceptError.Message);
                    }
                }

                else { runningStatus = false; }
            }

            runningStatus = true; Console.Clear();

            while (runningStatus)
            {
                //Displaying the details of the newly instantiated workstation
                newStation.DisplayDetails();

                try
                {
                    Console.WriteLine("Press 0 to quit the program ");
                    Console.WriteLine("Press 1 to start the simulation");
                    Console.WriteLine("Press 2 to stop the simulation");
                    Console.Write("Select An Option: ");
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    switch(userInput)
                    {
                        case 0:
                            runningStatus = false;
                            break;
                        case 1:
                            newStation.SimulationOperation();
                            break;
                        case 2:
                            newStation.SetWorkStationStatus(false);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }

                }
                catch (Exception ExceptionError) { Console.WriteLine(ExceptionError.Message); }
            }



        }

        /*
        * Function		:   TestConnection()
        * Description	:   Checks the connection between the form and SQL database.
        * Parameters	:   N/A
        * Returns		:   status - Bool value that indicates if it was successful/unsucessful
        */
        static bool TestConnection()
        {
            bool status;       
            SqlConnection sqlConnToServer = new SqlConnection(connString);   //Creatinng a connectiong
            try
            {
                sqlConnToServer.Open();  //Opening the connection to the database
                status = true;  //If no exception is thrown, set status to true
                sqlConnToServer.Close(); //Close the connection
            }
            //If any exception was thrown, set status to false
            catch (Exception exceptError) { Console.WriteLine(exceptError.Message); status = false; }
            return status;
        }

        /*  
        * Function		:   bool RunInsertStoredProcedure(WorkStation workStation)
        * Description	:   Runs the instanties_station procedure 
        *                   Based on the results, it creates a new workstation simulation in the database
        *                   or asks for another stationID that is currently not in use 
        * Parameters	:   workStation -   WorkStation
        * Returns		:   status      -   bool
        */
        static bool RunInsertStoredProcedure(WorkStation workStation)
        {
            bool status = true;
            //Ensuring the sqlConnection variable is disposed correctly
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                try
                {
                    sqlConnection.Open();   //Opening connection to the sql database
                    //Creating a stored procedure command
                    SqlCommand sqlCommand = new SqlCommand("instantiate_station", sqlConnection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    //Adding the workstation details as the stored procedure parameters
                    sqlCommand.Parameters.AddWithValue("@StationNumber", workStation.GetWorkStationID());
                    sqlCommand.Parameters.AddWithValue("@Experience", workStation.GetWorkStationExperience());
                    sqlCommand.Parameters.AddWithValue("@DefectRate", workStation.GetWorkStationDefectRate());
                    sqlCommand.Parameters.AddWithValue("@Speed", workStation.GetWorkStationSpeed());
                    sqlCommand.Parameters.AddWithValue("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //Executing the stored procedure query
                    sqlCommand.ExecuteNonQuery();
                    int queryResult = Convert.ToInt32(sqlCommand.Parameters["@Result"].Value);  //Getting the result back from the stored procedure
                    //If there was an error, report back to where the function was called from
                    if (!(queryResult > 0)) { status = false; }
                }
                //If there was an error, let the user know and report back to where the function was called from
                catch (Exception ExceptionError) { Console.WriteLine(ExceptionError.Message); status = false; }

            }
            return status;
        }
    }
}
