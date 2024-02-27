using GraphParser;

namespace Task_05
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph graph = GraphParser.GraphParser.GetFromFile(@"..\..\..\..\GraphParser\graph.txt", false);
			Console.WriteLine(graph + "\n\n");

			var components  = new DepthSearch(graph).GetComponents();
			using (var stream = File.CreateText(@"..\..\..\result.txt"))
			{
				foreach (var component in components)
				{
					string stringToWrite = $"There are component with items: [{String.Join("; ", component)}]";
					stream.WriteLine(stringToWrite);
					Console.WriteLine(stringToWrite);
				}
			}
		}
	}
}