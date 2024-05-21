namespace Task_18
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int itemsCount = 10;
			Random random = new();
			List<int> items = new();
			for (int i = 0; i < itemsCount; i++)
			{
				items.Add(random.Next(0, 100));
			}

			var result = SubsetSumGreedySolver.GetPossibleClosestSumSubset(items, 250);
			var sum = result.Sum();
		}
	}
}
