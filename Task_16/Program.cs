using System.Diagnostics;

namespace Task_16
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<BackpackItem> items = new();
			Random random = new Random();
			for(int i = 0; i  < 10; i++)
			{
				int weight = random.Next(1, 10);
				int price = random.Next(5, 20);
				items.Add(new BackpackItem(weight, price));
			}

			BackpackProblemSolver.GetOptimalItemsForBackpack(items, 30);
			
		}
	}
}
