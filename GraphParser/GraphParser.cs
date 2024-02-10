using System;
using System.IO;

namespace GraphParser
{
	public class GraphParser
	{
		public static Graph GetFromFile(string filePath, bool isIndirect = false)
		{
			string[] lines = File.ReadAllLines(filePath);
			int expectedLength = lines.Length;
			Graph graph = new Graph(expectedLength, isIndirect);
			for (int i = 0; i < expectedLength; i++)
			{
				string[] valueStrings = lines[i].Split();
				if (valueStrings.Length != expectedLength)
					throw new InvalidOperationException("Graph matrix can not be non-square");

                for(int j = 0; j < valueStrings.Length; j++)
				{ 
					bool valueToSet = int.Parse(valueStrings[j]) != 0;
					if (!valueToSet)
						continue;

					graph.AddConnection(i, j, valueToSet);			
                }
            }

			return graph;
		}
	}
}
