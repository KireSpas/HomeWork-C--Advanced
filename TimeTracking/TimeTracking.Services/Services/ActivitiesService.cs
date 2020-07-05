using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class ActivitiesService<T> : IActivitiesService<T> where T : BaseActivities
    {
        private ActivitiesDb<Reading> _readingDb;
        private ActivitiesDb<Working> _workingDb;
        public ActivitiesDb<Exercising> _exercisingDb;
        public ActivitiesDb<OtherHobbies> _otherHobbiesDb;
        public IActivitiesDb<T> _db;
        public ActivitiesService()
        {
            _db = new ActivitiesDb<T>();
            _readingDb = new ActivitiesDb<Reading>();
            _workingDb = new ActivitiesDb<Working>();
            _exercisingDb = new ActivitiesDb<Exercising>();
            _otherHobbiesDb = new ActivitiesDb<OtherHobbies>();

        }
        
        
        public T EndActivity(T user)
        {
            throw new NotImplementedException();
        }

        public void StartActivity(T user)
        {
            throw new NotImplementedException();
        }
    }
}
