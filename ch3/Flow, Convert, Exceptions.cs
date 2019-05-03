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
//	--  Many types, including FileStream and StreamWriter, provide a Close method
//     as well as a Dispose method.
//
//
//
//		*******************************
//		**	Checking For Overflow   *** 
//		*******************************
// The checked statement - tells .NET to throw an exception when an overflow happens 
// instead of allowing it happen silently 
//
//
//

//		******* Go to definition   *******
//    *************************************
//  Can give useful info when using unfamiliar methods etc,  such as what exceptions to catch..
//
//
//
//
//


//*************************
//		Design Patterns
//**************************







//	*************  Explore 3.5 Topics  ****************
//******************************************************


//--------------------------------------------------------------------------------
// 					Selection Statements (C# reference)							 |
//--------------------------------------------------------------------------------
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/selection-statements

// A selection statement causes the program control to be transferred to a specific flow based upon 
// whether a certain condition is true or not
//
//Keywords:
			if  else  switch  case  default 

		if :
		//	identifies which statement to run based on the value of a Boolean expression. 
		//Ex:
				bool condition = true;
				
				if (condition)
				{
					execute;
				}
				else 
				{
					execute;
				}
	// two forms:
					//if-else
				if (condition)
				{
					then-statement;
				}
				else
				{
					else-statement;
				}
		
					// if statement without else
				if (condition)
				{
					then-statement;
				}					
				
//Example:
			Console.Write("Enter a character: ");
			char c = (char)Console.Read();			//  https://docs.microsoft.com/en-us/dotnet/api/system.char?view=netframework-4.8
			if(Char.IsLetter(c))					//	https://docs.microsoft.com/en-us/dotnet/api/system.char.isletter?view=netframework-4.8
			{
				if(Char.IsLower(c))
				{
					Console.WriteLine("The character is lowercase.");
				}
				else
				{
					Console.WriteLine("The character is uppercase.");
				}
			}
			else
			{
				Console.WriteLine("The character isn't an alphabetic character.");
			}

// **	You can also nest an if statement inside an else block,
// **   You can use any valid Boolean expression for the condition 
// **   You can use logical operators such as !, &&, ||, & | and ^ to make compound conditions.


	switch
//  a selection statement that chooses a single switch section to execute from a list of candidates 
//  based on a pattern match with the match expression.

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch


// Example:
				using System;
				
				public enum Color {Red, Green, Blue }  // work with enums,  can functions be used ??
				
				public class Example
				{
					public static void Main()
					{
						Color c = (Color) (new Random()).Next(0,3);
						switch (c)
						{
							case Color.Red:
											Console.WriteLine("The color is red");
											break;
						   case Color.Green:
											Console.WriteLine("The color is green"):
											break;
							case Color.Blue:
											Console.WriteLine("The color is blue");
											break;
							default:
									Console.WriteLine("The color is unknown");
									break;
						}
					}
				}

// -The match expression - provides the value to match against the patterns in case labels:
				switch (expr)
				
				// match expression must be an expression that returns a value of the following types:
				char
				string
				bool
	//an integral value, such as an int or a long 
				enum
				


// -The switch section - includes one or more switch sections. Each switch section contains one or more case 
//						 labels (either a case or default label) followed by one or more statements.
//						-No two case labels may contain the same expression
//						-Only one switch section in a switch statement executes, C# doesn't allow execution 
//						to continue from one switch section to the next.
//						- Use the break, goto, or returb statement to exit the switch section 
				
				switch (caseSwitch)
				{
					case 1:
							Console.WriteLine("Case 1...");
							break;
					case 2:
					case 3:
							Console.WriteLine("... and/or Case 2");
							break;
					case 4:
							while(true)
								Console.WriteLine("Endless looping....");
					default:
							Console.WriteLine("Default value..");
							break;
					
					
				}
		// A goto statement, if used, must transfer control to a constant label. 
		
				






// -Case labels - Each case label specifies a pattern to compare to the match expression. If they match
//				  control is transferred to the switch section that contains the first matching case label.
//         
//		C# 6: suports only the constant pattern and doesn't allow the repetition of constant values, 
//			  case labels define mutually exclusive values, and only one pattern can match the expression.
//          as a result, the order in which case statements appear is unimportant.

//      C# 7: other patterns are supported, case labels need not define mutually exclusive values, and multiple 
//            patterns can match the match expression.
//       -- if C# detects a switch section whose case statement or statements are equivalent to or are subsets of previous
//          statements, it generates a compiler error, CS8120
//		 
//	*** Case statements can contain the when keyword, to perform more specific pattern matching. >>> BOTH TRUE
//






// -the default case 

// -Pattern matching with the switch statement - Each case statement defines a pattern that, if it matches the 
//   											 match expression, causes its containing switch section to be 
//												 executed. All versions of C# support the constant pattern
//      ** Constant pattern:
//							Tests whether the match expression equals a specified constant:
						case constant:
