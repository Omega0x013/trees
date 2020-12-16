using System;

namespace trees
{
	static class Fires
	{
		// Entry point to fires code,
		
		
		public static void fires(ref Tree[,] trees, ref int wind, ref Random randint, ref int rotation, bool anydeer) 
		{
			// Josh, you're up
			// this calculates which trees will catch fire and sets them to damaged
			// trees have a 15% chance to survive the fire
			// the first loop runs to set the initial trees on fire
			// the second loop then runs to spread the fire depending on wind direction
			bool new_fire = false;
			int x = 0;
			int y = 0;
			for (int i = 0; i < 10000; i++)
			{
				if (trees[x, y].fire != true)
				{
					// Random randint = new Random();
					int rand = randint.Next(1, 1000000);
					if (rand == 1)
					{
						trees[x, y].fire = true;
						new_fire = true;
					}
						if (x == 100)
						{
						y++;
						x = 0;
					}
				}
			}

			x = 0;
			y = 0;

			while (new_fire == true & x <= 100 & y <= 100)
			{
				new_fire = false;
				if (trees[x, y].fire == true)
				{
					new_fire = true;
					if (wind == 0)
					{
						trees[x + 1, y].fire = true;
						trees[x, y + 1].fire = true;
						trees[x + 1, y + 1].fire = true;
					}
					if (wind == 1)
					{
						trees[x + 1, y].fire = true;
						trees[x + 1, y - 1].fire = true;
						trees[x, y - 1].fire = true;
					}
					if (wind == 2)
					{
						trees[x, y - 1].fire = true;
						trees[x - 1, y - 1].fire = true;
						trees[x, y - 1].fire = true;
					}
					if (wind == 3)
					{
						trees[x - 1, y].fire = true;
						trees[x - 1, y + 1].fire = true;
						trees[x, y + 1].fire = true;
					}
					y++;
					x++;
					// Random randint = new Random();
					// int rand = randint.Next(15, 100);
					// if (rand >= 15)
					// {
					// 	trees[x, y].damage = true;
					// }
					// trees[x, y].fire = false;
				}
				for (int i = 0; i < 0; i++) if(trees[x, y].fire) {
					if (randint.Next(0,100) >= 15) trees[x,y].fire = false;
					else trees[x,y] = new Tree(ref rotation, anydeer, ref randint);
				}
			}
		}
	}
}