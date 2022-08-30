using System;
using System.Drawing;

namespace SmallWorld.Services
{
    public interface IFindNeighbors
    {
        // Find the next 3 neighbors of a point
        Task<Dictionary<PointF, (PointF, double)[]>> CalculateNeighbors(PointF[] points);
    }
}