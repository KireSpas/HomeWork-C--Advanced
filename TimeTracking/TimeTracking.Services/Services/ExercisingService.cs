using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;
using TimeTracking.Db.Enums;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class ExercisingService<T> where T : Exercising
    {
        public IActivitiesDb<Exercising> _exercisingDb;

        public ExercisingService()
        {
            _exercisingDb = new ActivitiesDb<Exercising>();
        }

        public void InsertExercise(Exercising exercise)
        {
            _exercisingDb.InsertActivity(exercise);
        }

        public List<Exercising> GetAllExercises()
        {
            return _exercisingDb.GetAllActivities();
        }

        public void Statistics()
        {
            var listOfExercising = _exercisingDb.GetAllActivities();
            int totalTimeInSeconds = 0;
            int generalType = 0;
            int runningType = 0;
            int sportType = 0;

            for (int i = 0; i < listOfExercising.Count; i++)
            {
                totalTimeInSeconds += listOfExercising[i].Stopwatch.Elapsed.Seconds;
                if (listOfExercising[i].ExcercisingType.ToString().ToLower() == "General".ToLower())
                {
                    generalType++;
                }
                else if (listOfExercising[i].ExcercisingType.ToString().ToLower() == "Running".ToLower())
                {
                    runningType++;
                }
                else
                {
                    sportType++;
                }
            }

            if(listOfExercising.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds}seconds");
                Console.WriteLine($"Average time: {totalTimeInSeconds / listOfExercising.Count}seconds");
                int mostUsedType = new List<int> { generalType, runningType, sportType }.Max();
                if (mostUsedType == generalType)
                {
                    Console.WriteLine("Favorite type: General");
                }
                else if (mostUsedType == runningType)
                {
                    Console.WriteLine("Favorite type: Running");
                }
                else if (mostUsedType == sportType)
                {
                    Console.WriteLine("Favorite type: Sport");
                }
            }
            else
            {
                Console.WriteLine("You haven't done any exercise yet");
            }
        }

        public int TotalSeconds()
        {
            var listOfReadings = _exercisingDb.GetAllActivities();
            int result = 0;
            foreach (var item in listOfReadings)
            {
                result += item.Stopwatch.Elapsed.Seconds;
            }
            return result;
        }

    }
}
