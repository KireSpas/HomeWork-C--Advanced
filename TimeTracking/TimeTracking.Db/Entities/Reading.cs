using System.Linq;
using System.Runtime.CompilerServices;
using TimeTracking.Db.Enums;
using TimeTracking.Db.Interfaces;

namespace TimeTracking.Db.Entities
{
    public class Reading : BaseActivities , IActivities
    {
        public int Pages { get; set; }
        public ReadingType Type { get; set; }

        public string GetInfo(User user)
        {
            return $"{user.FirstName} read {Pages} pages from the {Type} for {StopwatchTimeToString(Stopwatch)}";
        }
    }
}