using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using TimeTracking.Db.Entities;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class Menus : IMenus
    {
        public int MenuChoise(int range)
        {
            while (true)
            {
                var numberFromUser = ValidationHelper.ValidateNumber(Console.ReadLine(), range);
                if (numberFromUser == -1)
                {
                    MessageHelper.Color("[Error] Wrong number entered. Please try again", ConsoleColor.Red);
                    continue;
                }
                return numberFromUser;
            }
        }

        public int LogInOrRegisterMenu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==  \\    //\\    // |||||| ||     ||||||  ||||||  |||     |||   ||||||  ");
            Console.WriteLine("==   \\  //  \\  //  ||=    ||     ||      ||  ||  || || || ||   ||=     ");
            Console.WriteLine("==    \\//    \\//   |||||| |||||| ||||||  ||||||  ||  ||   ||   ||||||  ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.ResetColor();

            Console.WriteLine("Please choose one of the options");
            Console.WriteLine("1)LogIn");
            Console.WriteLine("2)Register");
            return MenuChoise(2);

        }

        public int MainMenu()
        {
            MessageHelper.Color("Welcome to Main Menu",ConsoleColor.Green);
            Console.WriteLine("Please choose one of the options");
            Console.WriteLine("1)Track Activity");
            Console.WriteLine("2)Statistics");
            Console.WriteLine("3)Account Management");
            MessageHelper.Color("4)Log Out", ConsoleColor.Red);
            return MenuChoise(4);
        }

        public int TrackMenu()
        {
            MessageHelper.Color("Welcome to Track Menu",ConsoleColor.Green);
            Console.WriteLine("What activity are we gonna do today?");
            Console.WriteLine("1) Reading");
            Console.WriteLine("2) Exercising");
            Console.WriteLine("3) Working");
            Console.WriteLine("4) Other Hobbies");
            Console.WriteLine("5) Go Back");
            return MenuChoise(5);
        }

        public int ExerciseMenu()
        {
            MessageHelper.Color("Please enter the type of the exercise that you were doing",ConsoleColor.Green);
            Console.WriteLine("1)General");
            Console.WriteLine("2)Running");
            Console.WriteLine("3)Sport");
            return MenuChoise(3);
        }

        public int ReadingMenu()
        {
            MessageHelper.Color("Please enter the type of the book that you were reading", ConsoleColor.Green);
            Console.WriteLine("1)Belles Lettres");
            Console.WriteLine("2)Fiction");
            Console.WriteLine("3)Professional Literature");
            return MenuChoise(3);
        }

        public int WorkingMenu()
        {
            MessageHelper.Color("Where did you work from",ConsoleColor.Green);
            Console.WriteLine("1)Office");
            Console.WriteLine("2)Home");
            return MenuChoise(2);
        }

        public int StatsMenu()
        {
            MessageHelper.Color("Welcome to Statistics",ConsoleColor.Green);
            Console.WriteLine("Which stats would you like to view");
            Console.WriteLine("1)Reading stats");
            Console.WriteLine("2)Exercising stats");
            Console.WriteLine("3)Working stats");
            Console.WriteLine("4)Hobbies");
            Console.WriteLine("5)Global stats");
            Console.WriteLine("6)Go back");
            return MenuChoise(6);
        }

        public int AccManagement()
        {
            MessageHelper.Color("Welcome to Acc Management menu", ConsoleColor.Green);
            Console.WriteLine("What would you like to do");
            Console.WriteLine("1)Change password");
            Console.WriteLine("2)Change First and Last Name");
            Console.WriteLine("3)Deactivate account");
            Console.WriteLine("4)Go back");
            return MenuChoise(4);

        }
    }
}
