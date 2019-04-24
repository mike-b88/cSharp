// Example for var (C# Reference)
// FROM: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var

using System;
using static System.Console;

namespace exMicDocs
{
	class Program
	{
		string[] words = {"apple", "strawberry", "grape", "peach", "banana" };
		static void Main()
		{
			//string[] words = {"apple", "strawberry", "grape", "peach", "banana" };
			var wordQuery = from word in words
						where word[0] == 'g'
						select word;
						
			foreach (string s in wordQuery)
			{
				WriteLine(s);
			}
			
	//	var custQuery = from cust in customers
	//					where cust.City == "Phoenix"
	//					select new {cust.Name, cust.Phone};
			
	//		foreach (var item in custQuery)
	//		{
	//			WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
	//		}		
		}
	}
}