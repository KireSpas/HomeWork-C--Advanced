using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.Services.Helpers
{
    public static class Styles
    {
        public static void WelcomeMenu()
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
        }
    }
}
