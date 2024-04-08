using GraphParser;

namespace Task_10
{
    internal class EulerianCyclesFinder
    {
        public static List<int> FindEulerianCycle(Graph graph)
        {
            List<int> resultPath = [0];
            if (!IsEulerian(graph))
                throw new ArgumentException(nameof(graph) + " is not eulerian");


            while (true)
            {
                int currentNode = resultPath.Last();
                IEnumerable<int> accessbileNodes = graph.GetAccessibleNodes(currentNode);
                if (!accessbileNodes.Any())
                    break;

                if (accessbileNodes.Count() == 1)
                {
                    int targetNode = accessbileNodes.First();
                    resultPath.Add(targetNode);
                    graph.AddConnection(currentNode, targetNode, false);
                }
                else
                {
                    int targetAccessibleNodesCount = AccessibleNodesCount(graph);
                    foreach(int targetNode in accessbileNodes)
                    {
                        graph.AddConnection(currentNode, targetNode, false);
                        if(AccessibleNodesCount(graph) != targetAccessibleNodesCount)
                        {
                            graph.AddConnection(currentNode, targetNode, true);
                            continue;
                        }

                        resultPath.Add(targetNode);
                        graph.AddConnection(currentNode, targetNode, false);
                        break;
                    }
                }
            }



            return resultPath;
        }

        public static bool IsEulerian(Graph graph)
        {
            if (!IsStronglyConnected(graph))
                return false;
            for (int currentNode = 0; currentNode < graph.Size; currentNode++)
            {
                int edgesCount = graph.GetAccessibleNodes(currentNode).Count();

                if (edgesCount % 2 != 0)
                    return false;
            }

            return true;
        }

        public static bool IsStronglyConnected(Graph graph)
        {
            return AccessibleNodesCount(graph) == graph.Size;
        }

        private static int AccessibleNodesCount(Graph graph)
        {
            HashSet<int> visitedNodes = new HashSet<int>();
            int currentNode = 0;
            DepthSearch(graph, visitedNodes, currentNode);
            return visitedNodes.Count;
        }

        private static void DepthSearch(Graph graph, HashSet<int> visited, int currentNode)
        {
            visited.Add(currentNode);
            foreach (int node in graph.GetAccessibleNodes(currentNode))
            {
                if (visited.Contains(node))
                    continue;

                DepthSearch(graph, visited, node);
            }
        }
    }
}
