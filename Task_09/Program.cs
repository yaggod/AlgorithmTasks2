using GraphParser;

namespace Task_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int origin = 0;
            DistancesGraph graph = DistancesGraphParser.GetFromFile(@"..\..\..\..\GraphParser\distancesGraph.txt");
            var result = BellmanFordAlgorithm.GetShortestDistances(graph, origin);
            Console.WriteLine(graph);

            Console.WriteLine("\n");
            Console.WriteLine(String.Join("\n", result.Select((item, index) => $"Distance from node {origin} to node {index}: {item}")));
        }
    }
}
