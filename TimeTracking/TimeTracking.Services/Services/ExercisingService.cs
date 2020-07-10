using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;
using TimeTracking.Db.Enums;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class ExercisingService<T> where T : Exercising
    {
        public IActivitiesDb<Exercising> _exercisingDb;

        public ExercisingService()
        {
            _exercisingDb = new ActivitiesDb<Exercising>();
        }

        public void InsertExercise(Exercising exercise)
        {
            _exercisingDb.InsertActivity(exercise);
        }

        public List<Exercising> GetAllExercises()
        {
            return _exercisingDb.GetAllActivities();
        }
        
    }
}
