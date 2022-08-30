using System;
using System.Drawing;
using SmallWorld.Utils;

namespace SmallWorld.Services
{
    public class FindNeighbors : IFindNeighbors
    {
        public async Task<Dictionary<PointF, (PointF, double)[]>> CalculateNeighbors(PointF[] points)
        {
            var pointsAndNeighbors = new Dictionary<PointF, (PointF, double)[]>();

            await Task.Run(() => {foreach (var point in points)
            {
                var backPoints = new List<PointF>();
                var frontPoints = new List<PointF>();
                var distances = new List<(PointF, double)>();

                var currentIndex = points.IndexOf(point);

                //Copiying previous 3 elements if exists
                if (currentIndex > 0)
                    backPoints = points[(currentIndex > 3 ? points.Count() - currentIndex : 0)..currentIndex].ToList();

                //Copiying next 3 elements if exists
                if (currentIndex != points.Count() - 1)
                    frontPoints = points.Skip(currentIndex + 1).Take(3 - backPoints.Count()).ToList();

                //Saving the distance between backpoints and current point
                distances.AddRange(SelectDistances(backPoints, point));

                //Saving the distance between frontPoints and current point
                distances.AddRange(SelectDistances(frontPoints, point));

                pointsAndNeighbors[point] = distances.OrderBy(x => x.Item2).ToArray();

            }});

            return pointsAndNeighbors;
        }

        private IEnumerable<(PointF, double)> SelectDistances(IEnumerable<PointF> pointsList, PointF currentPoint)
        {
            var x =  pointsList.Select(x => (x, Helpers.DistanceBetween(currentPoint,x))).ToList();
            return x;
        }
    }
}

