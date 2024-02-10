using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphParser
{
	public class Graph
	{
		private readonly bool[][] _graphMatrix;
        
        public int Size
        {
            get;
        }

        public bool IsIndirect
        {
            get;
        }


        public Graph(int size, bool isIndirect = false)
        {
			Size = size;
            IsIndirect = isIndirect;

            _graphMatrix = new bool[size][];

            for (int i = 0; i < size; i++)
            {
                _graphMatrix[i] = new bool[size];
            }   
        }

        public void AddConnection(int from, int to, bool isConnected)
        {
            _graphMatrix[from][to] = isConnected;
            if(IsIndirect)
				_graphMatrix[to][from] = isConnected;

		}

        public IEnumerable<int> GetAccessibleNodes(int from)
        {
            for(int i = 0; i < Size; i++)
            {
                if (i == from)
                    continue;

                if (_graphMatrix[from][i])
                    yield return i;
            }
        }

        public IEnumerable<int> GetAccessibleToTargetNodes(int target)
        {
            for(int i = 0; i < Size; i++)
            {
                if (_graphMatrix[i][target])
                    yield return i;
            }
        }
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < Size; i++)
            {
                stringBuilder.AppendLine(String.Join(" ", _graphMatrix[i].Select(value => value ? '1' : '0')));
            }

            return stringBuilder.ToString();
        }
	
    
    }
}
