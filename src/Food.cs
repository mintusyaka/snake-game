using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace snake_game_console.src
{
    internal class Food
    {
        private Coords coords = new Coords(1, 1);
        public Coords Coords { get { return coords; } }
        public Food()
        {
            coords.GenerateNew();
        }

        public void changePos()
        {
            coords.GenerateNew();
        }

    }
}
