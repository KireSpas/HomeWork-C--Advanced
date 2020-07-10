using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Db.DataBase
{
    public interface IActivitiesDb<T> where T: BaseActivities
    {
        List<T> GetAllActivities();
        T GetById(int id);
        void InsertActivity(T activity);
    }
}
