using Dogs.App.Entities;
using System;
using System.Drawing;
using System.Xml.Schema;

namespace Dogs.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog(1,"L", Color.White);
            Dog dog2 = new Dog(1,"Lajka2", Color.Red);
            Dog dog3 = new Dog(-1,"Lajka3", Color.Blue);

            CheckDog(dog1);
            CheckDog(dog2);
            CheckDog(dog3);
            

            Console.WriteLine("===============");Console.WriteLine("===============");Console.WriteLine("===============");

            DogShelter.PrintAll();

            Console.ReadLine();

        }

        public static void CheckDog(Dog dog)
        {
            if (Dog.Validate(dog.Id) == false)
            {
                Console.WriteLine($"Id number on {dog.Name} should be 0 or more");
            }
            else if (Dog.Validate(dog.Name) == false)
            {
                Console.WriteLine($"{dog.Name} name should have 2 or more characters");
            }
            else
            {
                DogShelter.DogsList.Add(dog);
            }
        }
    }
}
