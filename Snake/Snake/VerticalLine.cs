using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yTop, int yBottom, int x, char sign)
        {
            pointsList = new List<Point>();

            for (int y = yTop; y <= yBottom; y++)
            {
                pointsList.Add(new Point(x, y, sign));
            }

        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            base.Draw();

            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
