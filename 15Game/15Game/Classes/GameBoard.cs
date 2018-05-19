using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Game
{
    public class GameBoard
    {
        private IBoardDrawer _Drawer;
        
        private int BoardSize;
        private List<Tile> BoardTiles { get; set; }

        internal IBoardDrawer Drawer
        {
            get
            {
                return _Drawer;
            }

            set
            {
                _Drawer = value;
            }
        }

        public GameBoard(int boardSize)
        {
            BoardSize = boardSize;
            BoardTiles = new Tile[boardSize * boardSize].ToList();

            Init();
        }

        private void Init()
        {
            for(int i = 0; i < BoardTiles.Count; i++)
            {
                BoardTiles[i] = new Tile() { Value = i + 1 };
            }

            BoardTiles[BoardTiles.Capacity - 1].Value = 0;
        }

        public void Draw()
        {
            if(Drawer == null)
            {
                Console.WriteLine("No IBoardDrawer specified!");
            } else
            {
                //draw the board using the given Drawer
                Drawer.Draw(BoardTiles);
            }

        }

    }

    public class Tile
    {
        public int Value;
        public override string ToString()
        {
            return Value > 0 ? Value.ToString() : "";
        }
    }
}
