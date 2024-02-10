using System;
using System.IO;

namespace GraphParser
{
	public class GraphParser
	{
		public static Graph GetFromFile(string filePath)
		{
			string[] lines = File.ReadAllLines(filePath);
			int expectedLength = lines.Length;
			Graph graph = new Graph(expectedLength);
			for (int i = 0; i < expectedLength; i++)
			{
				string[] valueStrings = lines[i].Split();
				if (valueStrings.Length != expectedLength)
					throw new InvalidOperationException("Graph matrix can not be non-square");

                for(int j = 0; j < valueStrings.Length; j++)
				{ 
					int value = int.Parse(valueStrings[j]);
					graph.AddConnection(i, j, value != 0);
                }
            }

			return graph;
		}
	}
}
