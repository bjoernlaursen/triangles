namespace Triangles.Core;

public class TriangleClassifier
{
    public static TriangleType GetTriangleTypeFromSideLengths(
        int sideABLength,
        int sideACLength,
        int sideBCLength)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideABLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideACLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideBCLength);

        if (sideABLength == sideACLength && sideABLength == sideBCLength)
            return TriangleType.Equilateral;

        if (sideABLength == sideACLength || sideABLength == sideBCLength || sideBCLength == sideACLength)
            return TriangleType.Isosceles;

        return TriangleType.Scalene;
    }

    public static TriangleType GetTriangleTypeFromSideLengths(
        double sideABLength,
        double sideACLength,
        double sideBCLength,
        double lengthComparisonPrecision = 0.0000001)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideABLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideACLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideBCLength);

        if (Math.Abs(sideABLength - sideACLength) < lengthComparisonPrecision && Math.Abs(sideABLength - sideBCLength) < lengthComparisonPrecision)
            return TriangleType.Equilateral;

        if (Math.Abs(sideABLength - sideACLength) < lengthComparisonPrecision || Math.Abs(sideABLength - sideBCLength) < lengthComparisonPrecision || Math.Abs(sideBCLength - sideACLength) < lengthComparisonPrecision)
            return TriangleType.Isosceles;

        return TriangleType.Scalene;
    }

    public static TriangleType GetTriangleTypeFromCoordinates(
        Coordinate a,
        Coordinate b,
        Coordinate c)
    {
        if (a == b)
            throw new ArgumentException(
                $"All coordinates must be unique." +
                $"Arguments {nameof(a)}: {a} and {nameof(b)}: {b} are identical");
        
        if (a == c)
            throw new ArgumentException(
                $"All coordinates must be unique." +
                $"Arguments {nameof(a)}: {a} and {nameof(c)}: {c} are identical");
        
        if (b == c)
            throw new ArgumentException(
                $"All coordinates must be unique." +
                $"Arguments {nameof(b)}: {b} and {nameof(c)}: {c} are identical");

        var abLength = Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        var acLength = Math.Sqrt(Math.Pow(c.x - a.x, 2) + Math.Pow(c.y - a.y, 2));
        var bcLength = Math.Sqrt(Math.Pow(c.x - b.x, 2) + Math.Pow(c.y - b.y, 2));
        
        
        return GetTriangleTypeFromSideLengths(abLength, acLength, bcLength);
    }

    public readonly record struct Coordinate(int x, int y);
}