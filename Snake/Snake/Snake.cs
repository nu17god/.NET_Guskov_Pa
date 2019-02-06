using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        private Direction direction;

        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;

            pointsList = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pointsList.Add(p);
            }
        }

        public void Move()
        {
            Point tail = pointsList.First();
            pointsList.Remove(tail);
            Point head = GetNextPoint();
            pointsList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pointsList.Last();
            Point nextPoint = new Point(head);

            nextPoint.Move(1, direction);

            return nextPoint; 
        }

        public void ReadKey (ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
        }

        public bool IsHitTail()
        {
            var head = pointsList.Last();
            for (int i = 0; i < pointsList.Count - 2; i++)
            {
                if (head.IsHit(pointsList[i]))
                    return true;
            }
            return false;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();

            if (head.IsHit(food))
            {
                food.Sign = head.Sign;
                pointsList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
