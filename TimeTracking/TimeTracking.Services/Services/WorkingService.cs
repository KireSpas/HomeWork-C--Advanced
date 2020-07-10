using System;
using System.Collections.Generic;
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
    }
}
