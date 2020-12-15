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
			ref Animals animals
		)
		{
			if (day % 365 == 0) animals.Year();
			if (day % 30 == 0) animals.Month();
		}
	}
}