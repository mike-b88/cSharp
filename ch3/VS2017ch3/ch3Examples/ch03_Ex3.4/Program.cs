using System;

//Just use tryparse in the end after i get this to work!!!

namespace ch03_Ex3._4
{
    public class inputCheck
    {
        

        public int checkInputs(string m, string n)
        {
           // Look into how the return statement does not return to caller, 
            try
            {
               int val = int.Parse(m);
                int val1 = int.Parse(n);

                if (val < 0 || val >= 256)
                {
                    Console.WriteLine("Please reenter a value between the ranges!!");
                    Program.Main();
                }
                else
                {
                    Console.WriteLine($"Value is: {m}");
                    Console.WriteLine($"The result is {val}/{val1} = {val / val1}");
                   // return val;
                }
            }

            

            catch (FormatException)
            {
                Console.WriteLine("Please reenter a proper value!!");
                Program.Main();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} says {ex.Message}");
                Program.Main();
            }

       //     int val1 = int.Parse(m);

            return 0;
        }


      
    }
   /* public class CheckFirst
    {
        inputCheck first = new inputCheck();
    }
    */

    /* public class CheckFirst
     {
         public static int firstCheck(string p)
         {
             return inputCheck.checkInputs(p);
         }
     }
     */
 /*   public class CheckSecond
    {
        public static int secondCheck(string l)
        {
            return inputCheck.checkInputs(l);
        }
    }
    */


    class Program
    {
       public static int Main()
        {
            var check1 = new inputCheck();


            // On mono I am working on creating a dll that calls the main function from another source file, 
            // I ran into a compilation error with mcs: error CS0103: The name 'Program' does not exist in the current context
            // So the program ends after an invalid input for now, must find a way to call the main program.


          //  var check2 = new inputCheck();
            // Knowing that exceptions are craeted with the throw keyword, 
            //  if the user input is not an int and not between constraints
            // create "throw", an exception that displays error and for now just 
            // asks for correct input
            string a = null;
            string b = null;
            

            Console.WriteLine("Hello, please enter two integers between 0 and 255: ");
            a = Console.ReadLine();
            b = Console.ReadLine();

            // int c = inputCheck.checkInputs(a);
            // int c = CheckFirst.firstCheck(a);
            //  int c = CheckFirst.checkInputs(a);
            // var check1 = new inputCheck();
            // int c = check1.checkInputs(a, b);
            check1.checkInputs(a, b); 
           // var check2 = new inputCheck();
          //  int d = check2.checkInputs(b);
            

            // int d = inputCheck.checkInputs(b);
            //  int d = CheckSecond.secondCheck(b);



          //  Console.WriteLine($"The result is {c} / {d} = {(c/d)}");
            return 0;

        }
    }
}










