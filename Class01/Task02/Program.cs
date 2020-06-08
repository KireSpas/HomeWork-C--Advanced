using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {

            CheckDate();

            Console.WriteLine("Do you want do check another date? y/n");
            string answer = Console.ReadLine();
            if(answer == "y")
            {
                CheckDate();
            }
            else
            {
                Console.WriteLine("Bye");
            }

            

            Console.ReadLine();
        }


        public static void NotWorkingDay()
        {
            Console.WriteLine("Not a working day");
        }

        public static DateTime OnlyMonthAndDay(DateTime input)
        {
            return new DateTime(DateTime.Now.Year,input.Month, input.Day);
        }

        public static void CheckDate()
        {
            List<DateTime> listOfNotWorkingDays = new List<DateTime>();

            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 01, 01));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 01, 07));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 04, 20));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 05, 01));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 05, 25));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 08, 03));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 09, 08));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 10, 12));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 10, 23));
            listOfNotWorkingDays.Add(new DateTime(DateTime.Now.Year, 12, 08));


            Console.WriteLine("Enter a date in this format yyyy/MM/dd");
            string dateFromUser = Console.ReadLine();

            while (true)
            {
                if (DateTime.TryParse(dateFromUser, out DateTime parsedDate))
                {
                    DateTime parsedDateMouthAndDay = OnlyMonthAndDay(parsedDate);
                    var counter = listOfNotWorkingDays.FirstOrDefault(holiday => holiday == parsedDateMouthAndDay);
                    if (counter.Year != 0001)
                    {
                        Console.WriteLine("That day is a holiday");
                        break;
                    }

                    switch (parsedDate.DayOfWeek.ToString())
                    {
                        case "Saturday":
                            NotWorkingDay();
                            break;
                        case "Sunday":
                            NotWorkingDay();
                            break;
                        default:
                            Console.WriteLine("That day is a working day");
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date entered");
                    break;
                }
            }
        }
        
    }
}
