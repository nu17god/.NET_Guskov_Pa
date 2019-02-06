using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        private int x;
        private int y;
        private char sign;
        #region
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public char Sign
        {
            get
            {
                return sign;
            }

            set
            {
                sign = value;
            }
        }
        #endregion

        public Point()
        {
        }

        public Point(int x, int y, char sign)
        {
            X = x;
            Y = y;
            Sign = sign;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Sign = point.Sign;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                X = X + offset;
            }
            else if (direction == Direction.LEFT)
            {
                X = X - offset;
            }

            else if (direction == Direction.UP)
            {
                Y = Y - offset;
            }

            else if (direction == Direction.DOWN)
            {
                Y = Y + offset;
            }
        }

        public void Clear()
        {
            sign = ' ';
            Draw();
        }

        internal bool IsHit(Point food)
        {
            return food.X == this.x && food.Y == this.Y; 
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sign);
        }
    }
}
