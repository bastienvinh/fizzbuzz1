using System;

namespace Portr
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var buzz = new FizzBuzz();
			buzz.MessageHasLuckyNumber = "lucky";

			Console.WriteLine(buzz.GenerateReport(1, 20));
		}
	}
}
