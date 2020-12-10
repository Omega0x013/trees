using System;

namespace trees
{
	class Program
	{
		public static void generatetrees(ref Tree[,] trees) {
			int rotation = 1;
			for (int x = 0; x<100; x++) for (int y = 0; y<100; y++) {
				// trees[x,y] = new Tree(ref rotation, true);
				trees[x,y] = new Tree(ref rotation, false);
				rotation = 1; // make sure that no rotation actually occurs
			}
		}
		static void Main() {
			Tree[,] trees= new Tree[100,100];
			generatetrees(ref trees);
			for(int x=0;x<100;x++)
			{
				for(int y=0;y<100;y++) Console.Write(trees[x,y]);
				Console.WriteLine();
			}
		}
	}
}
