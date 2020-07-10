using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TimeTracking.Services.Services
{
    public interface IActivitiesService
    {
        Stopwatch ActivityTime(string name);
    }
}
