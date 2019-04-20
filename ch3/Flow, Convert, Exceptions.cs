//  				Chapter 3
//--------------------------------------------------
//**	Controlling the Flow, Converting Types, 
//**	and Handling Exceptions.
//--------------------------------------------------
// This chapter is about writing code that makes decisions,
// repeats blocks of statements, converts between types,
// and handles errors (exceptions).
//
//	* Selection Statements
//  * Iteration statements
//  * Casting and converting between types
//  * Handling exceptions
//  * Checking for overflow
//  * Looking for help
//
//
//************************************************************
// 			Selection statements
//************************************************************
// Every application needs to be able to select from choices and branch along different code paths
//
// Two selection statements in C# are if and switch
//
// 
//	******   	The if statement   ********
//-----------------------------------------
// the if statement determines which branch to follow by evaluating a Boolean expression
// 
// the else block is optional
//
// The if statement can be nested and combined
//
// 
	if (args.Length == 0)
	{
		WriteLine("There are no arguments.");
	}
	else
	{
		WriteLine("There is at least one argument.");
	}

//  look into the #goto fail bug in Apple's iPhone OS, 
//  -- Secure Sockets Layer bug, 
	
	
//	*****		Pattern matching with the if statement    ******
//---------------------------------------------------------------
// new feature of C#7 is pattern matching.
// 
// The if statement can use the is keyword in combination with declaring a local variable to make
// code safer
//
				object 0 = "3";
				int j = 4;
				
				if(o is int i)
				{
					WriteLine($"{i} {j} = {i * j}");
				}
				else
				{
				WriteLine("o is not an int so it cannot multiply!");
				}

				
//			 ******** The switch statement ********
//			========================================				
//	** Like the if statement, the switch statement supports pattern matching 
//     The values no longer need to be literal values, they can be patterns
//
//
//** The switch statement is different from the if statement because it compares a single
// 	 expression against a list of multiple possible cases.
//
//** Every case is related to the single expression.
//** Every case must end with the break keyword or the goto, keywords.
//
//   **Labels -- writing out the A_label, Visual Studio generates error:
//				"This label has not been referenced" -- Use the goto?


//******  Example code to look into  *******
//******************************************
//		-File.Open
//		-Stream
//		-System.IO
//		-Path.Combine
//		-FileMode.OpenOrCreate
//
//
//				
				
				
				
				
//
//********************************************************************
//******		   Iteration Statements					**************				**			
//		*************************************************				
//				-Repeat a block either while a condition is true or for each
//			     item in a group.
//
//	***** The While Statement  ******			
//		***********************	
//  -evaluates a Boolean expression and continues to loop while it is true.
//   				
//
//	***** The do Statement  ******
// ********************************
//	-the do statement is like while, except the boolean expression is checked at the bottom
//   of the block instead of the top, which means that it always executes at least once.
//
//	******	The For Statement	******
//	     ************************
//  - Combines an initializer statement that executes once at the start of loop, A 
//    Boolean expression to check whether the loop should continue, and an incrementer
//    that executes at the bottom of the loop.

//   - The for statement is commonly used with an integer counter:

		for (int y = 1; y <= 10; y++)
		{
			WriteLine(y);
		}

//
//	******* The foreach statement ********
//        *************************
//   
//	- Used to perform a block of statements on each item in a sequence, for 
//    example an array or collection.
// *** - Each item is read-only and if the sequence is modified during iteration, 
//  	 then an exception will be thrown.	***
//
//	    **** How does the foreach statement work?	****
//--------------------------------------------------------
//
//  the foreach statement will work on any type that implements an interface
//  called IEnumerable, Chapter 7, Implementing Interfaces and Inheriting Classes.
//



//
// --- *** Casting and converting between types *** ---
//  **************************************************
// - It becomes necessary often to convert between types.
// - Must explicitly cast a double into an int variable using a pair 
//   of round brackets around the type you want to case 
//   *** Cast operator  ***
		
		long e = 10;
		int f = (int)e;
		WriteLine($"e is {e} and f is {f}");
		e = long.MaxValue;
		f (int)e;
		WriteLine($"e is {e} and f is {f}");

