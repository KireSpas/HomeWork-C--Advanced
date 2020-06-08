using Business.Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace DataBase
{
    public class Repository: Data
    {
        public LoginResult StudentOrTeacherLogIn()
        {
            var result = new LoginResult();
           
            Console.WriteLine("Are you 1.student or 2.teacher?");
            string userAnswer = Console.ReadLine();
            if(userAnswer == "1")
            {
                
                result.Student = LogInStudent(students);
            }
            else if(userAnswer == "2")
            {
                result.Teacher = LogInTeacher(teachers);
            }

            return result;
        }

        public Student LogInStudent(List<Student> students)
        {
            Console.WriteLine("Student, Welcome to Quizz. Please Log in");
            while (true)
            {
                
                Console.WriteLine("Enter a username");
                string username = Console.ReadLine();
                var validateUsername = students.FirstOrDefault(student => student.Username == username);
                
                Console.WriteLine("Enter a password");
                string password = Console.ReadLine();
                
                if (validateUsername != null && validateUsername.Password == password)
                {
                    Console.WriteLine($"Welcome {validateUsername.FullName}.You are successfully logged in.");
                    return validateUsername;
                }
                else
                {
                    Console.WriteLine("Wrong Username or Password.Please try again");
                }
                
            }
        }

        public Teacher LogInTeacher(List<Teacher> teachers)
        {
            Console.WriteLine("Teacher,Welcome to Quizz App. Please Log in");
            while (true)
            {
                
                Console.WriteLine("Enter a username");
                string username = Console.ReadLine();
                var validateUsername = teachers.FirstOrDefault(teachers => teachers.Username == username);

                Console.WriteLine("Enter a password");
                string password = Console.ReadLine();

                if (validateUsername != null && validateUsername.Password == password)
                {
                    Console.WriteLine($"Welcome {validateUsername.FullName}.You are successfully logged in.");
                    return validateUsername;
                }
                else
                {
                    Console.WriteLine("Wrong Username or Password.Please try again");
                }

            }
        }

        public int ToInteger(int min, int max)
        {
            int parsedNumber = 0;
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    parsedNumber = int.Parse(Console.ReadLine());
                    if (!(parsedNumber >= min && parsedNumber <= max))
                    {
                        throw new Exception($"Please select from given input range from {min} to {max}.");
                    }
                    isValid = !isValid;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter argument.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not valid input.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large or too low.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return parsedNumber;
        }

        public string Question1()
        {
            return @"Q1: 
                    What is the capital of Tasmania?    
                    1: Dodoma
                    2: Hobart <tocen>
                    3: Launceston
                    4: Wellington";

        }
        public string Question2()
        {
            return @"Q2: 
                    What is the tallest building in the Republic of the Congo?
                    1: Kinshasa Democratic Republic of the Congo Temple
                    2: Palais de la Nation
                    3: Kongo Trade Centre
                    4: Nabemba Tower <tocen>";
        }
        public string Question3()
        {
            return @"Q3: 
                    Which of these is not one of Pluto's moons?
                    1: Styx
                    2: Hydra
                    3: Nix
                    4: Lugia <tocen>";
        }
        public string Question4()
        {
            return @"Q4: 
                    What is the smallest lake in the world?
                    1: Onega Lake
                    2: Benxi Lake <tocen>
                    3: Kivu Lake
                    4: Wakatipu Lake";
        }
        public string Question5()
        {
            return @"Q5: 
                    What country has the largest population of alpacas?
                    1: Chad
                    2: Peru <tocen>
                    3: Australia
                    4: Niger";
        }

        public int QuestionForm(string question, int correctAnswer)
        {
            Console.WriteLine(question);
            int answerQuestion1 = ToInteger(1, 4);
            if (answerQuestion1 == correctAnswer)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Student Test(Student user)
        {
            
            Console.WriteLine("TEST");
            Console.WriteLine("Good Luck!!!");
            string question1 = Question1();
            string question2 = Question2();
            string question3 = Question3();
            string question4 = Question4();
            string question5 = Question5();

            int gradeCalculation = QuestionForm(question1, 2) + QuestionForm(question2, 4) + QuestionForm(question3, 4) + 
                               QuestionForm(question4, 2) + QuestionForm(question5, 2);
            if(gradeCalculation == 0)
            {
                gradeCalculation = 1;
            }

            user.DoneWithTheTest = true;
            user.Grade = gradeCalculation;
            
            Console.WriteLine($@"Thank you for your participation {user.FullName}. 
                                Your final grade is {gradeCalculation} 
                                Logging you out. ");
            Thread.Sleep(3000);

            return user;
        }

        public void AssigningStudentsInLists()
        {
            var finishedStudents = students.Where(student => student.DoneWithTheTest = false).ToList();
            var unFinishedStudents = students.Where(student => student.DoneWithTheTest = true).ToList();

            foreach (var teacher in teachers)
            {
                teacher.FinishedStudents = finishedStudents;
                teacher.UnFinishedStudents = unFinishedStudents;
            }
        }
    }

    public class LoginResult
    {
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
