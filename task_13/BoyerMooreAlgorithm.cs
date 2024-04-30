namespace Task_13
{
	internal class BoyerMooreAlgorithm
	{
		internal static List<int> FindAllOccurrences(string text, string pattern)
		{
			List<int> result = new();
			Dictionary<char, int> charactersTable = CharactersTable(pattern);

			int patternLength = pattern.Length;
			int textLength = text.Length;
			int shift = 0;

			while (shift < textLength - patternLength)
			{
				int i = patternLength - 1;
				while (i >= 0 && pattern[i] == text[shift + i])
					i--;
				if (i < 0)
				{
					result.Add(shift);
					if (shift + patternLength < textLength)
						shift +=
							patternLength - GetOffsetFromTable(charactersTable, text[shift + patternLength]);
					else
						shift++;
				}
				else
					shift += Math.Max(1, i - GetOffsetFromTable(charactersTable, text[shift + i]));
			}

			return result;
		}

		private static Dictionary<char, int> CharactersTable(string pattern)
		{
			Dictionary<char, int> result = new();
			for (int i = 0; i < pattern.Length; i++)
			{
				result[pattern[i]] = i;
			}

			return result;
		}

		private static int GetOffsetFromTable(Dictionary<char, int> table, char key)
		{
			if (table.ContainsKey(key))
				return table[key];

			return -1;
		}


	}
}
