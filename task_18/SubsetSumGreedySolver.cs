namespace Task_18
{
	public static class SubsetSumGreedySolver
	{
		public static List<int> GetPossibleClosestSumSubset(IEnumerable<int> numbers, int target)
		{
			var sortedNumbers = numbers.Order();
			List<int> resultItems = new List<int>();
			int sum = 0;
			foreach (var number in sortedNumbers)
			{
				if (number + sum <= target)
				{
					resultItems.Add(number);
					sum += number;
				}
				else
					break;
			}

			return resultItems;
		}
	}
}
