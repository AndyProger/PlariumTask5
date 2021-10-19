using System;
using System.Text;

namespace PlariumTask4
{
    public class Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        // поиск расстояния до указанной точки
        public double lengthToPoint2D(Point2D otherPoint)
        {
            return Math.Sqrt(
                (otherPoint.X - X) * (otherPoint.X - X) + 
                (otherPoint.Y - Y) * (otherPoint.Y - Y));
        }

        // из-за большого количества конкатенаций использовано StringBuilder
        public override string ToString()
        {
            return new StringBuilder().Append("(" + X + ", " + Y + ")").ToString();
        }
    }
}
