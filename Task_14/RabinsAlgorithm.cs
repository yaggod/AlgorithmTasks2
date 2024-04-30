namespace Task_14
{
	internal class RabinsAlgorithm
	{
		internal static List<int> FindAllOccurrences(string text, string pattern)
		{
			List<int> result = new();


			return result;
		}

		private static Dictionary<char, int> CreateCharCodes(string text, string pattern)
		{
			Dictionary<char, int> result = new();
			int currentCode = 0;
			foreach (char c in text)
			{
				if (!result.ContainsKey(c))
					result[c] = currentCode++;
			}

			foreach (char c in pattern)
			{
				if (!result.ContainsKey(c))
					result[c] = currentCode++;
			}

			return result;
		}

		private static long CalculateHash(string text, Dictionary<char, int> charCodes)
		{
			long result = 0;
			long hashBase = charCodes.Count;
			long multiplier = 1;
			unchecked
			{
				for (int i = (text.Length) - 1; i >= 0; i--)
				{
					result += multiplier * charCodes[text[i]];
					multiplier *= hashBase;
				}
			}

			return result;
		}
	}
}
