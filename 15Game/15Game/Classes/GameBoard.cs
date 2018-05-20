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
        public List<Tile> BoardTiles { get; set; }

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

        public bool IsGameOver()
        {
            for (int i = 1; i < BoardTiles.Count - 1; i++)
            {
                //break and return false if elements are not sequential
                if (BoardTiles[i].Value < BoardTiles[i - 1].Value)
                    return false;

            }

            return true;
        }

        private void Init()
        {
            for(int i = 0; i < BoardTiles.Count; i++)
            {
                BoardTiles[i] = new Tile(new TilePosition() {
                    X = i % BoardSize,
                    Y = i / BoardSize})
                { Value = i + 1 };
            }

            BoardTiles[BoardTiles.Capacity - 1].Value = 0;
        }

        public void Draw()
        {
            if(Drawer == null)
            {
                Console.WriteLine("No BoardDrawer specified!");
            } else
            {
                //draw the board using the given Drawer
                Console.Clear();
                Drawer.Draw(BoardTiles);
            }

        }

    }

    public class Tile
    {
        public int Value { get; set; }

        public TilePosition Position { get; set; } = new TilePosition();

        public Tile(TilePosition position)
        {
            Position = position;
        }
        public override string ToString()
        {
            return Value > 0 ? Value.ToString() : "";
        }

      
    }

    public struct TilePosition
    {
        public int X;
        public int Y;
    }
}
