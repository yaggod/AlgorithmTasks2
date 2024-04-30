namespace Task_14
{
	internal class RabinsAlgorithm
	{
		internal static List<int> FindAllOccurrences(string text, string pattern)
		{
			List<int> result = new();
			int patternLength = pattern.Length;
			int textLength = text.Length;
			if (textLength < patternLength)
				return result;

			Dictionary<char, int> charCodes = CreateCharCodes(text, pattern);

			long expectedHash = CalculateHash(pattern, charCodes);
			int offset = 0;
			long currentHash = CalculateHash(text.Substring(offset, patternLength), charCodes);
			if (expectedHash == currentHash)
				if(text.Substring(offset, patternLength) == pattern)
					result.Add(offset);

			for (offset = 1; offset < textLength - patternLength; offset++)
			{
				unchecked
				{
					currentHash -= charCodes[text[offset - 1]] * (long) (Math.Pow(charCodes.Count, patternLength-1));
					currentHash *= charCodes.Count;
					currentHash += charCodes[text[patternLength + offset - 1]];
				}

				if (expectedHash == currentHash)
					if (text.Substring(offset, patternLength) == pattern)
						result.Add(offset);
			}
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
