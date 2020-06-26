using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Services.Services
{
    public interface IUserService
    {
        void ChangePassword(int userId, string oldPassword, string newPassword);
        void ChangeInfo(int userId, string firstName, string lastName);
        User LogIn(string username, string password);
        User Register(User user);
    }
}
