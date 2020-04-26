using System;
using System.Collections.Generic;
using TowerOfHanoi.Utilities;

namespace TowerOfHanoi.Printers
{
    public abstract class StylisedPrinter : ITowerOfHanoiPrinter
    {
        public abstract void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings);

        protected void Print(TowerOfHanoiGame game, PrintStyleSettings printStyleSettings, char horizontalLine, char verticalLine, char topLeftCorner, char topRightCorner, char bottomLeftCorner, char bottomRightCorner, char horizontalUpIntersection, char horizontalDownIntersection)
        {
            int diskWidth = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = game.GetMaxHeight();

            int horizontalPadding = printStyleSettings.HorizontalPadding;
            string emptySpace = new string(' ', horizontalPadding);

            int verticalPadding = printStyleSettings.VerticalPadding;
            string verticalPaddingPart = horizontalLine + new string(' ', diskWidth + 2 * horizontalPadding);
            string verticalPaddingLine = verticalPaddingPart.Repeat(TowerOfHanoiGame.TowerCount) + horizontalLine;

            string topLine = topLeftCorner + (horizontalLine.Repeat(diskWidth + horizontalPadding * 2) + horizontalDownIntersection).Repeat(TowerOfHanoiGame.TowerCount - 1) + horizontalLine.Repeat(diskWidth + horizontalPadding * 2) + topRightCorner;

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

                    line += verticalLine + emptySpace + disk + emptySpace;
                }
                Console.WriteLine(line + verticalLine);
            }

            Console.Write((verticalPaddingLine + '\n').Repeat(verticalPadding));

            string bottomLine = bottomLeftCorner + (horizontalLine.Repeat(diskWidth + horizontalPadding * 2) + horizontalUpIntersection).Repeat(TowerOfHanoiGame.TowerCount - 1) + horizontalLine.Repeat(diskWidth + horizontalPadding * 2) + bottomRightCorner;
            Console.WriteLine(bottomLine);
        }
    }
}