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
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 30);
            GameArea.DrawWalls();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("I Love You!");

            Random random = new Random();

            Snake snake = new Snake(60, 15, (char)Skin.Life, Direction.RIGHT);
            snake.Draw();
            Food food = new Food((char)Skin.Food);
            food.Draw();

            GameArea.DoCycle();
            Console.ReadKey();
        }
    }
}