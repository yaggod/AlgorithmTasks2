using System.Drawing;
using System.Xml.XPath;

namespace Task_01
{
	public class GrahamAlgorithm
	{
		public static IEnumerable<Point> GetConvexHull(IEnumerable<Point> points)
		{
			if (points.Count() < 3)
				throw new ArgumentException(nameof(points));

			Point origin = points.OrderBy(point => point.Y).ThenBy(point => point.X).First();
			IEnumerable<Point> sortedPoints = GetOrderedByAnglePoints(points.Skip(origin, 1), origin).ToList();


			return GetConvexHull(sortedPoints, origin);
		}

		private static IEnumerable<Point> GetConvexHull(IEnumerable<Point> sortedPoints, Point origin)
		{
			Stack<Point> result = new Stack<Point>();
			Point lastPoint = sortedPoints.First();
			Point prelastPoint = origin;

			result.Push(prelastPoint);
			result.Push(lastPoint);

			foreach (Point currentPoint in sortedPoints.Skip(1))
			{
				while (result.Count > 2 && IsRightRotation(prelastPoint, lastPoint, currentPoint))
				{
					result.Pop();
					lastPoint = result.Pop();
					prelastPoint = result.Peek();
					result.Push(lastPoint);
				}
				result.Push(currentPoint);
				prelastPoint = lastPoint;
				lastPoint = currentPoint;
			}

			return result;
		}

		private static bool IsRightRotation(Point prelastPoint, Point lastPoint, Point currentPoint)
		{
			int deltaX1 = lastPoint.X - prelastPoint.X;
			int deltaY1 = lastPoint.Y - prelastPoint.Y;
			int deltaX2 = currentPoint.X - lastPoint.X;
			int deltaY2 = currentPoint.Y - lastPoint.Y;
			return (deltaX1 * deltaY2 - deltaY1 * deltaX2) < 0;
		}

		private static IEnumerable<Point> GetOrderedByAnglePoints(IEnumerable<Point> points, Point origin)
		{
			return points.Distinct().OrderByDescending(point => GetAngle(point, origin)).ThenBy(point => GetDistanceSquare(point, origin));
		}

		private static double GetAngle(Point point, Point origin)
		{
			int x = point.X - origin.X;
			int y = point.Y - origin.Y;

			return Math.Atan2(x, y);
		}

		private static double GetDistanceSquare(Point point1, Point point2)
		{
			int x = point1.X - point2.X;
			int y = point1.Y - point2.Y;

			return x * x + y * y;
		}
	}
}