//										-A bool literal, true or false 
//										-any integral constant, int long, byte, 
//										-name of a declared const variable 
//										-an enumeration constant
//								   		-a char literal 
//										- a string literal
//						
//	   ** Type Pattern:
//						Enables concise type evaluation and conversion. When used with the switch 
//					    statement to perform pattern matching, it tests whether an expression can be converted
//						to a specified type, and, if it can be, casts it to a variable of that type

					case type varname
					
	// type is the name of the type to which the result of expr is to be converted, 
	// varname is the object to which the result of expr is converted if the match succeeds.
	// The compile-time type of expr may be a generic type parameter.
	
//  The case expression is true if any of the following is true:
//				- expr is an instance of the same type as type 
//              - expr is an instance of type that derives from type.
//				- expr has a compile-time type that is base class of type, and expr has runtime type
//       		  that is type or is derived from type. 
//
//
//
//	
//
//








//---------------------------------------------------------------------------------------
//		Iteration Statements
//----------------------------------------------------------------------------------------
//
//	*** Create loops using iteration statements, 
//  *** Cause embedded statements to be executed a number of times, subject to the loop-termination criteria.
//	*** Statements are executed in order, except when a jump statement is encountered 

		do     for   		foreach,in    		while 
//
// do: executes a statement or a block of statements while a specified Boolean expression evaluates
//     to true.
//     
//		- The expression is evaluated after each execution of the loop, a do-while 
//        loop executes one or more times. This differs from the while loop, which 
//        executes zero or more times. 
//
//      - At any point within the do statement block, you can break  out the loop by using 
//        the break statement. 
//
//      -- You can step directly to the evaluation of the while expression by using the continue 
//  	    statement. If the expression evaluates to true, execution continues at the first 
//			statement in the loop. 
//
// for: executes a statement or a block of statements while a specified Boolean expresison evaluates to true
//		-can break out of the loop by using the break statement, or step to the next iteration in the loop
//		 by using the continue statement. Can also exit a for loop by the goto, return, or throw statements.

//******* Structure of the for statement*********
//***********************************************
//	The for statement deinfes initializer, condition, and iterator sections
//
//
//Example:
			int i;
			int j = 10;
			for (i = 0, Console.WriteLine($"Start: i={i}, j={j}"); i < j; i++, j--, Console.WriteLine($"Step: i={i}, j={j}")
				{
					//Body of loop
				}
			
			
	
// foreach: executes a statement or a block of statements for each element in an instance of the type
//		    that implements the System.Collections.IEnumerable or System.Collections.Generic.IEnumerable<T> interface.
//      
//
			https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
	
	//Read the above after understanding methods, such as GetEnumerator, and methods that return a type of
	// class, struct or interface.

	//

//

//--------------------------------------------------------
//			 Jump Statements							 |
//--------------------------------------------------------
// Branching is performed using jump statements, which cause an immediate transfer of the 
// program control.
					// Keywords:
		break      continue      goto    return     throw  




		
		
		
		
		
		return :
			//  terminates execution of the method in which it appears and returns contnrol to the calling 
			//  method. It can also return an optional value. If the method is a void type, the return statement
			//  can be omitted.
			
			//If the return statement is inside a try block, the finally block, if one exists, will be executed before 
			// control returns to the calling method.
//
//
//---------------------------------------------------------------------
//		Casting and Type Conversions
//---------------------------------------------------------------------
//
//	-Since C# is statically-typed at compile time, after a variable is declared, it cannot be 
//   declared again or assigned a value of another type unless that type is implicitly convertible to the 
//   variable's type. 
//
//  *** Type conversions:   - Implicit conversions:  NO special syntax is required because the conversion is type safe 
//								and no data will be lost.
//     				Such as conversion from derived classes to base classes....

//							- Explicit conversions (casts): Require a cast operator. Casting is required when 
//														information might be lost in the conversion.
//							Such as a conversion of a base-class instannce to a derived class.
//
//							- User-defined conversions: performed by special methods that you can define to enable 
//												explicit and implicit conversions between custom types that do not have
//											    a base class-derived class relationship.----> Conversion Operators.
//
//
//							- Conversions with helper classes: Convert between non-compatible types, 
//
				https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions
				
//
//
//
//
//----------------------------------------------------------------------
//  			Exception Handling Statements
//----------------------------------------------------------------------
//		*throw    *try-catch    *try-finally    *try-catch-finally

//			**********************
					throw
//			**********************
//  -signals the occurance of an exception during program execution

		throw [e]
//
// e is an instance of a class derived from System.Exception

https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=netframework-4.8

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
//--------------------------------------------------
//				Design Patterns
//--------------------------------------------------
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
//----------------------------------------------------
//				patterns & practices
//----------------------------------------------------
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
