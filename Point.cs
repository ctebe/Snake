using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public const char empty = ' ';
        public Point(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Symbol = point.Symbol;
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);

        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(empty);
        }
        public static Point operator +(Point point, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    point.Y--;
                    break;
                case Direction.DOWN:
                    point.Y++;
                    break;
                case Direction.RIGHT:
                    point.X++;
                    break;
                case Direction.LEFT:
                    point.X--;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return point;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            var point = obj as Point;
            return X == point.X && Y == point.Y;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
