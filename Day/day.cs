using System;

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
			ref Tuple<int,int> results,
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
			Tree.Harvest(ref trees, ref results);

			// DISPLAY
			if (day % 7 == 0) Layout.layout(ref trees);
		}
	}
}