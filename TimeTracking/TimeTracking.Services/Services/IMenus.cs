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
        int ExerciseMenu();

    }
}
