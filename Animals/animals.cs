namespace trees
{
	sealed class Animals
	{
		/**
		 * Animals manages the deer and wolves
		 * 
		 * It is run with a few callbacks:
		 *  - Month
		 *  - Year
		 *  - hasDeer
		 */

		bool fences;
		int deer, wolves; // Up to you what you want to do with this
		public Animals(int deer) {
			// Constructor -- set deer & wolves
			this.deer = deer;
			wolves = 0;
			fences = false;

			// Lucas, you're up
		}

		public void Month() {
			// this is called every month
		}

		public void Year() {
			// this is called every year
		}

		// Checks if we have enough syrup to release wolves
		public void Check(int syrup) { 
			if ( (!fences) && (syrup >= 1500) )
			{
				fences = true;
				wolves = 2;
			}
		}

		// if there are any deer in the forest to damage new trees
		public bool hasDeer() => deer > 0;
	}
}