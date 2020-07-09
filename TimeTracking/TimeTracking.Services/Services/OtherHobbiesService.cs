using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public class OtherHobbiesService<T> : IActivitiesService<T> where T : BaseActivities
    {
        public IActivitiesDb<OtherHobbies> _otherHobbiesDb;

        public OtherHobbiesService()
        {
            _otherHobbiesDb = new ActivitiesDb<OtherHobbies>();
        }

        public void DoActivity(T activity)
        {
            throw new NotImplementedException();
        }
    }
}
