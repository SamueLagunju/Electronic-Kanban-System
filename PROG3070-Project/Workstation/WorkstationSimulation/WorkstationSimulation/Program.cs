using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WorkstationSimulation
{
    class Program
    {
        static string connString = "Server= localhost; Initial Catalog=Kanban System Data; Integrated Security=SSPI;";
        static void Main(string[] args)
        {
            bool runningStatus = true;
            int workStationIDBuffer = 0; string experienceBuffer = ""; int experienceLevel = 0;

            //If the connection to the database failed, close the application.
            if (!TestConnection()) { Environment.Exit(0); }

            //While loop to keep running until the user's input has been determined valid
            while(runningStatus)
            {
                try
                {
                    Console.Write("Please input StationID: ");
                    workStationIDBuffer = Convert.ToInt32(Console.ReadLine());

                    while(runningStatus)
                    {

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
                catch (Exception ExceptionError) { Console.WriteLine(ExceptionError.Message); ; }
            }

            WorkStation newStation = new WorkStation(workStationIDBuffer, experienceBuffer, experienceLevel); runningStatus = true;

            while(runningStatus)
            {
                if(!RunInsertStoredProcedure(newStation))
                {
                    try
                    {
                        Console.Write("Please input a new StationID: ");
                        newStation.SetWorkStationID(Convert.ToInt32(Console.ReadLine()));
                    }
                    catch(Exception exceptError)
                    {
                        Console.WriteLine(exceptError.Message);
                    }
                }

                else { runningStatus = false; }
            }

            runningStatus = true;

            while(runningStatus)
            {
                Console.Write("Press 1 to start the simulation: ");
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
            catch (Exception exceptError)
            {
                Console.WriteLine(exceptError.Message);
                status = false;
            }

            return status;
        }

        static bool RunInsertStoredProcedure(WorkStation workStation)
        {
            bool status = true;

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("InstantiateStation", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StationNumber", workStation.GetWorkStationID());
                sqlCommand.Parameters.AddWithValue("@Experience", workStation.GetWorkStationExperience());
                sqlCommand.Parameters.AddWithValue("@DefectRate", workStation.GetWorkStationDefectRate());
                sqlCommand.Parameters.AddWithValue("@Speed", workStation.GetWorkStationSpeed());


                var returnParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                sqlCommand.ExecuteNonQuery();
                int queryResult = (int) returnParameter.Value;
                if (!(queryResult > 0)) { status = false; }
            }

            return status;
        }
    }
}
