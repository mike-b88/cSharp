using System;
using static System.Console;

namespace Ch03_CheckingForOverflow
{
    class Program
    {
        static void Main()
        {
          
            try
            {
                checked
                {
                    int x = int.MaxValue - 1;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                }

            }
            catch(OverflowException)
            {
                WriteLine("The code overflowed but I caiught the exception.");
            }
            
            
            
            
            
            
            
            
            
            
            /*  checked
            {
                int x = int.MaxValue - 1;
                WriteLine(x);
                x++;
                WriteLine(x);
                x++;
                WriteLine(x);
                x++;
                WriteLine(x);
            }*/
        }
    }
}
