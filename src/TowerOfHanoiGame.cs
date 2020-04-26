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

        private Stack<(int, int)> moveHistory;

        private ITowerOfHanoiPrinter printer;

        public int DiskCount => diskCount;
        public static int TowerCount => towerCount;

        public TowerOfHanoiGame(int diskCount)
        {
            printer = new PipeGamePrinter();

            towers = new List<int>[towerCount];
            moveHistory = new Stack<(int, int)>();

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
                if (addToHistory) moveHistory.Push((sourceTowerIndex, targetTowerIndex));

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

            (int, int) move = moveHistory.Pop();
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
            printer.Print(this);            
        }

        public int GetBestPossibleMoveCount()
        {
            return (int)Math.Pow(2, diskCount) - 1;
        }

        public int GetMoveCount()
        {
            return moveHistory.Count;
        }
    }
}
