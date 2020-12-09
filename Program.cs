using System;

namespace trees
{
	class Program
	{
		static void Main() => new Program();

		// DATA
		uint[] trees = new uint[10_000]; // Make the array on the heap

		// Entry Point for the program
		public Program() {
			/**
			 * This bit is where the program begins,
			 * 
			 * Here is where you should call tree generation and run the mainloop
			 * of the simulation.
			 * 
			 * The reason it's in a constructor is so that trees is created not on the stack,
			 * but on the heap. This will mean the program is less likely to stack overflow.
			 */
		}
	}
}
