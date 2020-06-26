using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TimeTracking.Db.Entities
{
    public class User : BaseEntitiy
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public Activities Activities { get; set; }

        public override string PrintInfo()
        {
            return $"{FirstName} {LastName} ({Age})";
        }
    }
}
