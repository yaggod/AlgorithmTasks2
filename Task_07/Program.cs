using GraphParser;

namespace Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DistancesGraph graph = DistancesGraphParser.GetFromFile(@"..\..\..\..\GraphParser\distancesGraph.txt");
            var result = PrimAlgorithm.GetMinimumSpanningTree(graph);
            Console.WriteLine(result);
        }
    }
}
