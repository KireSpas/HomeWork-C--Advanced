using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TimeTracking.Db.Entities
{
    public class BaseActivities
    {
        public int Id { get; set; }
        public Stopwatch Stopwatch { get; set; }

        public double StopwatchSeconds(Stopwatch stopwatch)
        {
            return stopwatch.Elapsed.TotalSeconds;
        }

        public string StopwatchTimeToString(Stopwatch stopwatch)
        {
            return $"Your time for the actibity was {stopwatch.Elapsed.Minutes}minutes and {stopwatch.Elapsed.Seconds}seconds";
        }

    }
}
