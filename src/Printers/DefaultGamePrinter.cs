﻿using System;
using System.Collections.Generic;

namespace TowerOfHanoi
{
    public class DefaultGamePrinter : ITowerOfHanoiPrinter
    {
        public void Print(TowerOfHanoiGame game)
        {
            int spacing = game.DiskCount > 0 ? game.DiskCount.ToString().Length : 0;
            int maxHeight = game.GetMaxHeight();

            for (int i = maxHeight - 1; i >= 0; i--)
            {
                string line = "";
                for (int j = 0; j < TowerOfHanoiGame.TowerCount; j++)
                {
                    List<int> tower = game.GetTower(j);

                    int value = 0;
                    if (i < tower.Count) value = tower[i];

                    line += value.ToString().PadLeft(spacing) + " ";
                }
                Console.WriteLine(line);
            }
        }
    }
}