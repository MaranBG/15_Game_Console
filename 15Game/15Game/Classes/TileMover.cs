using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15Game
{
    public static class TileMover
    {
        public static void MoveTile(int selectedTileValue, List<Tile> board, bool suppressMessages = false)
        {
            Tile Blank = board.Single(z => z.Value == 0);
            Tile Selected = board.Single(z => z.Value == selectedTileValue);

            //check if the move is possible (selected tile is next to the blank tile)
            if ((Selected.Position.X == Blank.Position.X) && 
               (Math.Abs(Selected.Position.Y - Blank.Position.Y) == 1) ||
               (Selected.Position.Y == Blank.Position.Y) &&
               (Math.Abs(Selected.Position.X - Blank.Position.X) == 1)) {
                //possible move, do it
                Blank.Value = selectedTileValue;
                Selected.Value = 0;
            } else {
                //not a possible move
                if (suppressMessages) return;

                //display a message and out a bit of a delay so it can be read
                Console.WriteLine("Illegal move! Try again.");
                Thread.Sleep(400);
            }
        }

        public static void RandomizeBoard(List<Tile> board, int numberOfMoves)
        {
            Random randomGenerator = new Random();

            //do N number of random moves
            for(int i = 0; i < numberOfMoves; i++)
            {
                Tile[] MovableTiles = GetMovableTiles(board);

                int TileNumber = MovableTiles[randomGenerator.Next(MovableTiles.Length)].Value;

                MoveTile(TileNumber, board, true);
            }
        }

        private static Tile[] GetMovableTiles(List<Tile> board)
        {
            //every tile that is next to 0 tile (on horizontal or verticla axis) can be moved
            Tile Zero = board.Single(t => t.Value == 0);

            return board.Where(t => ((Math.Abs(t.Position.X - Zero.Position.X) == 1 && t.Position.Y == Zero.Position.Y) || (Math.Abs(t.Position.Y - Zero.Position.Y) == 1 && t.Position.X == Zero.Position.X))).ToArray();
        }
    }
}
