using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        private int mapWidght;
        private int mapHeight;
        private char sign;

        private Random random = new Random();

        public FoodCreator(int widght, int height, char sign)
        {
            mapWidght = widght;
            mapHeight = height;
            this.sign = sign;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidght - 2);
            int y = random.Next(2, mapHeight - 2);

            return new Point(x, y, sign);
        }


    }
}
