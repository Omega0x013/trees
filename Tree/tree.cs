using System;
using System.Collections.Generic;

namespace trees
{
	public sealed class Tree
	{
		int age;
		public bool dove;
		public bool damage, fire;
		public readonly TreeType treeType;

		// Final impl
		public bool harvestable {
			get => !dove && treeType switch {
			TreeType.Maple => false,
			TreeType.Fir => (age >= 9125u) && (age <= 25550u),
			TreeType.Spruce => (age >= 32850u) && (age <= 54750u),
			_ => false,
		};}

		/**
		 * If it's
		 *  - Maple
		 *  - 4 years or older
		 *  - Harvesting Date
		 */
		public bool tappable {
			get =>
			!dove
			&& (treeType == TreeType.Maple)
			&& (age >= 1460)
			&& (age % 730 == 0);
		}

		public bool removeable { get => damage || harvestable; }

		// Tree -> uint

		public Tree(ref int rotation, bool anydeer, ref Random r) {
			// Random r = new Random();
			age = 0;
			// damage = r.Next(0,1) == 0; // 50:50 change of protection or damage
			// damage = (calculate_protection ? anydeer : false);
			damage = anydeer && (r.Next(0,1) == 0);
			dove = r.Next(0,50) == 0; // 1 / 50 chance of dove in tree
			fire = false;
			treeType = ((rotation % 3) == 0)
				? TreeType.Maple
				: (
					(r.Next(0,100) <= 20)
					? TreeType.Spruce :
					TreeType.Fir
				);
			rotation++;
		}

		public static implicit operator string(Tree tree) => tree.damage
		? "\u001b[30;1mX\u001b[0;0m"
		: tree.treeType switch {
			TreeType.Fir => "\u001b[32mf\u001b[0;0m",
			TreeType.Spruce => "\u001b[32;1ms\u001b[0;0m",
			TreeType.Maple => "\u001b[31;1mm\u001b[0;0m",
			_ => " ",
		};

		public override string ToString() => this;
		// utilise implicit conversion

		public static void Harvest(ref Tree[,] trees, ref Pair<int, int> results, ref int rotation, bool anydeer, ref Random r)
		{
			/**
			 * Composed of 3 stages
			 * 
			 * 1. Tap
			 * 2. Detect
			 * 3. Remove & Replant
			*/
			// List<Pair<int, int>> targetTrees = new List<Pair<int, int>>();
			int v = 10;
			for(int x=0;x<100;x++)
				for(int y=0;y<100;y++) {
				if (trees[x,y].tappable) results.First++;
				// if (trees[x,y].removeable) targetTrees.Add(new Pair<int, int>(x,y));
				if (trees[x,y].removeable && x > 0) {
					results.Second += trees[x,y].treeType switch {
						TreeType.Fir => 1,
						TreeType.Spruce => 2,
						_ => 0
					}; // add log
					v -= trees[x,y].treeType switch {
						TreeType.Fir => 1,
						TreeType.Spruce => 2,
						_ => 0
					}; // reduce tree count
					trees[x,y] = new Tree(ref rotation, anydeer, ref r);
				}
				trees[x,y].age++;
			}
		}

		public static Tuple<int, int, int> CountTrees(ref Tree[,] trees) {
			int[] results = new int[3];
			// Fir, Spruce, Maple
			for (int x=0;x<100;x++)
				for(int y=0;y<100;y++)
					results[
						trees[x,y].treeType switch {
							TreeType.Fir => 0,
							TreeType.Spruce => 1,
							TreeType.Maple => 2,
							_ => 0,
						}
					]++;

			return new Tuple<int, int, int>(results[0], results[1], results[2]);
		}
	}

	public enum TreeType {Fir,Spruce,Maple}
	// 00, 01, 10

	public sealed class Pair<T1, T2>
	{
		public T1 First {get; set;}
		public T2 Second {get; set;}

		public Pair(T1 f, T2 s) {
			First = f;
			Second = s;
		}
	}
}