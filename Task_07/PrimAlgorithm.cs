using GraphParser;

namespace Task_07
{
    public class PrimAlgorithm
    {
        internal static DistancesGraph GetMinimumSpanningTree(DistancesGraph originalGraph)
        {
            DistancesGraph result = new(originalGraph.Size);
            HashSet<int> addedNodes = new();
            List<DistancesGraph.Edge> edgesToHandle = new();
            addedNodes.Add(0);
            edgesToHandle.AddRange(originalGraph.GetAccessibleNodesEdges(0));

            while(addedNodes.Count < originalGraph.Size)
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
                        addedNodes.Add(edge.SecondNode);
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