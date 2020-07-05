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
        public static IMenus _menus = new Menus();
        public static IActivitiesService<Activities> activitiesService = new ActivitiesService<Activities>();
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
                        if (_user == null)
                        {
                            Environment.Exit(0);
                        }
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
                bool breakMainMenu = true;
                while (breakMainMenu)
                {
                    int mainMenuChoise = _menus.MainMenu();
                    switch (mainMenuChoise)
                    {
                        case 1:
                            
                            
                            //Reading
                            break;
                        case 2:
                            //Excercising
                            break;
                        case 3:
                            //Working
                            break;
                        case 4:
                            //Other Hobbies
                            break;
                        case 5:
                            _user = null;
                            MessageHelper.Color("Thank you for using our service. Have a good day!",ConsoleColor.Green);
                            Thread.Sleep(3000);
                            breakMainMenu = false;
                            break;
                    }
                }
            }


        }
    }
}
