using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public interface IMenus
    {
        int MenuChoise(int range);
        int LogInOrRegisterMenu();
        int MainMenu();
        int TrackMenu();
        int ExerciseMenu();
        int ReadingMenu();
        int WorkingMenu();
        int StatsMenu();
        int AccManagement();
    }
}
