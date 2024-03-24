using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
