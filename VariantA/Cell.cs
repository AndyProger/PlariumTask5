using System;

namespace PlariumTask4
{
    public class Cell : IComparable<Cell>
    {
        public Point2D LeftUpPoint { get; private set; }
        public Point2D LeftDownPoint { get; private set; }
        public Point2D RightUpPoint { get; private set; }
        public Point2D RightDownPoint { get; private set; }

        public Cell(int leftUpX, int leftUpY)
        {
            LeftUpPoint = new Point2D(leftUpX, leftUpY);
            LeftDownPoint = new Point2D(leftUpX, leftUpY + 5);

            RightUpPoint = new Point2D(leftUpX + 5, leftUpY);
            RightDownPoint = new Point2D(leftUpX + 5, leftUpY + 5);
        }

        public double lengthToPoint(Point2D p)
        {
            double centerX = LeftUpPoint.X + 5.0 / 2.0;
            double centerY = LeftUpPoint.Y + 5.0 / 2.0;

            return Math.Sqrt((p.X - centerX) * (p.X - centerX) + (p.Y - centerY) * (p.Y - centerY));
        }

        public override string ToString() => new Point2D(LeftUpPoint.X, LeftUpPoint.Y).ToString();

        /* 
         * логика сравнения клеток для SortedDictionary
         * сравниваются не координаты, а их расстояние до центра
        */
        public int CompareTo(Cell other)
        {
            double otherLength = other.lengthToPoint(new Point2D(0, 0));
            double length = lengthToPoint(new Point2D(0, 0));

            if (length > otherLength)
                return 1;
            else
                return -1;
        }
    }
}
