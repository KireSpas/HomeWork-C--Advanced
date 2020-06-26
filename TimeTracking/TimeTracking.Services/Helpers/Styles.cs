using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Helpers
{
    public static class Styles
    {
        public static void Spiner()
        {
            for (int i = 0; i < 20; i++)
            {
                switch (i % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Thread.Sleep(150);
            }
        }

        
    }
}
