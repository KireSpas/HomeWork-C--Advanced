using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class OtherHobbiesService<T> where T : OtherHobbies
    {
        public IActivitiesDb<OtherHobbies> _otherHobbiesDb;

        public OtherHobbiesService()
        {
            _otherHobbiesDb = new ActivitiesDb<OtherHobbies>();
        }

        public void InsertOtherHobbies(OtherHobbies otherHobbie)
        {
            _otherHobbiesDb.InsertActivity(otherHobbie);
        }

        public List<OtherHobbies> GetAllExercises()
        {
            return _otherHobbiesDb.GetAllActivities();
        }

        public void Statistics()
        {
            var listOfOtherHobbies = _otherHobbiesDb.GetAllActivities();
            int totalTimeInSeconds = 0;
            List<string> nameOfHobbies = new List<string>();

            for (int i = 0; i < listOfOtherHobbies.Count; i++)
            {
                totalTimeInSeconds += listOfOtherHobbies[i].Stopwatch.Elapsed.Seconds;
                nameOfHobbies.Add(listOfOtherHobbies[i].Name + ",");
                
            }

            if(listOfOtherHobbies.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds}seconds");
                Console.WriteLine($"Average time: {totalTimeInSeconds / listOfOtherHobbies.Count}seconds");
                List<string> finalListWithHobbies = nameOfHobbies.Distinct().ToList();
                Console.Write($"Name of new Hobbies:");
                finalListWithHobbies.ForEach(i => Console.Write(i));
            }
            else
            {
                Console.WriteLine("You haven't done any hobby yet");
            }
        }

        public int TotalSeconds()
        {
            var listOfReadings = _otherHobbiesDb.GetAllActivities();
            int result = 0;
            foreach (var item in listOfReadings)
            {
                result += item.Stopwatch.Elapsed.Seconds;
            }
            return result;
        }
    }
}
