using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Dogs.App.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }


        public Dog(int id,string name,Color color)
        {
            Id = id;
            Name = name;
            Color = Validate(color);
        }

        public string Bark()
        {
            return $"Bark Bark";
        }

        public static bool Validate(int id)
        {
            if (id < 0)
            {
                return false;
            }
            return true;
        }
        public static bool Validate(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }
            return true;
        }
        public static Color Validate(Color color)
        {
            return color;
        }

    }
}
