using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter names and after that press x");

            
            List<string> names = new List<string>();
            while (true)
            {
                string inputNames = Console.ReadLine();
                if (inputNames != "x")
                {
                    names.Add(inputNames);
                }
                else
                {
                    break;
                }
            }
            string text = "kire kire kire sasasa kire sasasadsd filip filip saagrg filip";

            string[] splitedText = text.Split(" ");
            List<string> splitedTextList = splitedText.ToList();

            foreach (var name in names)
            {
                var counter = splitedTextList.Where(word => word.ToLower() == name.ToLower());
                Console.WriteLine($"The name {name} is contained {counter.Count()} times in the text");

            }

            Console.ReadLine();
        }

    }
}
