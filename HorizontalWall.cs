using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalWall
    {
        private int startPosition;
        private int endPosition;
        private int y;
        private readonly char symbol;
        private Point currentPoint;
        public HorizontalWall(int startPosition, int endPosition, int y)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.y = y;
            symbol = (char)Skin.Wall;
            currentPoint = null;
        }
        public void Draw()
        {
            for (int i = startPosition; i < endPosition; i++)
            {
                currentPoint = new Point(i, y, symbol);
                GameArea.Walls.Add(currentPoint);
                currentPoint.Draw();
            }
        }
    }
}
