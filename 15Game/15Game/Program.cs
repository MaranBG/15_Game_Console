using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gb = new GameBoard(4);
            gb.Drawer = new ConsoleDrawer();

            //first randomize the grid, else it is solved initially
            TileMover.RandomizeBoard(gb.BoardTiles, 1);

            while (!gb.IsGameOver()) 
            {
                gb.Draw();

                TileMover.MoveTile(UserInput.GetUserInput(), gb.BoardTiles);
            }

            gb.Draw();

            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}
