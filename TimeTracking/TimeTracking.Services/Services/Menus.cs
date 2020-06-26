using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.Entities;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class Menus : IMenus
    {
        public void LogInOrRegisterMenu(User user)
        {
            Styles.WelcomeMenu();

        }
    }
}
