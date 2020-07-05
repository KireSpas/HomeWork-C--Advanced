using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Db.Interfaces
{
    public interface IActivities
    {
        string GetInfo(User user);
    }
}