//***** Using the convert type ******
//  *****************************
//  An alternative to using the casting operator is to use the System.Convert type 
//
		using static System.Convert;

	double g = 9.8;
	int h = ToInt32(g);
	WriteLine($"g is {g} and h is {h}");
		
//		*** The System.Convert type can convert to and from all the C# number
//          types as weel ass Booleans, strings, and date and time values.	
//
//*** The rule for rounding is subtly different. It will round up if the decimal
//    part is .5 or higher and the non-decimal part is odd, but it will round down 
//    if the non-decimal part is even. It always rounds down if the decimal part is less 
//   than .5 ----->>> Banker's Rounding 


//---------------------------------------
// Converting from any type to a string:
//---------------------------------------
//	*** Most common converstion is from any type into a string variable,
//      so all types have a method named ToString that they inherit from the System.Object class.
//  *** Converts into a textual representation
//  *** Some types can't be sensisbly represented as text so they return their 
//      namespace and type name.  <<<---- Go back to Exercise 2.2 and my array of types idea *****
//
//
//
//
//		------------------------------------------------------
// 			 Parsing from strings to numbers or dates and times
//		------------------------------------------------------
//	*** from strings to numbers or date and time values 
//  *** The opposite of ToString is Parse. 
//    
//		*** Review and remember format codes ***
		
		WriteLine($"My birthday is {birthday:D}.");

//  One Problem with the parse method is that it gives errors if the string cannot be converted.
//  
		int count = int.Parse("abc");
// Produces an Unhandled Exception: System.FormatException: Input string was not in a correct format.
//
// To avoid errors, you can use the TryParse method instead.
// TryParse attempts to convert the input string and returns true if it can convert it 
// and false if it cannot. The out keyword is required to allow TryParse method to set 
// the count variable when the conversion works.

			WriteLine("How many eggs are there? ");
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

//     ***************************************			
//  		 *** Handling Exceptions  ***
//     ***************************************
// -C# calls where an exception has been thrown
// - Good practice is to avoid writing code that will throw an exception whenever possible.
//  --- When you can't you must catch the exception and handle it.
//  --- *** can take control over how to handle exceptions using the try statement.
//  
//*****************************
//  *** The try statement  ***
//*****************************
//  
//	-- When you know that a statement can cause an error, you should wrap that statement
//     in a try block.
//  -- Do not have to do anything in catch block
//  -- Useful to show what kind of error has occured 
//
// *** Catching all exceptions ***
// *******************************
//
//  
		catch(Exception ex)
		{
			WriteLine($"{ex.GetType()} says {ex.Message}");
		}

// Another catch:

				catch(OverflowException)
				{
					WriteLine("Your age is a valid number format but it is either
					too big or small.");
				}
				catch (FormatException)
				{
					WriteLine("The age you entered is not a valid number format.");
				}
//
//	https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/
//
//	The order in which you catch exceptions is important.
//  The correct order is related to the inheritance hierarchy of the exception types.
//  
//
//
//
//




// ****** The finally statement *******
//*************************************
//
// Sometimes we may need to ensure that some code executes regardless of whether an 
// exception occurs or not.
// --For example when working with files and databases, when you open a file or a database 
//   you are using resources outside of .NET, called unmanaged resources and must be disposed
//   of when you are done working them.

//  To guarantee that they are disposed of, we can call the Dispose method inside of 
//  a finally block.

//  Import System.IO --
							using System.IO;
//			https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netframework-4.8
//


		if (Directory.Exists(path))
					https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.exists?view=netframework-4.8

		file = File.OpenWrite(Path.Combine(path, "file2.cs"))
					https://docs.microsoft.com/en-us/dotnet/api/system.io.file.openwrite?view=netframework-4.8
		
//		
// 


//
//

				
//
// -- *** FileStream
					https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=netframework-4.8
// -- *** StreamWriter
					https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=netframework-4.8
// -- *** Exception 
					
// -- *** .Dispose 
//
//


// ********************************************************
// ****  Simplifying disposal with the using statement ****
//*********************************************************
//
//	-- can simplify the code that needs to check for a non-null object and then call its Dispose
//     method by using the using statement. --- generate a finally statement that disposes of an object.
//
			https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
			https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?view=netframework-4.8
			https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=netframework-4.8
// 
//	--  
//
//
//
//
//
//
//
//
//
//
//
//



















//
//
//
//
//
//
