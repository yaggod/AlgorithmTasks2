using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_17
{
	public static class CratesProblemSolver
	{
		public static int GetCratesCount(int[] itemsSizes, int crateSize)
		{
			var sortedItemsSizes = itemsSizes.OrderByDescending(x => x);
			List<int> crates = new();

			foreach(var item in sortedItemsSizes)
			{
				bool placedAny = false;
				for(int i = 0; i < crates.Count; i++)
				{
					if (crates[i] + item <= crateSize)
					{
						crates[i] += item;
						placedAny = true;
						break;
					}
				}

				if (!placedAny)
					crates.Add(item);
			}

			return crates.Count;

		}
	}
}
