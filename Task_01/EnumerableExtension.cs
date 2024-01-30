namespace Task_01
{
	public static class EnumerableExtension
	{
		public static IEnumerable<T> Skip<T>(this IEnumerable<T> items, T itemToSkip, int count)
		{
			int foundCandidates = 0;
			foreach (T item in items)
			{
				if (itemToSkip?.Equals(item) == true)
				{
					foundCandidates++;
					if (foundCandidates <= count)
						continue;
				}

				yield return item;

			}

		}
	}
}
