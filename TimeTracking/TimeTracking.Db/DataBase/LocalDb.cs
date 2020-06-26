using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Db.Entities;

namespace TimeTracking.Db.DataBase
{
    public class LocalDb : IDataBase
    {
        public int IdCount { get; set; }
        private List<User> db;
        public LocalDb()
        {
            db = new List<User>();
            IdCount = 1;
        }
        public List<User> GetAllUsers()
        {
            return db;
        }

        public User GetUserById(int id)
        {
            return db.FirstOrDefault(x => x.Id == id);
        }

        public int InsertUser(User user)
        {
            user.Id = IdCount;
            db.Add(user);
            IdCount++;
            return user.Id;
        }

        public void RemoveUser(int id)
        {
            User item = db.FirstOrDefault(x => x.Id == id);
            if (item != null) db.Remove(item);
        }

        public void UpdateUser(User user)
        {
            User item = db.FirstOrDefault(x => x.Id == user.Id);
            item = user;
        }
    }
}
