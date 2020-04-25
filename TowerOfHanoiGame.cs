using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    public class TowerOfHanoiGame
    {
        private const int towerCount = 3;

        private List<int>[] towers;
        private int diskCount;

        private Queue<(int, int)> moveHistory;

        public TowerOfHanoiGame(int diskCount)
        {
            towers = new List<int>[towerCount];
            moveHistory = new Queue<(int, int)>();

            this.diskCount = diskCount;

            towers[0] = Enumerable.Range(1, diskCount).Reverse().ToList();
            for (int i = 1; i < towerCount; i++)
            {
                towers[i] = new List<int>(diskCount);
            }
        }

        public bool Move(int sourceTowerIndex, int targetTowerIndex)
        {
            return Move(sourceTowerIndex, targetTowerIndex, true);
        }

        private bool Move(int sourceTowerIndex, int targetTowerIndex, bool addToHistory)
        {
            List<int> sourceTower = towers[sourceTowerIndex];
            List<int> targetTower = towers[targetTowerIndex];

            int sourceTowerTopMost = int.MaxValue;
            if (sourceTower.Count != 0) sourceTowerTopMost = sourceTower[sourceTower.Count - 1]; // Top-most disk of source tower

            int targetTowerTopMost = int.MaxValue;
            if (targetTower.Count != 0) targetTowerTopMost = targetTower[targetTower.Count - 1]; // Top-most disk of target tower

            if (sourceTowerTopMost == -1) return false;

            if (sourceTowerTopMost < targetTowerTopMost)
            {
                if(addToHistory) moveHistory.Enqueue((sourceTowerIndex, targetTowerIndex));
                
                sourceTower.RemoveAt(sourceTower.Count - 1);
                targetTower.Add(sourceTowerTopMost);
                Print();

                return true;
            }

            return false;
        }

        public bool Undo()
        {
            if (moveHistory.Count == 0) return false;

            (int, int) move = moveHistory.Dequeue();
            Move(move.Item2, move.Item1, false);
            return true;
        }

        public bool IsOver()
        {
            // Skip the first tower, and check if any of the other towers length is the disk count.
            return towers.Skip(1).Any(l => l.Count == diskCount);
        }

        public List<int> GetTower(int towerIndex)
        {
            return towers[towerIndex];
        }

        public void Print()
        {
            int spacing = diskCount > 0 ? diskCount.ToString().Length : 0;
            int maxHeight = Math.Max(Math.Max(towers[0].Count, towers[1].Count), Math.Max(towers[1].Count, towers[2].Count)); // This works only for 3 towers

            Console.WriteLine("");

            for (int i = maxHeight - 1; i >= 0; i--)
            {
                string line = "";
                for (int j = 0; j < towerCount; j++)
                {
                    List<int> tower = towers[j];

                    int value = 0;
                    if (i < tower.Count) value = tower[i];

                    line += ReplaceUntilDifferentCharacter(value.ToString("D" + spacing), '0', ' ') + " ";
                }
                Console.WriteLine(line);
            }
        }

        private string ReplaceUntilDifferentCharacter(string text, char charToReplace, char replaceWith)
        {
            var result = text.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == charToReplace)
                {
                    result[i] = replaceWith;
                }
                else
                {
                    break;
                }
            }

            return new string(result);
        }
    }
}
