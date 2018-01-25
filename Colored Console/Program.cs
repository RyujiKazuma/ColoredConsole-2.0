using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Colored_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			int year = setYears();
			writeYears(year);
			leapYear(year);
		}

		static int setYears()
		{

			Console.WriteLine("Please enter a year.");
			string year = Console.ReadLine();
			bool yeaRight = Int32.TryParse(year, out int yearInt);
			if (yeaRight)
			{
				return yearInt;
			}
			else
			{
				Console.WriteLine("You have entered invalid value");
				return setYears();
			}
		}
		static int writeYears(int start)
		{

			start -= 5;
			int end = start;
			end += 10;
			for (int i = start; i <= end; i++)
			{
				Console.ResetColor();
				Console.WriteLine("Hit any key to write down year " + i + ".");
				Console.ReadLine();
				bool lYear = leapYear(i);
				if (lYear)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine();
					Console.WriteLine(i);
					Console.ResetColor();
					underline();
				}
				else
				{
					Console.ResetColor();
					Console.WriteLine();
					Console.WriteLine(i);
					underline();
				}
				for (int months = 1; months <= 12; months++)
				{
					seasonColor(months);
					monthwriter(months, lYear);
				}
			}
			Console.WriteLine("Hit any key to exit");
			Console.ReadLine();
			return 0;
		}

		static bool leapYear(int start)
		{
			bool lYear;
			int leapYear4 = start % 4;
			int leapYear100 = start % 100;
			int leapYear400 = start % 400;
			if (leapYear4 == 0 || leapYear400 == 0 && leapYear100 != 0)
			{
				lYear = true;
			}
			else
			{
				lYear = false;
			}
			return lYear;
		}

		static string days31(int months)
		{
			List<string> days = new List<string>();
			for (int j = 1; j <= 31; j++)
			{
				days.Add(j.ToString());
			}
			foreach (string day in days)
			{
				Console.WriteLine(day.PadLeft(2, '0') + "/" + months.ToString().PadLeft(2, '0'));
			}
			return "";
		}

		static string days30(int months)
		{
			List<string> days = new List<string>();
			for (int j = 1; j <= 30; j++)
			{
				days.Add(j.ToString());
			}
			foreach (string day in days)
			{
				Console.WriteLine(day.PadLeft(2, '0') + "/" + months.ToString().PadLeft(2, '0'));
			}
			return "";
		}

		static string days28(int months)
		{
			List<string> days = new List<string>();
			for (int j = 1; j <= 28; j++)
			{
				days.Add(j.ToString());
			}
			foreach (string day in days)
			{
				Console.WriteLine(day.PadLeft(2, '0') + "/" + months.ToString().PadLeft(2, '0'));
			}
			return "";
		}

		static string days29(int months)
		{
			List<string> days = new List<string>();
			for (int j = 1; j <= 29; j++)
			{
				days.Add(j.ToString());
			}
			foreach (string day in days)
			{
				Console.WriteLine(day.PadLeft(2, '0') + "/" + months.ToString().PadLeft(2, '0'));
			}
			return "";
		}

		static int underline()
		{
			int i = Console.WindowWidth;
			Console.WriteLine("=".PadRight(i, '='));
			return i;
		}

		static int seasonColor(int months)
		{
			if (months == 3 || months == 4 || months == 5)
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			else if (months == 6 || months == 7 || months == 8)
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			else if (months == 9 || months == 10 || months == 11)
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
			}
			else if (months == 12 || months == 1 || months == 2)
			{
				Console.ForegroundColor = ConsoleColor.DarkBlue;
			}
			return months;
		}

		static int monthwriter(int months, bool lYear)
		{
			if (months == 1 || months == 3 || months == 5 || months == 7 || months == 8 || months == 10 || months == 12)
			{
				Console.WriteLine();
				days31(months);
			}
			else if (months == 4 || months == 6 || months == 9 || months == 11)
			{
				Console.WriteLine();
				days30(months);
			}
			else
			{
				if (lYear)
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine();
					days29(months);
				}
				else
				{
					Console.WriteLine();
					days28(months);
				}
			}
			return months;
		}
	}
}
