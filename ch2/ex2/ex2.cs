//Counting Types and methods
//Find out how many types and methods are avaiable to C#
//
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection
using System;
using System.Linq;
using System.Reflection;

namespace ex2
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Xml.XmlReader reader;
			System.Xml.Linq.XElement element;
			System.Net.Http.HttpClient client;
			//Loop through assemblies that this application references
			foreach (var r in Assembly.GetEntryAssembly()
				.GetReferencedAssemblies())
				{
					//Load assemblies to read its details
					var a = Assembly.Load(new AssemblyName(r.FullName));
					//declare a variable to count the total number of methods
					int methodCount = 0;
					//loop through all the types in the assembly
					foreach (var t in a.DefinedTypes)
					{
						//add up the counts of methods
						methodCount += t.GetMethods() .Count();
					}
					//output the count of types and their methods
					Console.WriteLine($"{a.DefinedTypes.Count() :N0} types " +
						$"with {methodCount :N0} methods in {r.Name} assembly.");
				}
		}
		
	}
}
