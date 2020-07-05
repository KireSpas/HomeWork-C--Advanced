using System.Diagnostics;
using System.Linq;
using TimeTracking.Db.Enums;
using TimeTracking.Db.Interfaces;

namespace TimeTracking.Db.Entities
{
    public class Working : BaseActivities, IActivities
    {
        public WorkingFrom WorkingFrom { get; set; }

        public string GetInfo(User user)
        {
            return $"{user.FirstName} was working from {WorkingFrom} for {StopwatchTimeToString(Stopwatch)}";
        }
    }
}