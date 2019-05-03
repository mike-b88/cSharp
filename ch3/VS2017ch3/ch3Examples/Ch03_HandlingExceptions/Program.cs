using System;
using static System.Console;
using System.IO;
namespace Ch03_HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Before Parsing");
            Write("what is your age? ");
            string input = Console.ReadLine();
            try
            {
                int age = int.Parse(input);
                WriteLine($"You are {age} years old.");
            }
            /*  catch(Exception ex)
              {
                  WriteLine($"{ex.GetType()} says {ex.Message}");

              }*/
            catch (OverflowException)
            {
                WriteLine("Your age is a valid number format but it is either " +
                    "too big or small");

            }

            catch (FormatException)
            {
                WriteLine("The age you entered is not a valid number format.");
            }

            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");

            }

            WriteLine("After parsing");


            string path = @"C:\Users\Brown\Source\Repos\cSharp\Packt\hub\ch2\ex1\ch3\VS2017ch3\ch3Examples";

            FileStream file = null;
            StreamWriter writer = null;
            try
            {
                if (Directory.Exists(path))
                {
                    file = File.OpenWrite(Path.Combine(path, "file2.cs"));
                    writer = new StreamWriter(file);
                    //writer.WriteLine("Hello, C#!");

                    WriteLine("Please enter text: ");
                    writer.WriteLine(ReadLine());
                }
                else
                {
                    WriteLine($"{path} does not exist!");
                }

            }

            catch (Exception ex)
            {
                //If the path doesn't exist the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    WriteLine("The writer's unmanaged resources have been disposed.");
                }
                if (file != null)
                {
                    file.Dispose();
                    WriteLine("The file's unmanaged resources have been disposed.");
                }
            }

            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\Brown\Source\Repos\cSharp\Packt\hub\ch2\ex1\ch3\VS2017ch3\ch3Examples\file2.cs"))
                {
                    Console.WriteLine($"The first Line of the file is {sr.ReadLine()}");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            
            catch (DirectoryNotFoundException e)
            {
                WriteLine($"The directory was not found: '{e}'");
            }

            catch (IOException e)
            {
                WriteLine($"The file could not be opened '{e}'");
            }

            using (FileStream file2 = File.OpenWrite(
                    Path.Combine(path, "file3.txt")))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try
                    {
                        writer2.WriteLine("Welcome, .NET Core!");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()} says {ex.Message}");
                    }
                }
            }



        }


        
    }
}
