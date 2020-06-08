using Business.Library.Classes;
using DataBase;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Quizz.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();
            while (true)
            {
                var user = repository.StudentOrTeacherLogIn();
                if (user.Student != null)
                {
                    repository.Test(user.Student);
                }
                else if (user.Teacher != null)
                {
                    repository.AssigningStudentsInLists();
                    
                    //Display Finished Students
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Finished students: ");
                    foreach (var student in user.Teacher.FinishedStudents)
                    {
                        Console.WriteLine($"Name: {student.FullName} Grade: {student.Grade}");
                    }

                    //Display Unfinished Students
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unfinished Students: ");
                    foreach (var student in user.Teacher.UnFinishedStudents)
                    {
                        Console.WriteLine($"Name: {student.FullName}");
                    }

                    
                    Console.ResetColor();
                    Console.WriteLine("Press any key to log out");
                    Console.ReadLine();
                    Console.WriteLine(@"Logging you out");
                    Thread.Sleep(3000);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");

                }
                else
                {
                    Console.WriteLine("Wrong number selected");
                }
            }
        }
    }
}
