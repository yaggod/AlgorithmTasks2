namespace Task_11
{
	internal class FiniteAutomataSearch
	{
		public static List<int> FindAllOccurrences(string data, string pattern)
		{
			List<int> result = new();
			int totalStatesCount = pattern.Length;
			Dictionary<char, int[]> table = CreateTable(data, pattern);

			int currentState = 0;
			for (int i = 0; i < data.Length; i++)
			{
				currentState = table[data[i]][currentState];
				if (currentState == totalStatesCount)
					result.Add(i + 1 - totalStatesCount);
			}

			return result;
		}

		private static Dictionary<char, int[]> CreateTable(string data, string pattern)
		{
			Dictionary<char, int[]> result = new();
			int totalStatesCount = pattern.Length;
			foreach (char @char in data)
			{
				if (!result.ContainsKey(@char))
					result.Add(@char, new int[totalStatesCount + 1]);
			}

			for (int currentState = 0; currentState < totalStatesCount + 1; currentState++)
			{
				foreach (char @char in result.Keys)
				{
					result[@char][currentState] = GetNextState(pattern, currentState, @char);
				}
			}

			return result;
		}

		private static int GetNextState(string pattern, int currentState, char nextCharacter)
		{
			int totalStatesCount = pattern.Length;
			if (currentState < totalStatesCount && pattern[currentState] == nextCharacter)
				return currentState + 1;


			for (int prefixState = currentState; prefixState > 0; prefixState--)
			{
				if (pattern[prefixState - 1] == nextCharacter)
				{
					int i;
					for (i = 0; i < prefixState - 1; i++)
						if (pattern[i] != pattern[currentState - prefixState + 1 + i])
							break;
					if (i == prefixState - 1)
						return prefixState;
				}
			}

			return 0;
		}
	}
}
