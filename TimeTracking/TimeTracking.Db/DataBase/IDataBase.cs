using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Db.DataBase
{
    public interface IDataBase
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        int InsertUser(User user);
        void RemoveUser(int id);
        void UpdateUser(User user);
    }
}
