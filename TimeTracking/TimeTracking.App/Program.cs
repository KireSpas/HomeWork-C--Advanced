using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Threading;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Services;

namespace TimeTracking.App
{
    class Program
    {
        public static IUserService _userService = new UserService();
        public static IActivitiesService _activitiesService = new ActivitiesService();
        public static IMenus _menus = new Menus();
        public static ExercisingService<Exercising> _exercisingService = new ExercisingService<Exercising>();
        public static OtherHobbiesService<OtherHobbies> _otherHobbiesService = new OtherHobbiesService<OtherHobbies>();
        public static ReadingService<Reading> _readingService = new ReadingService<Reading>();
        public static WorkingService<Working> _workingService = new WorkingService<Working>();
        public static User _user;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int registerOrLoginChoise = _menus.LogInOrRegisterMenu();
                while (true)
                {
                    if (registerOrLoginChoise == 1)
                    {
                        _user = _userService.LogIn();
                        if (_user == null) Environment.Exit(0);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        _user = _userService.Register();
                        if (_user == null) continue;
                        break;
                    }
                }
                Console.Clear();
                bool mainMenu = true;
                while (mainMenu)
                {
                    switch (_menus.MainMenu())
                    {
                        case 1:
                            bool breakTrackMenu = true;
                            while (breakTrackMenu)
                            {
                                Console.Clear();
                                int trackMenuChoise = _menus.TrackMenu();
                                switch (trackMenuChoise)
                                {
                                    case 1:
                                        //Reading
                                        Reading reading = new Reading();
                                        reading.Stopwatch = _activitiesService.ActivityTime("reading");
                                        MessageHelper.Color("Please enter number of pages that you have read", ConsoleColor.Green);
                                        reading.Pages = ValidationHelper.ParsedNumber(Console.ReadLine());
                                        switch (_menus.ReadingMenu())
                                        {
                                            case 1:
                                                reading.Type = Db.Enums.ReadingType.BellesLettres;
                                                break;
                                            case 2:
                                                reading.Type = Db.Enums.ReadingType.Fiction;
                                                break;
                                            case 3:
                                                reading.Type = Db.Enums.ReadingType.ProfessionalLiterature;
                                                break;
                                        }
                                        _readingService.InsertReading(reading);

                                        MessageHelper.Color($"Mr.{_user.LastName} you have been reading for {reading.Stopwatch.Elapsed.Seconds} seconds and you read {reading.Pages} pages from the book that has genre {reading.Type}", ConsoleColor.Yellow);
                                        break;
                                    case 2:
                                        //Excercising
                                        Exercising exercise = new Exercising();
                                        exercise.Stopwatch = _activitiesService.ActivityTime("exercising");
                                        switch (_menus.ExerciseMenu())
                                        {
                                            case 1:
                                                exercise.ExcercisingType = Db.Enums.ExcercisingType.General;
                                                break;
                                            case 2:
                                                exercise.ExcercisingType = Db.Enums.ExcercisingType.Running;
                                                break;
                                            case 3:
                                                exercise.ExcercisingType = Db.Enums.ExcercisingType.Sport;
                                                break;
                                        }
                                        _exercisingService.InsertExercise(exercise);
                                        MessageHelper.Color($"Mr.{_user.LastName} you have been doing {exercise.ExcercisingType} exercise for {exercise.Stopwatch.Elapsed.Seconds}seconds", ConsoleColor.Yellow);
                                        break;
                                    case 3:
                                        //Working
                                        Working working = new Working();
                                        working.Stopwatch = _activitiesService.ActivityTime("working");
                                        switch (_menus.WorkingMenu())
                                        {
                                            case 1:
                                                working.WorkingFrom = Db.Enums.WorkingFrom.Office;
                                                break;
                                            case 2:
                                                working.WorkingFrom = Db.Enums.WorkingFrom.Home;
                                                break;
                                        }
                                        _workingService.InsertWork(working);
                                        MessageHelper.Color($"Mr.{_user.LastName} you have been working from {working.WorkingFrom} for {working.Stopwatch.Elapsed.Seconds} seconds", ConsoleColor.Yellow);
                                        break;
                                    case 4:
                                        //Other Hobbies
                                        OtherHobbies otherHobbie = new OtherHobbies();
                                        MessageHelper.Color("It's nice to try something new. What's the name of the new Hobby?", ConsoleColor.Green);
                                        otherHobbie.Name = Console.ReadLine();
                                        otherHobbie.Stopwatch = _activitiesService.ActivityTime(otherHobbie.Name);
                                        _otherHobbiesService.InsertOtherHobbies(otherHobbie);
                                        MessageHelper.Color($"Mr.{_user.LastName} you have been doing your new hobbie {otherHobbie.Name} for {otherHobbie.Stopwatch.Elapsed.Seconds} seconds", ConsoleColor.Yellow);
                                        break;
                                    case 5:
                                        MessageHelper.Color("Going back to Main Menu!", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        breakTrackMenu = false;
                                        break;
                                }
                            }
                            break;
                        case 2:
                            //Statistics
                            break;
                        case 3:
                            //Acc Mngmnt
                            break;
                        case 4:
                            _user = null;
                            MessageHelper.Color("Thank you for using our application! Have a good day!", ConsoleColor.Green);                            
                            mainMenu = false;
                            break;
                    }
                }


                
            }


        }
    }
}
