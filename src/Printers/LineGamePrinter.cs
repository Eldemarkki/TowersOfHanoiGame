using System;
using System.Collections.Generic;

namespace TowerOfHanoi.Printers
{
    class LineGamePrinter : ITowerOfHanoiPrinter
    {
        public void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            int horizontalPadding = printStyleSettings.HorizontalPadding;
            string emptySpace = new string(' ', horizontalPadding);

            int spacing = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = game.GetMaxHeight();

            string topLine = "";
            topLine += "┌";

            for (int i = 0; i < TowerOfHanoiGame.TowerCount * (spacing + horizontalPadding * 2 + 1) - 1; i++)
            {
                bool isIntersection = (i + 1) % (spacing + horizontalPadding * 2 + 1) == 0;
                if (isIntersection)
                {
                    topLine += "┬";
                }
                else
                {
                    topLine += "─";
                }
            }

            topLine += "┐";

            Console.WriteLine(topLine);
            for (int i = maxHeight - 1; i >= 0; i--)
            {
                string line = "";
                for (int j = 0; j < TowerOfHanoiGame.TowerCount; j++)
                {
                    List<int> tower = game.GetTower(j);

                    int value = 0;
                    if (i < tower.Count) value = tower[i];

                    line += "│" + emptySpace + value.ToString().PadLeft(spacing) + emptySpace;
                }
                Console.WriteLine(line + "│");
            }

            string bottomLine = "";
            bottomLine += "└";

            for (int i = 0; i < TowerOfHanoiGame.TowerCount * (spacing + horizontalPadding * 2 + 1) - 1; i++)
            {
                bool isIntersection = (i + 1) % (spacing + horizontalPadding * 2 + 1) == 0;
                if (isIntersection)
                {
                    bottomLine += "┴";
                }
                else
                {
                    bottomLine += "─";
                }
            }

            bottomLine += "┘";

            Console.WriteLine(bottomLine);
        }
    }
}
