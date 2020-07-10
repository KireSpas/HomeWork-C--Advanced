using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TimeTracking.Db.DataBase;
using TimeTracking.Db.Entities;
using TimeTracking.Services.Helpers;

namespace TimeTracking.Services.Services
{
    public class UserService : IUserService
    {
		public IDataBase _db;
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
			Styles.Spiner();
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
			Styles.Spiner();
			MessageHelper.Color("Password successfuly changed!", ConsoleColor.Green);
		}

		public User LogIn()	
		{
			int counter = 3;
			while(counter > 0)
            {
				MessageHelper.Color($"Please note you you have {counter} times to try to log in",ConsoleColor.Red);
				Console.WriteLine("Enter username:");
				string username = Console.ReadLine();
				Console.WriteLine("Enter password:");
				string password = Console.ReadLine();

				User user = _db.GetAllUsers().FirstOrDefault(x => x.Username == username && x.Password == password);
				if(user != null)
                {
					Console.WriteLine($"Welcome {user.FirstName}.You are successfully logged in.");
					return user;
                }
                else
				{
					MessageHelper.Color("[Error] Username or password did not match! Please try again!", ConsoleColor.Red);
				}
				counter--;
			}
			Console.WriteLine("You entered wrong username/password 3 times. App is closing");
			Thread.Sleep(3000);
			return null;
		}

		public User Register()
		{
			User user = new User();
			MessageHelper.Color("Welcome to registration", ConsoleColor.Green);
			Console.WriteLine("Enter First Name:");
			user.FirstName = ValidationHelper.ValidateString(Console.ReadLine());
			Console.WriteLine("Enter Last Name:");
			user.LastName = ValidationHelper.ValidateString(Console.ReadLine());
			Console.WriteLine("Enter Age(must be older than 18 and younger than 120 years old to use this app):");
			user.Age = ValidationHelper.ValidateAge(Console.ReadLine());
			Console.WriteLine("Enter Username(must be longer than 5 characters):");
			user.Username = ValidationHelper.ValidateUsername(Console.ReadLine());
			Console.WriteLine("Enter Password(shoud contain at lease one capital letter and one number):");
			user.Password = ValidationHelper.ValidatePassword(Console.ReadLine());

			if (user.FirstName == null
				|| user.LastName == null
				|| user.Age == -1
				|| user.Username == null
				|| user.Password == null)
			{
				MessageHelper.Color("[Error] Invalid info! You are not registered! Please try again", ConsoleColor.Red);
				Thread.Sleep(3000);
				return null;
			}
			int id = _db.InsertUser(user);
			Console.WriteLine("Registering user...");
			Styles.Spiner();
			MessageHelper.Color("You have been successfully registered", ConsoleColor.Green);
			Thread.Sleep(3000);

			return _db.GetUserById(id);
		}


	}
}
