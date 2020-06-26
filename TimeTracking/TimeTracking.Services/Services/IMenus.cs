using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public interface IMenus
    {
        void LogInOrRegisterMenu(User user);

    }
}
