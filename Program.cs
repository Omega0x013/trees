using System;

namespace trees
{
	class Program
	{
		static void Main()
		{
			uint[] trees = new uint[10_000];
			GenerateTrees.generatetrees(ref trees);
			Tree t = trees[0];
		}
	}
}
