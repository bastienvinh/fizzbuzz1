using System;
using System.Text;
using System.Linq;

namespace Portr
{
	public class FizzBuzz
	{
		#region Attributes

		// We make configurable all message.
		public int LuckyNumber { get; set; }
		public string MessageHasLuckyNumber { get; set; }
		public string MessageNumber3 { get; set; }
		public string MessageNumber5 { get; set; }
		public string MessageNumber3And5 { get; set; }
		#endregion


		#region Constructors
		public FizzBuzz()
		{
			MessageHasLuckyNumber = "lucky";
			MessageNumber3 = "fizz";
			MessageNumber5 = "buzz";
			MessageNumber3And5 = "fizzbuzz";
			LuckyNumber = 3;
		}

		#endregion

		#region Utils
		private string FizzBuzzNumber(int number)
		{
			string res = "";

			if ((number % 10) == LuckyNumber)
				res = MessageHasLuckyNumber;

			// Custom fizzbuzz Solution
			else if ((number % 15) == 0)
				res = MessageNumber3And5;
			else if ((number % 3) == 0)
				res = MessageNumber3;
			else if ((number % 5) == 0)
				res = MessageNumber5;
			else
				res = number.ToString();

			return res;
		}
		#endregion


		#region Public Methods
		public string Generate(int start, int end)
		{

			var builder = new StringBuilder();

			// I did this way to manage the " ";

			if (start <= end)
				builder.Append(FizzBuzzNumber(start));

			for (int i = start + 1; i <= end; ++i)
			{
				builder.Append(string.Concat(" ", FizzBuzzNumber(i)));
			}

			return builder.ToString();
		}

		public string Generate(int start, int end, bool hasReport)
		{
			string res = Generate(start, end);
			if (hasReport)
				res += " " + GenerateReport(start, end);

			return res;
		}

		// For me each function can Test Simply;

		public string GenerateReport(int start, int end)
		{
			// We count the number of lucky
			int numberLucky = (end / 10) - (start / 10);
			if ((end % 10) >= LuckyNumber)
				++numberLucky;

			int numberInteger = end - (start - 1);
			int numberOf15 = (end / 15) - ((start - 1) / 15); // Remove 15 first

			// I didn't find a better way for now, I try to make it simpler
			// So I count all lucky.
			// It's impossible to ony modifiate this code than counting with Generate Function
			var list = Enumerable.Range(1, numberLucky)
													 .Select(x => (((x - 1) * 10) + LuckyNumber) + (start - (start % 10)));

			// res -= list.Count;

			// int numberInterData = numberLucky - list.Count;
			int numberOfFizz = (end / 3) - ((start - 1) / 3) - numberOf15 - list.Where(x => (x % 3) == 0).Count();
			int numberOfBuzz = (end / 5) - ((start - 1) / 5) - numberOf15 - list.Where(x => (x % 5) == 0).Count();

			numberInteger -= (numberLucky + numberOfFizz + numberOfBuzz + numberOf15);

			return string.Format("{0}:{1} {2}:{3} {4}:{5} {6}:{7} integer:{8}", MessageNumber3, numberOfFizz, MessageNumber5, numberOfBuzz, MessageNumber3And5, numberOf15, MessageHasLuckyNumber, numberLucky, numberInteger);
		}

		#endregion
	}
}

