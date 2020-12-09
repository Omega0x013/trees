namespace trees
{
	public sealed class Tree
	{
		ushort age;
		bool prot, damage, dove; // protected is a keyword
		TreeType treeType;

		public bool harvestable() {
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

		/**
		 * If it's
		 *  - Maple
		 *  - 4 years or older
		 *  - Harvesting Date
		 */
		public bool tappable() => (treeType == TreeType.Maple) && (age >= 1460) && (age % 730 == 0);

		// Tree -> uint
		public static implicit operator uint(Tree t) {
			uint o = 0u;

			return o;
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
			TreeType t = bits[1] ? TreeType.Maple : (bits[0] ? TreeType.Spruce : TreeType.Fir);
			return new Tree() {
				// XX--
				// >>
				// --XX
				// (ushort)
				// XX
				age = (ushort)(s >> 16),
				prot = bits[4],
				dove = bits[3],
				damage = bits[2],
			};
		}
	}

	public enum TreeType {Fir,Spruce,Maple}
	// 00, 01, 10
}