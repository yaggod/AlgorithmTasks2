namespace Task_16
{
	public static class BackpackProblemSolver
	{
		public static int GetMaximumTotalPrice(IEnumerable<BackpackItem> items, int maxWeight)
		{
			int[,] maxPrices = new int[items.Count() + 1, maxWeight + 1];
			// maxPrices[k, s] is the maximum total price for all the items in the backpack with total weight up to s with first k items included 
			for (int k = 1; k <= items.Count(); k++)
			{
				for (int s = 1; s <= maxWeight; s++)
				{
					if (items.ElementAt(k - 1).Weight <= s)
						maxPrices[k, s] = Math.Max(maxPrices[k - 1, s], maxPrices[k - 1, s - items.ElementAt(k - 1).Weight] + items.ElementAt(k - 1).Price);
					else
						maxPrices[k, s] = maxPrices[k - 1, s];
				}
			}

			return maxPrices[items.Count(), maxWeight];
		}
	}
}
