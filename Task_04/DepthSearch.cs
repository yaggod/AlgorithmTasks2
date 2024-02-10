using GraphParser;

namespace Task_04
{
	public class DepthSearch
	{
		public static List<List<int>> GetComponents(Graph graph)
		{
			HashSet<int> visitedNodes = new();
			List<List<int>> components = new();

			for (int i = 0; i < graph.Size; i++)
			{
				if (visitedNodes.Contains(i))
					continue;

				List<int> component = new();
				Traverse(graph, i, visitedNodes, component);
				components.Add(component);
			}

			return components;
		}

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
	}
}
