using System;
using System.Collections.Generic;
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
    }
}
