using System;
using System.Collections.Generic;
using System.Linq;

namespace _15Game
{
    public class ConsoleDrawer : IBoardDrawer
    {
        public void Draw(List<Tile> Board)
        {
            int BoardSize = Math.Sqrt(Board.Count) % 1 > 0 ? 0 : (int)Math.Sqrt(Board.Count);

            List<string> output = new List<string>() { "" };

            for (int row = 0; row < BoardSize; row++)
            {
                string sRow = "";
                for (int col = 0; col < BoardSize; col++)
                {
                    //append the block to the row
                    sRow += $"{Board[row * BoardSize + col],3} |";
                }

                //append the row to the whole output
                output.Add(new string('-', output.Max(s => s.Length)));
                output.Add(sRow);
            }

            output[1] = (new string('-', output.Max(s => s.Length)));
            output.Add(output[1]);
            output.Remove(output[0]);

            Console.WriteLine(string.Join("\n\r", output.ToArray()));
        }
    }
}
