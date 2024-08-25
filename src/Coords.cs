using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace snake_game_console.src
{
    internal class Coords
    {
        private int _X;
        private int _Y;
        public int X { get { return _X; } }
        public int Y { get { return _Y; } }

        public Coords(Coords coords)
        {
            _X = coords.X;
            _Y = coords.Y;
        }
        public Coords(int x, int y)
        {
            _X = x;
            _Y = y;
        }

        // generates new coordinates
        public void GenerateNew()
        {
            _X = new Random().Next(1, MAP_SIZE_X - 1);
            _Y = new Random().Next(1, MAP_SIZE_Y - 1);
        }

        public void Set(Coords _coords)
        {
            if (_coords.X >= MAP_SIZE_X || _coords.X <= 0 || _coords.Y >= MAP_SIZE_X || _coords.Y <= 0)
                throw new Exception("Out of range!");
            
            _X = _coords.X;
            _Y = _coords.Y;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !(GetType().Equals(obj.GetType())))
                return false;

            Coords other = obj as Coords;
            return (other.X == X) && other.Y == Y;

        }
    }
}
