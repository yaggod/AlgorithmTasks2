using GraphParser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    public class DepthSearch
    {

		public Graph Graph {get; }
        private int[] weights;
		

        public DepthSearch(Graph graph)
        {
            Graph = graph;
            weights = new int[graph.Size];

			AssignWeights();
		}

		private void AssignWeights()
		{
			HashSet<int> visitedNodes = new();
			int currentWeight = 0;
			for (int i = 0; i < Graph.Size; i++)
			{
				if (visitedNodes.Contains(i))
					continue;
				AssignWeights(Graph, i, visitedNodes, ref currentWeight);
			}
		}

		public List<List<int>> GetComponents()
		{
			Graph inverted = Graph.GetInverted();
			HashSet<int> nodesLeft = new HashSet<int>(Enumerable.Range(0, Graph.Size));
			HashSet<int> visitedNodes = new();
			List<List<int>> components = new();


			while (nodesLeft.Count > 0)
			{
				int highestWeigthIndex = nodesLeft.First();
				for (int i = 0; i < Graph.Size; i++)
				{
					if (!nodesLeft.Contains(i))
						continue;
					if (weights[i] > weights[highestWeigthIndex])
						highestWeigthIndex = i;
				}
				List<int> component = new();
				Traverse(inverted, highestWeigthIndex, visitedNodes, component);

				nodesLeft.ExceptWith(component);
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
			foreach (int node in graph.GetAccessibleNodes(currentNode))
			{
				Traverse(graph, node, visitedNodes, destination);
			}

		}


		private void AssignWeights(Graph graph, int currentNode, HashSet<int> visitedNodes, ref int currentWeight)
		{

			visitedNodes.Add(currentNode);
			foreach (int node in graph.GetAccessibleNodes(currentNode))
			{
				if (visitedNodes.Contains(node))
					continue;
				currentWeight++;
				AssignWeights(graph, node, visitedNodes, ref currentWeight);
			}
			currentWeight++;
			weights[currentNode] = currentWeight;
		}


	}
}
