using GraphParser;

namespace Task_06
{
    public class DepthSearch
    {
        public static bool ContainsCycles(DistancesGraph graph)
        {
            HashSet<int> visitedNodes = new();

            for (int i = 0; i < graph.Size; i++)
            {
                if (visitedNodes.Contains(i))
                    continue;

                if (ContainsCycles(graph, i, -1, visitedNodes))
                    return true;
            }

            return false;
        }

        private static bool ContainsCycles(DistancesGraph graph, int currentNode, int parentNode, HashSet<int> visitedNodes)
        {
            visitedNodes.Add(currentNode);
            foreach (int node in graph.GetAccessibleNodes(currentNode))
            {
                if (!visitedNodes.Contains(node))
                {
                    if (ContainsCycles(graph, node, currentNode, visitedNodes))
                        return true;
                }
                else if (node != parentNode)
                    return true;
            }

            return false;
        }

        /*
         
         
        private static void Traverse(Graph graph, int currentNode, HashSet<int> visitedNodes, List<int> destination)
		{
			if (visitedNodes.Contains(currentNode))
				return;

			visitedNodes.Add(currentNode);
			destination.Add(currentNode);
			foreach(int node in graph.GetAccessibleNodes(currentNode))
			{
				Traverse(graph, node, visitedNodes, destination);
			}
			
		}

        */

    }
}
