using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class UserService : IUserService
    {
		private IDataBase _db;
		public UserService()
		{
			_db = new LocalDb();
		}

		public void ChangeInfo(int userId, string firstName, string lastName)
		{
			User user = _db.GetUserById(userId);
			if (ValidationHelper.ValidateString(firstName) == null
				|| ValidationHelper.ValidateString(lastName) == null)
			{
				MessageHelper.Color("[Error] strings were not valid. Please try again!", ConsoleColor.Red);
				return;
			}
			user.FirstName = firstName;
			user.LastName = lastName;
			_db.UpdateUser(user);
			MessageHelper.Color("Data successfuly changed!", ConsoleColor.Green);
		}

		public void ChangePassword(int userId, string oldPassword, string newPassword)
		{
			User user = _db.GetUserById(userId);
			if (user.Password != oldPassword)
			{
				MessageHelper.Color("[Error] Old password did not match", ConsoleColor.Red);
				return;
			}
			if (ValidationHelper.ValidatePassword(newPassword) == null)
			{
				MessageHelper.Color("[Error] New password is not valid", ConsoleColor.Red);
				return;
			}
			user.Password = newPassword;
			_db.UpdateUser(user);
			MessageHelper.Color("Password successfuly changed!", ConsoleColor.Green);
		}

		public User LogIn(string username, string password)
		{
			User user = _db.GetAllUsers().FirstOrDefault(x => x.Username == username && x.Password == password);
			if (user == null)
			{
				MessageHelper.Color("[Error] Username or password did not match!", ConsoleColor.Red);
				return null;
			}
			return user;
		}

		public User Register(User user)
		{
			if (ValidationHelper.ValidateString(user.FirstName) == null
				|| ValidationHelper.ValidateString(user.LastName) == null
				|| ValidationHelper.ValidateUsername(user.Username) == null
				|| ValidationHelper.ValidatePassword(user.Password) == null)
			{
				MessageHelper.Color("[Error] Invalid info!", ConsoleColor.Red);
				Console.ReadLine();
				return null;
			}
			int id = _db.InsertUser(user);
			return _db.GetUserById(id);
		}
	}
}
