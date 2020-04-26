using System;
using System.Collections.Generic;
using TowerOfHanoi.Utilities;

namespace TowerOfHanoi.Printers
{
    class PipeGamePrinter : ITowerOfHanoiPrinter
    {
        public void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            int diskWidth = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = game.GetMaxHeight();

            int horizontalPadding = printStyleSettings.HorizontalPadding;
            string emptySpace = new string(' ', horizontalPadding);

            int verticalPadding = printStyleSettings.VerticalPadding;
            string verticalPaddingPart = "║" + new string(' ', diskWidth + 2 * horizontalPadding);
            string verticalPaddingLine = verticalPaddingPart.Repeat(TowerOfHanoiGame.TowerCount) + "║";

            string topLine = "╔" + ("═".Repeat(diskWidth + horizontalPadding * 2) + "╦").Repeat(TowerOfHanoiGame.TowerCount-1) + "═".Repeat(diskWidth + horizontalPadding * 2) + "╗";

            Console.WriteLine(topLine);
            Console.Write((verticalPaddingLine + '\n').Repeat(verticalPadding));

            for (int i = maxHeight - 1; i >= 0; i--)
            {
                string line = "";
                for (int j = 0; j < TowerOfHanoiGame.TowerCount; j++)
                {
                    List<int> tower = game.GetTower(j);

                    string disk = new string(' ', diskWidth);
                    if (i < tower.Count)
                    {
                        disk = tower[i].ToString().PadLeft(diskWidth);
                    }

                    line += "║" + emptySpace + disk + emptySpace;
                }
                Console.WriteLine(line + "║");
            }

            Console.Write((verticalPaddingLine + '\n').Repeat(verticalPadding));

            string bottomLine = "╚" + ("═".Repeat(diskWidth + horizontalPadding * 2) + "╩").Repeat(TowerOfHanoiGame.TowerCount - 1) + "═".Repeat(diskWidth + horizontalPadding * 2) + "╝";
            Console.WriteLine(bottomLine);
        }
    }
}
