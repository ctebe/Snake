using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        private Point body;
        private readonly char skin;
        public Food(char skin)
        {
            Random random = new Random();
            int x = random.Next(1, GameArea.Width - 1);
            int y = random.Next(1, GameArea.Height - 1);
            body = new Point(x, y, skin);
            this.skin = skin;
            GameArea.Food = this;
        }
        public void Draw()
        {
            body.Draw();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            var point = obj as Point;
            return body.X == point.X && body.Y == point.Y;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
