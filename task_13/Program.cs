﻿namespace Task_13
{
	internal class Program
	{
		static void Main(string[] args)
		{

			string text = File.ReadAllText((@"..\..\..\input.txt"));
			string pattern = "AABA";
			var result = BoyerMooreAlgorithm.FindAllOccurrences(text, pattern);
			
		}
	}
}
