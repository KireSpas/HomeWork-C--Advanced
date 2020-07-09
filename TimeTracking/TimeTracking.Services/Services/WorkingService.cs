using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class WorkingService<T> : IActivitiesService<T> where T : BaseActivities
    {
        public IActivitiesDb<Working> _workingDb;

        public WorkingService()
        {
            _workingDb = new ActivitiesDb<Working>();
        }

        public void DoActivity(T activity)
        {
            throw new NotImplementedException();
        }
    }
}
