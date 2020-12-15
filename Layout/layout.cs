using System;
namespace trees
{
    public class Layout
    {
        public static void layout(ref Tree[,] trees)
        {
            Console.Clear();
            for (int y = 1; y < 100; y++)
            {
                for (int x = 1; x < 100; x++)
                {
                    if (trees[x, y].treeType == TreeType.Maple)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    if (trees[x, y].treeType == TreeType.Fir)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    if (trees[x, y].treeType == TreeType.Spruce)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    if (trees[x, y].dove == true)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    if (trees[x, y].damage == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write("* ");
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
        }
    }
}
