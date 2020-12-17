using System;

namespace trees
{
	partial class Program
	{
		const int TimeLength = 365*25;
		public static void generatetrees(ref Tree[,] trees) {
			int rotation = 1;
			Random r = new Random();
			for (int x = 0; x<100; x++)
				for (int y = 0; y<100; y++) {
					// trees[x,y] = new Tree(ref rotation, true);
					trees[x,y] = new Tree(ref rotation, false, ref r);
					rotation = 1; // make sure that no rotation actually occurs
			}
		}
		static void Main() {
			Tree[,] trees= new Tree[100,100];
			generatetrees(ref trees);
			Random r = new Random();
			Animals animals = new Animals(500);
			Pair<int, int> results = new Pair<int, int>(0,0); // syrup (in trees, 3 cans per tree), logs (in tree values, fir worth one, spruce worth 2)
			int rotation = 0;

			for (
				int day = 0;
				day < TimeLength;
				day++
			) Day(
					day,
					ref trees,
					ref r,
					ref animals,
					ref results,
					ref rotation
				);

			Tuple<int, int, int> treeCounts = Tree.CountTrees(ref trees);

			Console.WriteLine("Tree Totals:");
			Console.WriteLine($" Fir    {treeCounts.Item1}");
			Console.WriteLine($" Spruce {treeCounts.Item2}");
			Console.WriteLine($" Maple  {treeCounts.Item3}");

			Console.WriteLine("Forest Products:");
			Console.WriteLine($" Syrup {results.First}");
			Console.WriteLine($" Wood  {results.Second}");
		}
	}
}
