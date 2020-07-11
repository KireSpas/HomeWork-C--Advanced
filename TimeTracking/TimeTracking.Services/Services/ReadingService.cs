using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class ReadingService<T> where T : Reading
    {
        public IActivitiesDb<Reading> _readingDb;
        public ReadingService()
        {
            _readingDb = new ActivitiesDb<Reading>();
        }

        public void InsertReading(Reading reading)
        {
            _readingDb.InsertActivity(reading);
        }

        public List<Reading> GetAllExercises()
        {
            return _readingDb.GetAllActivities();
        }

        public void Statistics()
        {
            var listOfReadings = _readingDb.GetAllActivities();
            int totalTimeInSeconds = 0;
            int totalPages = 0;
            int bellesLettresType = 0;
            int fictionType = 0;
            int proffesionalLiteratureType = 0;

            for (int i = 0; i < listOfReadings.Count; i++)
            {
                totalTimeInSeconds += listOfReadings[i].Stopwatch.Elapsed.Seconds;
                totalPages += listOfReadings[i].Pages;
                if (listOfReadings[i].Type.ToString().ToLower() == "BellesLettres".ToLower())
                {
                    bellesLettresType++;
                }
                else if(listOfReadings[i].Type.ToString().ToLower() == "Fiction".ToLower())
                {
                    fictionType++;
                }
                else
                {
                    proffesionalLiteratureType++;
                }
            }

            if(listOfReadings.Count != 0)
            {
                Console.WriteLine($"Total time: {totalTimeInSeconds}seconds");
                Console.WriteLine($"Average time: {totalTimeInSeconds / listOfReadings.Count}seconds");
                Console.WriteLine($"Total number of pages: {totalPages} pages");

                int mostUsedType = new List<int> { bellesLettresType, proffesionalLiteratureType, proffesionalLiteratureType }.Max();
                if (mostUsedType == bellesLettresType)
                {
                    Console.WriteLine("Favorite type: Belles Lettres");
                }
                else if (mostUsedType == proffesionalLiteratureType)
                {
                    Console.WriteLine("Favorite type: Proffecional Literature");
                }
                else if (mostUsedType == fictionType)
                {
                    Console.WriteLine("Favorite type: Fiction");
                }
            }
            else
            {
                Console.WriteLine("You haven't read anything yet");
            }
        }

        public int TotalSeconds()
        {
            var listOfReadings = _readingDb.GetAllActivities();
            int result = 0;
            foreach (var item in listOfReadings)
            {
                result += item.Stopwatch.Elapsed.Seconds;
            }
            return result;
        }

    }
}
