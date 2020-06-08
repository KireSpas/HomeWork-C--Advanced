using Business.Library.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class Data
    {
        public List<Student> students = new List<Student>();
        public List<Teacher> teachers = new List<Teacher>();

        public Data()
        {
            Student martinStudent = new Student("student1", "password1", "Martin Martinovski");
            Student kireStudent = new Student("student2", "password2", "Kiril Spasovski");
            Student filipStudent = new Student("student3", "password3", "Filip Shutinovski");

            students = new List<Student>() { martinStudent, kireStudent, filipStudent };

            Teacher radmilaTeacher = new Teacher("teacher1", "password1", "Radmila Radmilovska");
            Teacher milaTeacher = new Teacher("teacher2", "password2", "Mila Milovska");

            teachers = new List<Teacher>() { radmilaTeacher, milaTeacher };

        }
    }
}
