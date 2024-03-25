using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraphParser
{
    public class DistancesGraph
    {
        private readonly ConnectionData[][] _graphDistancesMatrix;

        public struct ConnectionData
        {
            public bool IsConnected {get; }
            public int Distance { get; }
            public ConnectionData(bool isConnected, int distance)
            {
                IsConnected = isConnected;
                Distance = distance;
            }

        }
        public struct Edge
        {
            public int FirstNode { get; }
            public int SecondNode { get; }
            public int Distance { get; }
            public Edge(int firstNode, int secondNode, int distance)
            {
                FirstNode = firstNode;
                SecondNode = secondNode;
                Distance = distance;
            }
        }

        public int Size
        {
            get;
        }

        public DistancesGraph(int size)
        {
            Size = size;
            _graphDistancesMatrix = new ConnectionData[size][];

            for (int i = 0; i < size; i++)
            {
                _graphDistancesMatrix[i] = new ConnectionData[size];
            }
        }

        public void AddConnection(int from, int to, int distance)
        {
            ConnectionData data = new ConnectionData(true, distance);
            _graphDistancesMatrix[from][to] = data;
            _graphDistancesMatrix[to][from] = data;
        }

        public void AddConnection(Edge edge)
        {
            AddConnection(edge.FirstNode, edge.SecondNode, edge.Distance);
        }

        public void RemoveConnection(int from, int to)
        {
            ConnectionData data = default;
            _graphDistancesMatrix[from][to] = data;
            _graphDistancesMatrix[to][from] = data;
        }
        public void RemoveConnection(Edge edge)
        {
            RemoveConnection(edge.FirstNode, edge.SecondNode);
        }


        public IEnumerable<Edge> GetAllEdges()
        {
            for (int i = 0; i < Size; i++)
            {
                for(int j = i + 1; j < Size; j++)
                {
                    if (_graphDistancesMatrix[i][j].IsConnected)
                        yield return new Edge(i, j, _graphDistancesMatrix[i][j].Distance);
                }
            }
        }

        public IEnumerable<int> GetAccessibleNodes(int from)
        {
            for (int i = 0; i < Size; i++)
            {
                if (i == from)
                    continue;

                if (_graphDistancesMatrix[from][i].IsConnected)
                    yield return i;
            }
        }

        public bool ContainsCycles()
        {
            HashSet<int> visitedNodes = new HashSet<int>();

            for (int i = 0; i < Size; i++)
            {
                if (visitedNodes.Contains(i))
                    continue;

                if (ContainsCycles(i, -1, visitedNodes))
                    return true;
            }

            return false;
        }

        private bool ContainsCycles(int currentNode, int parentNode, HashSet<int> visitedNodes)
        {
            visitedNodes.Add(currentNode);
            foreach (int node in GetAccessibleNodes(currentNode))
            {
                if (!visitedNodes.Contains(node))
                {
                    if (ContainsCycles(node, currentNode, visitedNodes))
                        return true;
                }
                else if (node != parentNode)
                    return true;
            }

            return false;
        }

    }




    public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                stringBuilder.AppendLine(String.Join(" ", _graphDistancesMatrix[i].Select(value => value.IsConnected ? value.Distance.ToString() : "0" )));
            }

            return stringBuilder.ToString();
        }
    }
}
