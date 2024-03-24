using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphParser
{
    public class DistancesGraphParser
    {
        public static DistancesGraph GetFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int expectedLength = lines.Length;
            DistancesGraph graph = new DistancesGraph(expectedLength);
            for (int i = 0; i < expectedLength; i++)
            {
                string[] valueStrings = lines[i].Split();
                if (valueStrings.Length != expectedLength)
                    throw new InvalidOperationException("Graph matrix can not be non-square");

                for (int j = 0; j < valueStrings.Length; j++)
                {
                    int valueToSet = int.Parse(valueStrings[j]);

                    graph.AddConnection(i, j, valueToSet);
                }
            }

            return graph;
        }
    }
}
