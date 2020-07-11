using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class WorkingService<T> where T : Working
    {
        public IActivitiesDb<Working> _workingDb;

        public WorkingService()
        {
            _workingDb = new ActivitiesDb<Working>();
        }

        public void InsertWork(Working working)
        {
            _workingDb.InsertActivity(working);
        }

        public List<Working> GetAllExercises()
        {
            return _workingDb.GetAllActivities();
        }

        public void Statistics()
        {
            var listOfWorking = _workingDb.GetAllActivities();
            int totalTimeInSeconds = 0;
            int homeType = 0;
            int officeType = 0;
            
            for (int i = 0; i < listOfWorking.Count; i++)
            {
                totalTimeInSeconds += listOfWorking[i].Stopwatch.Elapsed.Seconds;
                if (listOfWorking[i].WorkingFrom.ToString().ToLower() == "Home".ToLower())
                {
                    homeType++;
                }
                else
                {
                    officeType++;
                }
            }

            if(listOfWorking.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds}seconds");
                Console.WriteLine($"Average time: {totalTimeInSeconds / listOfWorking.Count}seconds");
                int mostUsedType = new List<int> { homeType, officeType }.Max();
                if (mostUsedType == 0)
                {
                    Console.WriteLine("No favorite type. Please do some work first");
                }
                else
                {
                    if (mostUsedType == homeType)
                    {
                        Console.WriteLine("Favorite place: Home");
                    }
                    else if (mostUsedType == officeType)
                    {
                        Console.WriteLine("Favorite place: Office");
                    }
                }
            }
            else
            {
                Console.WriteLine("You haven't done any work yet");
            }
        }

        public int TotalSeconds()
        {
            var listOfReadings = _workingDb.GetAllActivities();
            int result = 0;
            foreach (var item in listOfReadings)
            {
                result += item.Stopwatch.Elapsed.Seconds;
            }
            return result;
        }
    }
}
