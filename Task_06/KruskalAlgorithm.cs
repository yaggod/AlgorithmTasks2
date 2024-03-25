using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GraphParser;

namespace Task_06
{
    public static class KruskalAlgorithm
    {
        public static DistancesGraph GetMinimumSpanningTree(DistancesGraph originalGraph)
        {
            DistancesGraph result = new(originalGraph.Size);
            IEnumerable<DistancesGraph.Edge> sortedEdges = originalGraph.GetAllEdges().OrderBy(item => item.Distance);
            int addedEdgesCount = 0;
            int currentEdgeIndex = 0;

            while(addedEdgesCount + 1 < originalGraph.Size && currentEdgeIndex < sortedEdges.Count())
            {
                DistancesGraph.Edge currentEdge = sortedEdges.ElementAt(currentEdgeIndex++);
                result.AddConnection(currentEdge);
                addedEdgesCount++;
                if (result.ContainsCycles())
                {
                    result.RemoveConnection(currentEdge);
                    addedEdgesCount--;
                }
            }

            return result;
        }
    }
}
