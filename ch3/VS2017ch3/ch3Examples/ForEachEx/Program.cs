using System;
using static System.Console;
using static System.Convert;

// Example showcasing Implicit casting

namespace CastEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a; // note that an int can be stored as a double
            WriteLine(b);

            double c = 9.8;
            int d = (int)c;
            WriteLine(d);

            double g = 11.3;
            int h = ToInt32(g);
            WriteLine($"g is {g} and h is {h}");

            double i = 9.49;
            double j = 9.5;
            double k = 10.49;
            double l = 10.5;
            WriteLine($"i is {i}, ToInt(i) is {ToInt32(i)}");
            WriteLine($"j is {j}, ToInt(j) is {ToInt32(j)} ");
            WriteLine($"k is {k}, ToInt(k) is {ToInt32(k)}");
            WriteLine($"l is {l}, ToInt(l) is {ToInt32(l)}");

            int number = 12;
            WriteLine(number.ToString());
            bool boolean = true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me.ToString());

            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");

            Write("How many eggs are there? ");
            int count;
            string input = Console.ReadLine();
            if (int.TryParse(input, out count))
            {
                WriteLine($"There are {count} eggs.");
            }
            else
            {
                WriteLine("I could not parse the input.");
            }

        }
    }
}
