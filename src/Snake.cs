using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Program;

namespace snake_game_console.src
{
    internal class Snake
    {
        private int length = 1;
        private List<Coords> tail = new List<Coords>();
        private Direction direction;
        private Coords head = new Coords(5, 5);
        public Direction Direction
        {

            get { return direction; }
            set {
                if (value.GetType() == typeof(Direction)) direction = value;
            }
        }
        public int Score { get { return length - 1; } }
        public Coords Head { get { return head; } }
        public Snake()
        {
            /*head.GenerateNew();*/
            tail.Add(new Coords(head.X, head.Y - 1));
            direction = Direction.Down;
        }

        // increasing tail length
        public void Eat()
        {
            length++;
            tail.Add(new Coords(tail.Last()));
        }

        // move snake on 1 position
        public void Move()
        {
            if (IsHeadOnTaill())
                throw new Exception("Don't eat yourself!");

            for (int i = length - 1; i >= 0; --i)
            {
                if (i == 0)
                {
                    tail[i].Set(head);
                }
                else
                {
                    tail[i].Set(tail[i - 1]);
                }
            }

            switch (direction)
            {
                case Direction.Up:
                    if (head.Y == 1) throw new Exception("You lose!");
                    head.Set(new Coords(head.X, head.Y - 1));
                    break;

                case Direction.Down:
                    if (head.Y == MAP_SIZE_Y - 1) throw new Exception("You lose!");
                    head.Set(new Coords(head.X, head.Y + 1));
                    break;

                case Direction.Left:
                    if (head.X == 1) throw new Exception("You lose!");
                    head.Set(new Coords(head.X - 1, head.Y));
                    break;

                case Direction.Right:
                    if (head.X == MAP_SIZE_X - 1) throw new Exception("You lose!");
                    head.Set(new Coords(head.X + 1, head.Y));
                    break;

                default:
                    throw new Exception("Direction error!");
            }
        }

        // is snake have a point
        public bool PositionEquals(Coords _coords)
        {
            if (_coords.Equals(head)) return true;

            for (int i = length - 1; i >= 0; --i)
            {
                if (tail[i].Equals(_coords)) return true;
            }

            return false;
        }

        private bool IsHeadOnTaill()
        {
            for (int i = length - 1; i >= 0; --i)
            {
                if (tail[i].Equals(head)) return true;
            }

            return false;
        }

    }

}
