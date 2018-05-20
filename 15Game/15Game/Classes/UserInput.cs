using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Game
{
    public static class UserInput
    {
        public static int GetUserInput()
        {
            int TileNum = 0;

            //get user input
            var KeyInput = Console.ReadLine();

            //try to parse it to int
            int.TryParse(KeyInput, out TileNum);

            return TileNum;
        }
        
    }
}
