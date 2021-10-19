using System;
using System.Collections.Generic;

namespace PlariumTask4
{
    public class FindingCells
    {
        public const int CellSize = 5;

        public static SortedDictionary<Cell,double> FindCells(int radius)
        {
            var startXCoord = -(0 - radius) % CellSize + (0 - radius) - CellSize;
            var startYCoord = startXCoord;

            var cellsInLine = (-startXCoord - startXCoord) / CellSize;
            
            var cellsList = new List<Cell>();

            for (int i = 0; i < cellsInLine; i++)
            {
                for (int j = 0; j < cellsInLine; j++)
                {
                    cellsList.Add(new Cell(startXCoord + i * CellSize, startYCoord + j * CellSize));
                }
            }

            /*
             * была выбрана коллекция отсортированный словарь, так как координаты верхнего угла каждой клетки
             * являются уникальными, а расстояние до центра круга - нет, что идеально вписывается
             * в концепцию ключ (координаты) - значение (расстояние)
             */
            var cellsInsideCircle = new SortedDictionary<Cell, double>();
            Point2D centerPoint = new Point2D(0, 0);

            foreach (var cell in cellsList)
            {
                var isInside = IsInside(cell.LeftUpPoint, cell.LeftDownPoint, 
                                         cell.RightDownPoint, cell.RightUpPoint, 
                                         centerPoint, radius);

                if (isInside)
                {
                    var length = cell.lengthToPoint(new Point2D(0, 0));
                    cellsInsideCircle.TryAdd(cell, length);
                }
            }
            
            return cellsInsideCircle;
        }

        private static bool IsInside(Point2D lUpPoint, Point2D lDownPoint, 
                              Point2D rDownPoint, Point2D rUpPoint,
                              Point2D centerPoint, int radius)
        {
            return lUpPoint.lengthToPoint2D(centerPoint) <= radius &&
                   lDownPoint.lengthToPoint2D(centerPoint) <= radius &&
                   rDownPoint.lengthToPoint2D(centerPoint) <= radius &&
                   rUpPoint.lengthToPoint2D(centerPoint) <= radius;
        }

        static void Main(string[] args)
        {
            var dictionary = FindCells(15);

            foreach (var item in dictionary){
                Console.WriteLine("Coordinates: " + item.Key + " the distance " + item.Value);
            }
        }
    }
}
