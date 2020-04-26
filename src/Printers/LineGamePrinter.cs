using System;
using System.Collections.Generic;

namespace TowerOfHanoi
{
    class LineGamePrinter : ITowerOfHanoiPrinter
    {
        public void Print(TowerOfHanoiGame game)
        {
            int spacing = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = Math.Max(Math.Max(game.GetTower(0).Count, game.GetTower(1).Count), Math.Max(game.GetTower(1).Count, game.GetTower(2).Count)); // This works only for 3 towers

            string topLine = "";
            topLine += "┌";

            for (int i = 0; i < 3 * spacing + 8; i++)
            {
                bool isIntersection = (i + 1) % (spacing + 3) == 0;
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

                    line += "│ " + StringUtilities.ReplaceUntilDifferentCharacter(value.ToString("D" + spacing), '0', ' ') + " ";
                }
                Console.WriteLine(line + "│");
            }

            string bottomLine = "";
            bottomLine += "└";

            for (int i = 0; i < 3 * spacing + 8; i++)
            {
                bool isIntersection = (i + 1) % (spacing + 3) == 0;
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
