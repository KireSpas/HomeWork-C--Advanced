using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public interface IActivitiesService<T> where T : BaseActivities
    {
        void DoActivity(T activity);
    }
}
