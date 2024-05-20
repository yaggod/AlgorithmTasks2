using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_16
{
	public class BackpackItem
	{
		public int Weight { get; set; }
		public int Price { get; set; }


		public BackpackItem(int weight, int price)
		{
			Weight = weight;
			Price = price;
		}

		public override string ToString()
		{
			return $"{Weight} for {Price}$";
		}
	}
}
