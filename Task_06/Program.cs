using GraphParser;

namespace Task_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DistancesGraph graph = GraphParser.DistancesGraphParser.GetFromFile(@"..\..\..\..\GraphParser\distancesGraph.txt");
            var result = KruskalAlgorithm.GetMinimumSpanningTree(graph);
            Console.WriteLine(result);
        }
    }
}
