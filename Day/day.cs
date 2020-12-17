using System;
using System.Threading.Tasks;

namespace trees
{
	// Conducts a single day
	partial class Program
	{
		public static void Day(
			int day,
			ref Tree[,] trees,
			ref Random random,
			ref Animals animals,
			ref Pair<int,int> results,
			ref int rotation
		)
		{
			// ANIMALS
			if (day % 365 == 0) animals.Year();
			if (day % 30 == 0) animals.Month();

			// RAIN/FIRES
			if (FireRisk.risk(day % 365))
				Fires.fires(
					ref trees,
					random.Next(0,3),
					ref random,
					ref rotation,
					animals.hasDeer()
				);

			// HARVEST
			Tree.Harvest(ref trees, ref results, ref rotation, animals.hasDeer(), ref random);

			// DISPLAY
			if (day % 365 == 0) {
				Console.WriteLine($"Year {day / 365}");
				Layout.layout(ref trees);
			}
		}
	}
}