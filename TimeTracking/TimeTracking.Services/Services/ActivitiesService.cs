using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TimeTracking.Db.Entities;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class ActivitiesService: IActivitiesService
    {
		public Stopwatch ActivityTime(string name)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Console.WriteLine($"You have started your {name}");
			Console.WriteLine($"Press any key when you stop {name}");


			Console.ReadLine();
			stopwatch.Stop();
			Console.WriteLine($"You have stopped {name}");
			return stopwatch;
		}

		public int TotalActivityTime(List<int> list)
        {
			int result = 0;
            foreach (var item in list)
            {
				result += item;
            }
			return result;
        }
	}
}
