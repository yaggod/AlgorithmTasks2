using GraphParser;

namespace Task_02
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph graph = GraphParser.GraphParser.GetFromFile(@"..\..\..\..\GraphParser\graph.txt");
			Console.WriteLine(graph + "\n\n");

			int startingNode = 0;
			var result = WidthSearch.GetAllNodesDistances(graph, startingNode);

			using(var stream = File.CreateText(@"..\..\..\..\Task_02\result.txt"))
			{
				foreach (int node in result.Keys)
				{
					string stringToWrite = $"Shortest distance from node {startingNode} to node {node} is {result[node]}";
					stream.WriteLine(stringToWrite);
                    Console.WriteLine(stringToWrite);
                }
			}
		}
	}
}