using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gb = new GameBoard(4);
            gb.Drawer = new ConsoleDrawer();
            gb.Draw();

            Console.ReadKey();
        }
    }
}
