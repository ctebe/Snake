using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalWall
    {
        private int startPosition;
        private int endPosition;
        private int x;
        private readonly char symbol;
        private Point currentPoint;
        public VerticalWall(int startPosition, int endPosition, int x)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.x = x;
            symbol = (char)Skin.Wall;
            currentPoint = null;
        }
        public void Draw()
        {
            for (int i = startPosition; i < endPosition; i++)
            {
                currentPoint = new Point(x, i, symbol);
                GameArea.Walls.Add(currentPoint);
                currentPoint.Draw();
            }
        }
    }
}
