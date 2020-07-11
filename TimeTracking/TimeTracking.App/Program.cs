using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
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
                    Console.Clear();
                    switch (_menus.MainMenu())
                    {
                        case 1:
                            //Track time
                            bool breakTrackMenu = true;
                            while (breakTrackMenu)
                            {
                                Console.Clear();
                                switch (_menus.TrackMenu())
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
                                        Thread.Sleep(3000);
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
                                        Thread.Sleep(3000);
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
                                        Thread.Sleep(3000);
                                        break;
                                    case 4:
                                        //Other Hobbies
                                        OtherHobbies otherHobbie = new OtherHobbies();
                                        MessageHelper.Color("It's nice to try something new. What's the name of the new Hobby?", ConsoleColor.Green);
                                        otherHobbie.Name = Console.ReadLine();
                                        otherHobbie.Stopwatch = _activitiesService.ActivityTime(otherHobbie.Name);
                                        _otherHobbiesService.InsertOtherHobbies(otherHobbie);
                                        MessageHelper.Color($"Mr.{_user.LastName} you have been doing your new hobbie {otherHobbie.Name} for {otherHobbie.Stopwatch.Elapsed.Seconds} seconds", ConsoleColor.Yellow);
                                        Thread.Sleep(3000);
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
                            bool breakStatsMenu = true;
                            while (breakStatsMenu)
                            {
                                Console.Clear();
                                switch (_menus.StatsMenu())
                                {
                                    case 1:
                                        //Reading Stats
                                        _readingService.Statistics();
                                        MessageHelper.Color("Press any key to go back",ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 2:
                                        //Exercising stats
                                        _exercisingService.Statistics();
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        //Working stats
                                        _workingService.Statistics();
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 4:
                                        //OtherHobbies stats
                                        _otherHobbiesService.Statistics();
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 5:
                                        //Global stats
                                        List<int> globalList = new List<int>
                                        {
                                            _exercisingService.TotalSeconds(),
                                            _otherHobbiesService.TotalSeconds(),
                                            _readingService.TotalSeconds(),
                                            _workingService.TotalSeconds()
                                        };
                                        int favoriteActivity = globalList.Max();
                                        Console.WriteLine($"Total activity time: {_activitiesService.TotalActivityTime(globalList)}seconds");
                                        if (favoriteActivity != 0)
                                        {
                                            if (favoriteActivity == _exercisingService.TotalSeconds())
                                            {
                                                Console.WriteLine("Favorite activity: Exercise");
                                            }
                                            else if (favoriteActivity == _otherHobbiesService.TotalSeconds())
                                            {
                                                Console.WriteLine("Favorite activity: Hobbie");
                                            }
                                            else if(favoriteActivity == _readingService.TotalSeconds())
                                            {
                                                Console.WriteLine("Favorite activity: Reading");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Favorite activity: Working");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have favorite activity yet");
                                        }
                                        MessageHelper.Color("Press any key to go back", ConsoleColor.Red);
                                        Console.ReadLine();
                                        break;
                                    case 6:
                                        MessageHelper.Color("Going back to Main Menu!", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        breakStatsMenu = false;
                                        break;
                                }
                            }
                            break;
                        case 3:
                            //Acc Management
                            bool accMng = true;
                            while (accMng)
                            {
                                Console.Clear();
                                switch (_menus.AccManagement())
                                {
                                    case 1:
                                        //change password
                                        Console.Clear();
                                        Console.WriteLine($"Mr. {_user.LastName}, please enter new password");
                                        _userService.ChangePassword(_user.Id, _user.Password, Console.ReadLine());
                                        break;
                                    case 2:
                                        //change First and Last Name
                                        Console.Clear();
                                        Console.WriteLine("Please enter new First name");
                                        string firstName = Console.ReadLine();
                                        Console.WriteLine("Please enter new Last name");
                                        string lastName = Console.ReadLine();
                                        _userService.ChangeInfo(_user.Id, firstName, lastName);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        _userService.RemoveUser(_user.Id);
                                        Console.WriteLine("Deactivating the account. Thank you for using our service");
                                        Styles.Spiner();
                                        MessageHelper.Color("The account has been deactivated", ConsoleColor.Red);
                                        mainMenu = false;
                                        break;
                                    case 4:
                                        MessageHelper.Color("Going back to Main Menu!", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        accMng = false;
                                        break;
                                }
                            }
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
