using System;


// Create an array to store password verification attempts, utilize foreach to 
// WriteLine each of the attempts, if any.....


namespace iterations
{
    class Program
    {
      const int attempts = 10;
        static int trys;
        static string[] tryStore = new string[10];
        static void Main(string[] args)
        {
            int trysCount = 0;
            Console.WriteLine("Hello World!");

            Console.WriteLine("Enter your Password: ");
            string password = Console.ReadLine();
            while ( trys < attempts)
            {
                string passwordCheck = string.Empty;

                do
                {
                    Console.WriteLine("Verify Your Password: ");
                    passwordCheck = Console.ReadLine();
                   // trys++;
                   // Console.WriteLine($"Counter for trys is {trysCount = trys}");
                    if (trys >= 0 && passwordCheck != password)         //Verify that the trys check is needed, may be redundant
                    {
                        trys++;
                        Console.WriteLine($"Counter for trys is {trysCount = trys}");
                        Console.WriteLine("Please Re-Enter");
                        tryStore[trys] = passwordCheck;
                    }
                    if (trys == 9)
                    {
                        Console.WriteLine("One attempt Left!!!");
                    }
                        

                 //   trys++;
                  



                } while (passwordCheck != password && trys < attempts);  //Fix this

                if (passwordCheck == password)
                {
                    Console.WriteLine("Correct!");
                    if(trys > 0)
                    {
                        Console.WriteLine("You've entered the following incorrect passwords: ");
                        foreach (string Try in tryStore)
                        {
                            Console.WriteLine($"{Try}");
                        }
                    }
                }




                break;
              //  trys++;   // remove this
            }



        }
    }
}
