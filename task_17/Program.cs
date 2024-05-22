namespace Task_17
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> items = new();
			Random random = new Random();
			for (int i = 0; i < 10; i++)
			{
				items.Add(random.Next(1, 8));
			}
			var result = CratesProblemSolver.GetCratesCount(items.ToArray(), 10);
		}
	}
}
