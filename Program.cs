using System;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            TowerOfHanoiGame game = new TowerOfHanoiGame(4);

            Console.WriteLine("Welcome to a the 'Towers of Hanoi' game!");
            Console.WriteLine("The goal is to move the disks from the first tower to any other tower. However, you can not move a big disk on top of a smaller disk, it has to be bigger than the disk below it.");
            Console.WriteLine("You can move a disk by typing 'move <number> <number>'. The first number is the tower where you want to move the disk from, and the second number is the tower where you want to move the disk to.");

            game.Print();
            while (true)
            {
                Console.Write("> ");
                string[] commandArgs = Console.ReadLine().Trim().Split(' ');
                string command = commandArgs[0].ToLower().Trim();

                if (command == "move")
                {
                    if (commandArgs.Length != 3)
                    {
                        Console.WriteLine("You need to provide 3 parameters!");
                        continue;
                    }

                    int fromIndex = -1;
                    if (!int.TryParse(commandArgs[1], out fromIndex))
                    {
                        Console.WriteLine("The first argument was not a number!");
                        continue;
                    }

                    int toIndex = -1;
                    if(!int.TryParse(commandArgs[2], out toIndex))
                    {
                        Console.WriteLine("The second argument was not a number!");
                        continue;
                    }

                    if (fromIndex < 1 || fromIndex > 3)
                    {
                        Console.WriteLine("The first argument must be between 1 and 3!");
                        continue;
                    }

                    if (toIndex < 1 || toIndex > 3)
                    {
                        Console.WriteLine("The second argument must be between 1 and 3!");
                        continue;
                    }

                    if (!game.Move(fromIndex - 1, toIndex - 1))
                    {
                        Console.WriteLine("That's an invalid move!");
                        continue;
                    }

                    bool isOver = game.IsOver();
                    if (isOver)
                    {
                        Console.WriteLine("Game over! You moved all the disks successfully!");
                        break;
                    }
                }
                else if (command == "undo")
                {
                    if (!game.Undo())
                    {
                        Console.WriteLine("There was nothing to undo!");
                    }
                }
                else if (command == "quit")
                {
                    break;
                }
            }
        }
    }
}
