using System;
using static System.Console;
using System.IO;

namespace ch03Examples
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("There are no arguments.");
            }
            else
            {
                WriteLine("There is at least one argument.");
            }


            object o = 3;
          //  object o = "3";
            int j = 4;

            if (o is int i)
            {
                WriteLine($"{i} X {j} = {i * j}");
        
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply!");
            }

        A_label:
            var number = (new Random()).Next(1, 7);
            WriteLine($"My random number is {NumberLock}");
            switch (number)
            {
                case 1:
                    WriteLine("One");
                    break;      //Jumps to the end of the switch statement
                case 2:
                    WriteLine("Two");
                    break;
                case 3:
                case 4:
                    WriteLine("Three or four");
                    goto case 1;
                case 5:
                    //go to sleep for half a second
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                    default:
                    WriteLine("Default");
                    break;
            }


            string path = @"C:\Users\Brown\Source\Repos\cSharp\Packt\hub\ch2\ex1\ch3\VS2017ch3\ch3Examples";
            Stream s = File.Open (
                Path.Combine(path, "file1.cs"),     // Try to add multiple Files for creation, or editing, or whatever the case, 
                FileMode.OpenOrCreate);

            switch(s)
            {
                case FileStream writeableFile when s.CanWrite:
                    WriteLine("The stream is to a file that I can write to.");
                    break;
                case FileStream readOnlyFile:
                    WriteLine("The stream is to a read-only file.");
                    break;
                case MemoryStream ms:
                    WriteLine("The stream is to a memory address.");
                    break;
                default:
                    WriteLine("The stream is some other type.");
                    break;
                case null:
                    WriteLine("The Stream is null.");
                    break;
            }
            

        }

        

    }
}