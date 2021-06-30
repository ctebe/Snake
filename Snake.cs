using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private Direction _direction;
        private Dictionary<ConsoleKey, Direction> _controlKeys;
        private List<Point> _bodyElements;
        private Point _tail;
        private Point _head;
        private char _skin;
        public Snake(int x, int y, char skin, Direction direction)
        {
            _controlKeys = new Dictionary<ConsoleKey, Direction>();
            _controlKeys.Add(ConsoleKey.W, Direction.UP);
            _controlKeys.Add(ConsoleKey.A, Direction.LEFT);
            _controlKeys.Add(ConsoleKey.S, Direction.DOWN);
            _controlKeys.Add(ConsoleKey.D, Direction.RIGHT);

            _skin = skin;
            _bodyElements = new List<Point>();

            _tail = new Point(x, y, skin);
            _head = _tail += direction;

            _bodyElements.Add(_tail);
            _bodyElements.Add(_head);
            _direction = direction;
            GameArea.Snake = this;
        }
        public void Move()
        {
            _tail = _bodyElements.First();
            _bodyElements.Remove(_tail);
            _head = NextPoint();
            _bodyElements.Add(_head);
            _tail.Clear();
            _head.Draw();

            var elementsWithoutHead = _bodyElements.ToList();
            elementsWithoutHead.Remove(_head);

            foreach (var point in elementsWithoutHead)
            {
                if (point.Equals(_head))
                {
                    GameArea.IsOpen = false;
                    Decompose();
                }
            }

            CheckCollideWithWall();
            if (GameArea.Food.Equals(_head))
            {
                GrowUp();
                GameArea.CreateFood();
            }
        }
        public void Draw()
        {
            foreach (var point in _bodyElements)
            {
                point.Draw();
            }
        }
        public void HandleKey(ConsoleKey key)
        {
            _controlKeys.TryGetValue(key, out _direction);
        }
        private Point NextPoint()
        {
            Point head = _bodyElements.Last();
            Point next = new Point(head);
            next += _direction;
            return next;
        }
        private void CheckCollideWithWall()
        {
            foreach (var wallItem in GameArea.Walls)
            {
                if (wallItem.Equals(_head))
                {
                    GameArea.IsOpen = false;
                    Decompose();
                }
            }
        }
        private void Decompose()
        {
            foreach (var point in _bodyElements)
            {
                _skin = (char)Skin.Death;
                point.Symbol = _skin;
                point.Draw();
            }
        }
        private void GrowUp()
        { 
            Point point = _head;
            _bodyElements.Add(point);
        }
    }
}