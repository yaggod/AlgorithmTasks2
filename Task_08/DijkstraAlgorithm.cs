﻿using GraphParser;

namespace Task_08
{
    internal class DijkstraAlgorithm
    {
        internal static float[] GetShortestDistances(DistancesGraph graph, int startingNode)
        {
            if (startingNode < 0 || startingNode >= graph.Size)
                throw new ArgumentOutOfRangeException(nameof(startingNode));

            float[] knownDistances = new float[graph.Size];
            HashSet<int> visitedNodes = new HashSet<int>();
            for (int i = 0; i < graph.Size; i++)
                knownDistances[i] = (i == startingNode) ? 0 : float.PositiveInfinity;

            var allAccessibleNodes = Enumerable.Range(0, graph.Size).Select(node => graph.GetAccessibleNodes(node)).ToArray();


            for (int i = 0; i < knownDistances.Length; i++)
            {
                int currentNode  = GetClosestNode(knownDistances, visitedNodes);
                float distanceToTheCurrentNode = knownDistances[currentNode];

                visitedNodes.Add(currentNode);

                IEnumerable<int> accessibleNodes = allAccessibleNodes[currentNode];
                foreach (int nodeToHandle in accessibleNodes)
                {
                    int distanceToHandledNode = graph.GetConnection(currentNode, nodeToHandle).Distance;
                    knownDistances[nodeToHandle] = Math.Min(knownDistances[nodeToHandle], distanceToTheCurrentNode + distanceToHandledNode);
                }
            }

            return knownDistances;
        }

        private static int GetClosestNode(float[] knownDistances, HashSet<int> visitedNodes)
        {
            int closestNode = 0;
            float distanceToTheCurrentNode = float.PositiveInfinity;
            for (int j = 0; j < knownDistances.Length; j++)
            {
                if (knownDistances[j] > distanceToTheCurrentNode || visitedNodes.Contains(j))
                    continue;

                closestNode = j;
                distanceToTheCurrentNode = knownDistances[j];
            }

            return closestNode;
        }
    }
}
