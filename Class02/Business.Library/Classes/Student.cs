using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library.Classes
{
    public class Student: User
    {
        public bool DoneWithTheTest { get; set; }
        public int Grade { get; set; }


        public Student(string username, string password, string fullname)
        {
            Username = username;
            Password = password;
            FullName = fullname;
        }
    }
}
