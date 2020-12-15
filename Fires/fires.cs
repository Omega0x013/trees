namespace trees
{
	static class Fires
	{
		// Entry point to fires code,
		
		
		public static void fires(ref uint[] trees, ref int wind) 
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
				if (tree[x, y].fire != true)
				{
					Random randint = new Random();
					int rand = randint.Next(1, 1000000);
					if (rand == 1)
					{
						tree[x, y].fire = true;
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

			while (new_fire == true)
			{
				new_fire = false;
				for (int i = 0; i < 10000; i++)
				{
					if (tree[x, y].fire == true)
					{
						new_fire = true;
						if (wind == 0)
						{
							tree[x + 1, y].fire = true;
							tree[x, y + 1].fire = true;
							tree[x + 1, y + 1].fire = true;
						}
						if (wind == 1)
						{
							tree[x + 1, y].fire = true;
							tree[x + 1, y - 1].fire = true;
							tree[x, y - 1].fire = true;
						}
						if (wind = 2)
						{
							tree[x, y - 1].fire = true;
							tree[x - 1, y - 1].fire = true;
							tree[x, y - 1].fire = true;
						}
						if (wind = 3)
						{
							tree[x - 1, y].fire = true;
							tree[x - 1, y + 1].fire = true;
							tree[x, y + 1].fire = true;
						}
					}
				    	Random randint = new Random();
				    	int rand = randint.Next(15, 100);
				    	if (rand >= 15)
				    	{
						tree[x, y].damaged = true;
				    	}
				    		tree[x, y].fire = false;
					}
				}
			}
		}
	}
}
