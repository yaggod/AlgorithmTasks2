﻿using GraphParser;

namespace Task_03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph graph = GraphParser.GraphParser.GetFromFile(@"..\..\..\..\GraphParser\graph.txt", true);
			Console.WriteLine(graph + "\n\n");

			HashSet<int> visitedNodes = new();
			List<IEnumerable<int>> components = new();		
			
			for(int i = 0; i < graph.Size; i++)
			{
				if (visitedNodes.Contains(i))
					continue;
				
				var subResult = Task_02.WidthSearch.GetAllNodesDistances(graph, i);
				visitedNodes.UnionWith(subResult.Keys);
				components.Add(subResult.Keys);
			}

			foreach(var component in components)
			{
                Console.WriteLine(String.Join(" ", component));
            }
		}
	}
}