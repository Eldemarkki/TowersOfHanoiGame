using System;
using System.Collections.Generic;

namespace TowerOfHanoi.Printers
{
    public class DefaultGamePrinter : ITowerOfHanoiPrinter
    {
        public void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings)
        {
            int horizontalPadding = printStyleSettings.HorizontalPadding;
            string emptySpace = new string(' ', horizontalPadding);

            int spacing = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = game.GetMaxHeight();

            Console.Write(new string('\n', printStyleSettings.VerticalPadding));

            for (int i = maxHeight - 1; i >= 0; i--)
            {
                string line = "";
                for (int j = 0; j < game.TowerCount; j++)
                {
                    List<int> tower = game.GetTower(j);

                    int value = 0;
                    if (i < tower.Count) value = tower[i];

                    line += value.ToString().PadLeft(spacing) + emptySpace;
                }

                Console.WriteLine(line.Trim());
            }

            Console.Write(new string('\n', printStyleSettings.VerticalPadding));
        }
    }
}