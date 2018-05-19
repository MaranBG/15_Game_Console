using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Game
{
    public interface IBoardDrawer
    {
        void Draw(List<Tile> Board);
    }
}
