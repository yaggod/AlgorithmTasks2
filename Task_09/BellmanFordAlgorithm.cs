using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphParser;

namespace Task_09
{
    internal class BellmanFordAlgorithm
    {
        internal static float[] GetShortestDistances(DistancesGraph graph, int originNode)
        {
            if (originNode < 0 || originNode >= graph.Size)
                throw new ArgumentOutOfRangeException(nameof(originNode));

            float[] knownDistances = new float[graph.Size];
            HashSet<int> visitedNodes = new HashSet<int>();
            for (int i = 0; i < graph.Size; i++)
                knownDistances[i] = (i == originNode) ? 0 : float.PositiveInfinity;

            var allAccessibleNodes = Enumerable.Range(0, graph.Size).Select(node => graph.GetAccessibleNodes(node)).ToArray();

            for(int i = 0; i < graph.Size; i ++)
                for(int startingNode = 0; startingNode < graph.Size; startingNode++)
                {
                    IEnumerable<int> accessibleNodes = allAccessibleNodes[startingNode];
                    foreach(int endingNode in accessibleNodes)
                    {
                        int distance = graph.GetConnection(startingNode, endingNode).Distance;
                        knownDistances[endingNode] = Math.Min(knownDistances[endingNode], knownDistances[startingNode] + distance);
                    }
                }
            return knownDistances;
        }

    }
}
