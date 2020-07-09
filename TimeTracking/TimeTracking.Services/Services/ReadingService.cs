using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class ReadingService<T> : IActivitiesService<T> where T : BaseActivities
    {
        public IActivitiesDb<Reading> _readingDb;
        public ReadingService()
        {
            _readingDb = new ActivitiesDb<Reading>();
        }

        public void DoActivity(T activity)
        {
            throw new NotImplementedException();
        }
    }
}
