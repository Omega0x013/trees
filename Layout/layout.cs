using System;
using System.Text;
namespace trees
{
    public class Layout
    {
        public static void layout(ref Tree[,] trees)
        {
            Console.Clear();
			StringBuilder stringBuilder = new StringBuilder();
			string bg;
			string fg;
			for (int y = 0; y < 100; y++)
			{
				for (int x = 0; x < 100; x++) {
					// Console.BackgroundColor = trees[x,y].treeType switch {
					// 	TreeType.Maple => ConsoleColor.DarkRed,
					// 	TreeType.Fir => ConsoleColor.DarkGreen,
					// 	TreeType.Spruce => ConsoleColor.Green,
					// 	_ => ConsoleColor.Gray
					// };
					// if(trees[x,y].dove) Console.ForegroundColor = ConsoleColor.White;
					// else Console.ForegroundColor = Console.BackgroundColor;

					// if(trees[x,y].damage) Console.ForegroundColor = ConsoleColor.Red;
					bg = trees[x,y].treeType switch {
						TreeType.Maple => "\u001b[41m",
						TreeType.Fir => "\u001b[42m",
						TreeType.Spruce => "\u001b[43m",
						_ => ""
					};
					
					if(trees[x,y].dove) fg="\u001b[37;1m";
					else fg = trees[x,y].treeType switch {
						TreeType.Maple => "\u001b[31m",
						TreeType.Fir => "\u001b[32m",
						TreeType.Spruce => "\u001b[33m",
						_ => ""
					};

					if(trees[x,y].damage) fg="\u001b[31m";

					stringBuilder.AppendFormat("{0}{1}*\u001b[0m", fg, bg);
				}
				stringBuilder.Append('\n');
			}
			string v = stringBuilder.ToString();
			Console.WriteLine(v); // seeing if this will force it to be more organised
        }
    }
}
