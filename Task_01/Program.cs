using System.Drawing;

namespace Task_01
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter points count: ");
			int count = int.Parse(Console.ReadLine());

			var points = GetPointsFromUser(count); 

			var result = GrahamAlgorithm.GetConvexHull(points);

			Console.WriteLine(PointsString(result, true));
			Console.WriteLine("\n\n");
			Console.WriteLine(PointsString(points.Except(result)));
		}

		private static List<Point> GetPointsFromUser(int count)
		{
			List<Point> points = new();
			for(int i = 0; i < count; i++)
			{
				try
				{
					Console.Write($"Enter point[{i}]: ");
					string input = Console.ReadLine().Trim();
					string[] subStrings = input.Split(';');
					int x = int.Parse(subStrings[0]);
					int y = int.Parse(subStrings[1]);

					points.Add(new Point(x, y));
				}
				catch
				{
                    Console.WriteLine("Incorrect format!\n\tThe correct one is \n\t\t\tx;y");
					i--;
                }
            }

			return points;
		}

		private static List<Point> GetRandomPoints(int count = 200, int range = 50)
		{
			List<Point> points = new List<Point>();
			Random random = new();

			for (int i = 0; i < count; i++)
			{
				int x = random.Next(-range, range);
				int y = random.Next(-range, range);
				points.Add(new Point(x, y));
			}

			return points;
		}

		private static string PointsString(IEnumerable<Point> points, bool shouldEnclose = false)
		{
			// this format is useful for the https://yotx.ru website
			string result = String.Join("", points.Select(point => $"({point.X};{point.Y})"));
			if (shouldEnclose)
			{
				Point first = points.First();
				result += $"({first.X};{first.Y})";
			}

			return result;
		}
	}
}