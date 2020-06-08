using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library.Classes
{
    public class Teacher: User
    {
        public List<Student> FinishedStudents { get; set; }
        public List<Student> UnFinishedStudents { get; set; }


        public Teacher(string userName,string password,string fullName)
        {
            Username = userName;
            Password = password;
            FullName = fullName;
        }
    }
}
