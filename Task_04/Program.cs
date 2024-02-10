using GraphParser;

namespace Task_04
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph graph = GraphParser.GraphParser.GetFromFile(@"..\..\..\..\GraphParser\graph.txt", true);
			Console.WriteLine(graph + "\n\n");

			var components = DepthSearch.GetComponents(graph);
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