using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Db.DataBase
{
    public class ActivitiesDb<T> : IActivitiesDb<T> where T: BaseActivities
    {
        public int IdCount { get; set; }
        public List<T> activities;

        public ActivitiesDb()
        {
            activities = new List<T>();
            IdCount = 1;
        }

        public List<T> GetAllActivities()
        {
            return activities;
        }

        public T GetById(int id)
        {
            return activities.FirstOrDefault(x => x.Id == id);
        }
    }
}
