namespace trees
{
	public sealed class Tree
	{
		ushort age;
		bool protection, damage, dove; // protected is a keyword
		TreeType treeType;

		/*public bool harvestable() {
			switch (treeType)
			{
				case TreeType.Maple:
					return false; // never harvestable
				case TreeType.Fir:
					return (age >= 9125u) && (age <= 25550u); // 25yr <= age <= 70yr
				case TreeType.Spruce:
					return (age >= 32850u) && (age <= 54750u); // 90yr <= age <= 150yr
				default:
					return false; // something went wrong
			}
		}

		// Reimplemented harvestable with lambda and conditional expressions
		public bool harvestable() =>
		(treeType == TreeType.Maple) ? false : ( // Maples not harvestable
			(treeType == TreeType.Fir) // If fir
			? ((age >= 9125u) && (age <= 25550u)) // then check age conditions
			: ((age >= 32850u) && (age <= 54750u)) // else check age conditions
		);*/

		// Final impl
		public bool harvestable() => treeType switch {
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
		public bool tappable() => (treeType == TreeType.Maple) && (age >= 1460) && (age % 730 == 0);

		// Tree -> uint
		public static implicit operator uint(Tree t) {
			BitField b = new BitField(
				// XX
				// (uint)
				// --XX
				// <<
				// XX--
				((uint)t.age) << 16
			);

			/**
			 * 00
			 * 0N or 10
			 * N = 0 if Fir else 1
			 * -> true => treeType == Spruce
			 */
			b[0] = false;
			b[1] = false;
			if (t.treeType != TreeType.Maple) b[0] = t.treeType == TreeType.Spruce;
			else b[1] = true;

			b[2] = t.damage;
			b[3] = t.dove;
			b[4] = t.protection;

			return b;
		}

		// uint -> Tree
		public static implicit operator Tree(uint s) {
			BitField bits = new BitField(s);
			/**
			 * AB
			 * 00   Fir
			 * 01   Spruce
			 * 10   Maple
			 * 
			 * If A -> Maple
			 * Else
			 *     If B -> Spruce
			 *     Else -> Fir
			 */ 
			return new Tree() {
				treeType = bits[1] ? TreeType.Maple : (bits[0] ? TreeType.Spruce : TreeType.Fir),
				// XX--
				// >>
				// --XX
				// (ushort)
				// XX
				age = (ushort)(s >> 16),
				protection = bits[4],
				dove = bits[3],
				damage = bits[2],
			};
		}
	}

	public enum TreeType {Fir,Spruce,Maple}
	// 00, 01, 10
}