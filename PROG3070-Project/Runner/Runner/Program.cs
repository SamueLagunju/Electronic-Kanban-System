//Filename      : Program.cs
//Project Name  : PROG3070-Project
//Programmer    : Gabriel Stewart
//Version Date  : 2019-04-17
//Description   : This is a simple console based timer application that will update stock every 5 minutes

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Runner
{
    // Class   	    : Program
    // Description	: Simple program to restock the stations
    // Programmer	: Gabriel Stewart 
    // Methods 	    : Main
    //                TimerCallback - Runs when timer has waited for specified amount of time
    class Program
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString;

        // Function		: Main
        // Description	: Creates the timer and begins execution
        // Sources      : https://stackoverflow.com/questions/7402146/cpu-friendly-infinite-loop
        // Parameters	: string[] args - Command line arguments
        // Returns		: None
        static void Main(string[] args)
        {
            // Create a IPC wait handle with a unique identifier.
            bool createdNew;
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "CF2D4313-33DE-489D-9721-6AFF69841DEA", out createdNew);
            var signaled = false;

            // If the handle was already there, inform the other process to exit itself.
            // Afterwards we'll also die.
            if(!createdNew)
            {
                waitHandle.Set();

                return;
            }

            // Start a another thread that does something every set amount of time
            Timer t = new Timer(TimerCallback, null, 0, 60000);

            // Wait if someone tells us to die or do every five seconds something else.
            do
            {
                signaled = waitHandle.WaitOne(TimeSpan.FromSeconds(5));
            } while(!signaled);

            Console.Write("Runner closing...");
        }

        // Function		: TimeCallBack
        // Description	: This is the method that the timer executes on a set delay
        // Programmer	: Gabriel Stewart
        // Parameters	: Object o
        // Returns		: None
        private static void TimerCallback(Object o)
        {
            Console.WriteLine("Updating Stock");

            // Establish connection to database
            using(SqlConnection con = new SqlConnection(constr))
            {
                // Execute command using query
                using(SqlCommand command = new SqlCommand("UPDATE Stock SET Stock = 60 WHERE Stock = 0", con))
                {
                    con.Open(); // Open connection
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
