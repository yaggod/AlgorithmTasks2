using GraphParser;

namespace Task_15
{
	internal class GraphColorizer
	{
		public static int[] Colorize(Graph graph)
		{
			List<int> allColors = new List<int>();
			int[] graphColors = new int[graph.Size];
			for (int currentNode = 0; currentNode < graph.Size; currentNode++)
			{
				foreach (int color in allColors)
				{
					bool isCorrectNode = true;
					foreach (int secondNode in graph.GetAccessibleNodes(currentNode))
						if (graphColors[secondNode] == color)
							isCorrectNode = false;
					if (isCorrectNode)
					{
						graphColors[currentNode] = color;
						break;
					}
				}
				if (graphColors[currentNode] == 0)
				{
					int newColor = allColors.Count() + 1;
					graphColors[currentNode] = newColor;
					allColors.Add(newColor);
				}
			}
			return graphColors;
		}
	}
}