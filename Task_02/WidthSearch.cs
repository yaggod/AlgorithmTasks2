using GraphParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
	internal class WidthSearch
	{
		public static Dictionary<int, int> GetAllNodesDistances(Graph graph, int startingNode)
		{
			Dictionary<int, int> visitedNodes = new();
			Queue<int> nodesToHandle = new();

			visitedNodes.Add(startingNode, 0);
			nodesToHandle.Enqueue((startingNode));

			while(nodesToHandle.Count > 0)
			{
				int currentNode = nodesToHandle.Dequeue();
				int currentNodeDistance = visitedNodes[currentNode];

				foreach(int targetNode in graph.GetAccessibleNodes(currentNode))
				{
					if (visitedNodes.ContainsKey(targetNode))
						continue;

					visitedNodes.Add(targetNode, currentNodeDistance + 1);
					nodesToHandle.Enqueue((targetNode));
				}
			}

			return visitedNodes;
		}
	}
}
