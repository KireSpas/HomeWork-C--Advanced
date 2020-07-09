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
            Console.WriteLine("Welcome to Main Menu");
            Console.WriteLine("What activity are we gonna do today?");
            Console.WriteLine("1) Reading");
            Console.WriteLine("2) Exercising");
            Console.WriteLine("3) Working");
            Console.WriteLine("4) Other Hobbies");
            Console.WriteLine("5) Log Out");
            return MenuChoise(5);
        }

        public int ExerciseMenu()
        {
            Console.WriteLine("Please enter the type of the exercise that you were doing");
            Console.WriteLine("1)General");
            Console.WriteLine("2)Running");
            Console.WriteLine("3)Sport");
            return MenuChoise(3);
        }

    }
}
