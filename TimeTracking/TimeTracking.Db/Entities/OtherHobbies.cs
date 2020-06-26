using System.Linq;
using TimeTracking.Db.Interfaces;

namespace TimeTracking.Db.Entities
{
    public class OtherHobbies : BaseActivities, IActivities
    {
        public string Name { get; set; }


        public string GetInfo(User user)
        {
            return $"Today {user.FirstName} desided to try {user.Activities.OtherHobbies.Name} as a new hobby and was doing it for {StopwatchTimeToString(user.Stopwatch)}";
        }
    }
}