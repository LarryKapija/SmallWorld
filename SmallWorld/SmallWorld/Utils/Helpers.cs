using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SmallWorld.Utils
{
    public static class Helpers
    {
        //Calculate the distance between two points
        public static double DistanceBetween(PointF origin, PointF destiny)
        {
            return Math.Sqrt(
                (Math.Pow(origin.X - destiny.X, 2) +
                Math.Pow(origin.Y - destiny.Y, 2))
                );
        }
    }
}

