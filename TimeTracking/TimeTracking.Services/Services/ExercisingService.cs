using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;
using TimeTracking.Db.Enums;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class ExercisingService<T> : IActivitiesService<T> where T : Exercising
    {
        public IActivitiesDb<Exercising> _exercisingDb;

        public ExercisingService()
        {
            _exercisingDb = new ActivitiesDb<Exercising>();
        }

        public void DoActivity(T exercise)
        {
            exercise.Stopwatch.Start();
            MessageHelper.Color($"You have started exercising", ConsoleColor.Green);
            MessageHelper.Color("Press any key when you stop exercising", ConsoleColor.Yellow);


            Console.ReadLine();
            exercise.Stopwatch.Stop();
            MessageHelper.Color($"You have stoped exercising", ConsoleColor.Green);
        }


    }
}
