using GraphParser;

namespace Task_15
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Graph graph = GraphParser.GraphParser.GetFromFile(@"..\..\..\..\GraphParser\graph1.txt");
			var result = GraphColorizer.Colorize(graph);
			
		}
	}
}
