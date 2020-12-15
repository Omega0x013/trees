using System;

namespace trees
{
	public sealed class Tree
	{
		int age;
		public bool dove;
		public bool damage, fire;
		public readonly TreeType treeType;

		// Final impl
		public bool harvestable() => !dove && treeType switch {
			TreeType.Maple => false,
			TreeType.Fir => (age >= 9125u) && (age <= 25550u),
			TreeType.Spruce => (age >= 32850u) && (age <= 54750u),
			_ => false,
		};

		/**
		 * If it's
		 *  - Maple
		 *  - 4 years or older
		 *  - Harvesting Date
		 */
		public bool tappable() => 
			!dove
			&& (treeType == TreeType.Maple)
			&& (age >= 1460)
			&& (age % 730 == 0);

		public bool removeable() => damage;

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
	}

	public enum TreeType {Fir,Spruce,Maple}
	// 00, 01, 10
}