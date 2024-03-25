using GraphParser;

namespace Task_07
{
    public class PrimAlgorithm
    {
        internal static DistancesGraph GetMinimumSpanningTree(DistancesGraph originalGraph)
        {
            DistancesGraph result = new(originalGraph.Size);
            List<DistancesGraph.Edge> edgesToHandle = new(originalGraph.GetAccessibleNodesEdges(0));
            int addedNodesCount = 1;

            while(addedNodesCount < originalGraph.Size)
            {
                edgesToHandle.Sort((first, second) => first.Distance.CompareTo(second.Distance));
                for (int i = 0; i < edgesToHandle.Count; i++)
                {
                    DistancesGraph.Edge edge = edgesToHandle[0];
                    edgesToHandle.RemoveAt(0);
                    if (result.ContainsEdge(edge))
                        continue;
                    result.AddConnection(edge);
                    
                    if (!result.ContainsCycles())
                    {
                        addedNodesCount++;
                        edgesToHandle.AddRange(originalGraph.GetAccessibleNodesEdges(edge.SecondNode));
                        break;
                    }
                    result.RemoveConnection(edge);
                }
            }

            return result;
        }
        
        
    }
}