using GraphParser;

namespace Task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = GraphParser.GraphParser.GetFromFile(@"..\..\..\..\GraphParser\graph.txt", true);
            Console.WriteLine(graph);
            try
            {
                Console.WriteLine(String.Join(" -> ", EulerianCyclesFinder.FindEulerianCycle(graph).Select(item => item + 1)));
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
