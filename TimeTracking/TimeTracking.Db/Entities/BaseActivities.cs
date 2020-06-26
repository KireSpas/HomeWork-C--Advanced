using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TimeTracking.Db.Entities
{
    public class BaseActivities
    {
        public Stopwatch Statistic { get; set; }

        public string StopwatchTimeToString(Stopwatch stopwatch)
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            return $"{timeSpan.Minutes}minutes and {timeSpan.Seconds}seconds";
        }

        public string ShowStatistics()
        {
            return StopwatchTimeToString(Statistic);
        }
    }
}
