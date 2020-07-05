using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TimeTracking.Db.Entities
{
    public class BaseActivities
    {
        public int Id { get; set; }
        public Stopwatch Statistic { get; set; }
        public Stopwatch Stopwatch { get; set; }

        public string StopwatchTimeToString(Stopwatch stopwatch)
        {
            TimeSpan timeSpan = Stopwatch.Elapsed;
            return $"{timeSpan.Minutes}minutes and {timeSpan.Seconds}seconds";
        }

        public string ShowStatistics()
        {
            return $"Your statistics: { StopwatchTimeToString(Statistic)}";
        }
    }
}
