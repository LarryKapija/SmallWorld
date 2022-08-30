

using System.Drawing;
using SmallWorld.Services;
using SmallWorld.Utils;

IFindNeighbors _FindNeighbors = new FindNeighbors();

PointF[] points =
{
    new PointF(0.0f, 0.0f),
    new PointF(10.1f, -10.1f),
    new PointF(-12.2f, 12.2f),
    new PointF(38.3f, 38.3f),
    new PointF(79.99f, 179.99f),
};


//Find the neighbors of the array order by the "Latitude" and "Longitude"
var ordererNeighbors= await Task.WhenAll(
    _FindNeighbors.CalculateNeighbors(points.OrderBy(x => x.X).ToArray()), 
    _FindNeighbors.CalculateNeighbors(points.OrderBy(y => y.Y).ToArray())
    );

var xOrdererNeighbors = ordererNeighbors[0];
var yOrdererNeighbors = ordererNeighbors[1];

//Find the shortest path and write to the console
foreach (var point in points)
{
    var x_distance = xOrdererNeighbors[point].Sum(x => x.Item2);
    var y_distance = yOrdererNeighbors[point].Sum(y => y.Item2);

    if (x_distance < y_distance)
    {
        Console.WriteLine($"{points.IndexOf(point) + 1} {string.Join(",", xOrdererNeighbors[point].Select(x => points.IndexOf(x.Item1) + 1))}");
        continue;
    }

    Console.WriteLine($"{points.IndexOf(point) + 1} {string.Join(",", yOrdererNeighbors[point].Select(x => points.IndexOf(x.Item1) + 1))}");
}