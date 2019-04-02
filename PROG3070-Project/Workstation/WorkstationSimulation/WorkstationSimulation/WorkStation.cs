using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WorkstationSimulation
{
    class WorkStation
    {
        private int workStationID;
        private string experience;
        private float defectRate;
        private float speed;
        private bool activeStatus;
        public string isActive;

        public WorkStation(int stationIDBuffer, string experienceBuffer, int experienceLevel)
        {
            this.workStationID = stationIDBuffer;
            switch(experienceLevel)
            {
                case 1:
                    this.experience = experienceBuffer;
                    this.defectRate = (float)0.85;
                    this.speed = (float)(GetTimeScale() * 1.5 * GenerateRandomNumber(0.9, 1.1));
                    break;
                case 2:
                    this.experience = experienceBuffer;
                    this.defectRate = (float)0.5;
                    this.speed = (float)(GetTimeScale() * GenerateRandomNumber(0.9, 1.1));
                    break;
                case 3:
                    this.experience = experienceBuffer;
                    this.defectRate = (float)0.15;
                    this.speed = (float)(GetTimeScale() * 0.85 *GenerateRandomNumber(0.9, 1.1));
                    break;
            }
        }

        /*
        * Function		:   GetTimeScale()
        * Description	:   Acquires the Time Scale value from the Configuration tableS
        * Parameters	:   N/A
        * Returns		:   TimeScaleBuffer - int
        */
        public int GetTimeScale()
        {

            string connString = "Server= localhost; Initial Catalog=Kanban System Data; Integrated Security=SSPI;"; //Connection string to connect to the database
            string commandString = "SELECT [Value] FROM [Configuration] WHERE [ITEM] = 'TimeScale'" ;   //Query string 
            int timeScaleBuffer;    //Value to be assigned from the database query

            using (SqlConnection tempConnection = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandString, tempConnection);

                try
                {
                    tempConnection.Open();
                    timeScaleBuffer = Convert.ToInt32(sqlCommand.ExecuteScalar());  
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    timeScaleBuffer = 60;   //Default value from the requirements page
                }
            }

            return timeScaleBuffer;
        }

        //From https://stackoverflow.com/questions/17786771/random-double-between-given-numbers
        public double GenerateRandomNumber(double minValue, double maxValue)
        {
            Random randomNumer = new Random();
            double randomValue = randomNumer.NextDouble();

            return minValue + (randomValue * (maxValue - minValue));
        }

        //Getters
        public int GetWorkStationID() { return this.workStationID; }
        public string GetWorkStationExperience() { return this.experience; }
        public float GetWorkStationDefectRate() { return this.defectRate; }
        public float GetWorkStationSpeed() { return this.speed; }
        public bool GetActiveStatus() { return this.activeStatus; }

        //Setters
        public void SetWorkStationID(int newStationID) { this.workStationID = newStationID; }
        public void SetWorkStationExperience(string newStationExperience) { this.experience = newStationExperience; }
        public void SetWorkStationDefectRate(float newDefectRate) { this.defectRate = newDefectRate; }
        public void SetWorkStationSpeed(float newStationSpeed) { this.speed = newStationSpeed; }
        public void SetWorkStationStatus(bool newStatus)
        {
            if (newStatus) { this.isActive = "Yes"; }
            else { this.isActive = "No"; }
        }


        public void SimulationOperation()
        {
            bool runningStatus = true;
            while(runningStatus)
            {
                Console.WriteLine("Hello");
                this.activeStatus = true;
                runningStatus = false;
            }

        }

        public void DisplayDetails()
        {
            Console.Clear();
            Console.WriteLine("Workstation #" + this.GetWorkStationID());
            Console.WriteLine("Experience: " + this.GetWorkStationExperience());
            Console.WriteLine("Defect Rate: " + this.GetWorkStationDefectRate());
            Console.WriteLine("Speed: " + this.GetWorkStationSpeed());
            Console.WriteLine("Active: " + this.isActive.ToString());

        }
    }
}
