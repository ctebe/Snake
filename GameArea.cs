using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    static class GameArea
    {
        public const int Width = 118;
        public const int Height = 29;
        public static List<Point> Walls = new List<Point>();
        public static Snake Snake;
        public static Food Food;
        public static bool IsOpen = true;
        public static void DrawWalls()
        {
            var topWall = new HorizontalWall(0, Width, 0);
            topWall.Draw();
            var downWall = new HorizontalWall(0, Width, Height);
            downWall.Draw();
            var leftWall = new VerticalWall(0, Height, 0);
            leftWall.Draw();
            var rightWall = new VerticalWall(0, Height, Width);
            rightWall.Draw();
        }
        public static void DoCycle()
        {
            while (IsOpen)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    Snake.HandleKey(key);
                }
                Snake.Move();
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(54, 14);
            Console.WriteLine("Game Over!");
            return;
        }
        public static void CreateFood()
        {
            Random random = new Random();
            Food food = new Food((char)Skin.Food);
            food.Draw();
        }
    }
}