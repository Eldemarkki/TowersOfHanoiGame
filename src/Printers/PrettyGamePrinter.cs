using System;
using System.Collections.Generic;
using TowerOfHanoi.Utilities;

namespace TowerOfHanoi.Printers
{
    public class PrettyGamePrinter : ITowerOfHanoiPrinter
    {
        public void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            int diskWidth = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = game.GetMaxHeight();

            int horizontalPadding = printStyleSettings.HorizontalPadding;
            string emptySpace = new string(' ', horizontalPadding);

            int verticalPadding = printStyleSettings.VerticalPadding;
            string verticalPaddingPart = "|" + new string(' ', diskWidth + 2 * horizontalPadding);
            string verticalPaddingLine = verticalPaddingPart.Repeat(TowerOfHanoiGame.TowerCount) + "|";

            string topLine = new string('-', TowerOfHanoiGame.TowerCount * (diskWidth + horizontalPadding * 2 + 1) + 1);

            Console.WriteLine(topLine);
            Console.Write((verticalPaddingLine + '\n').Repeat(verticalPadding));

            for (int i = maxHeight - 1; i >= 0; i--)
            {
                string line = "";
                for (int j = 0; j < TowerOfHanoiGame.TowerCount; j++)
                {
                    List<int> tower = game.GetTower(j);

                    int value = 0;
                    if (i < tower.Count) value = tower[i];

                    line += "|" + emptySpace + value.ToString().PadLeft(diskWidth) + emptySpace;
                }
                Console.WriteLine(line + "|");
            }

            Console.Write((verticalPaddingLine + '\n').Repeat(verticalPadding));

            string bottomLine = new string('-', TowerOfHanoiGame.TowerCount * (diskWidth + horizontalPadding * 2 + 1) + 1);
            Console.WriteLine(bottomLine);
        }
    }
}
