using System;
using System.Collections.Generic;
using System.Text;

namespace Dogs.App.Entities
{
    public static class DogShelter
    {
        public static List<Dog> DogsList { get; set; } = new List<Dog>();

        public static void PrintAll()
        {
            Console.WriteLine("List of dogs:");
            foreach (var dog in DogsList)
            {
                Console.WriteLine($"{dog.Name}");
            }
        }

    }
}
