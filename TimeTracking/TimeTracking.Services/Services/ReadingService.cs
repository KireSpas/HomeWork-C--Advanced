using System;
using System.Collections.Generic;
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

    }
}
