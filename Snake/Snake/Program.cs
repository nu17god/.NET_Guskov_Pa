using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        const int ConsoleHeight = 25;
        const int ConsoleWidght = 80;

        static void Main(string[] args)
        {
            Console.SetWindowSize(ConsoleWidght, ConsoleHeight);
            Console.SetBufferSize(ConsoleWidght, ConsoleHeight);

            #region Frame
            Walls walls = new Walls(ConsoleWidght, ConsoleHeight);
            walls.Draw();
            #endregion

            Point snakeTail = new Point(4, 5, '*');
            Snake snake = new Snake(snakeTail, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(ConsoleWidght, ConsoleHeight, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.ReadKey(key.Key);
                }
            }

            WriteGameOver();
        }

        static void WriteGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(ConsoleWidght / 2 - 5, ConsoleHeight / 2);
            Console.Write("Game Over!");
            Console.ReadKey();
        }
    }
}
