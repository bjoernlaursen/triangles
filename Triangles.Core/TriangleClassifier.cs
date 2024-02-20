namespace Triangles.Core;

public static class TriangleClassifier
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
        if (double.IsNaN(sideABLength))
            throw new ArgumentOutOfRangeException(nameof(sideABLength), "Value must not be double.NaN");
        
        if (double.IsNaN(sideACLength))
            throw new ArgumentOutOfRangeException(nameof(sideACLength), "Value must not be double.NaN");
        
        if (double.IsNaN(sideBCLength))
            throw new ArgumentOutOfRangeException(nameof(sideBCLength), "Value must not be double.NaN");
        
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideABLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideACLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideBCLength);

        if (Math.Abs(sideABLength - sideACLength) < lengthComparisonPrecision &&
            Math.Abs(sideABLength - sideBCLength) < lengthComparisonPrecision)
            return TriangleType.Equilateral;

        if (Math.Abs(sideABLength - sideACLength) < lengthComparisonPrecision ||
            Math.Abs(sideABLength - sideBCLength) < lengthComparisonPrecision ||
            Math.Abs(sideBCLength - sideACLength) < lengthComparisonPrecision)
            return TriangleType.Isosceles;

        return TriangleType.Scalene;
    }

    public static TriangleType GetTriangleTypeFromInternalAngles(
        double aDegrees,
        double bDegrees,
        double cDegrees,
        double degreeComparisonPrecision = 0.0000001)
    {
        if (aDegrees is not (> 0 and < 180))
            throw new ArgumentOutOfRangeException(nameof(aDegrees),
                $"Value ({aDegrees}) must be greater than 0 and less than 180");
        
        if (bDegrees is not (> 0 and < 180))
            throw new ArgumentOutOfRangeException(nameof(bDegrees),
                $"Value ({bDegrees}) must be greater than 0 and less than 180");
        
        if (cDegrees is not (> 0 and < 180))
            throw new ArgumentOutOfRangeException(nameof(cDegrees),
                $"Value ({cDegrees}) must be greater than 0 and less than 180");

        if (Math.Abs(aDegrees + bDegrees + cDegrees - 180d) > degreeComparisonPrecision)
            throw new ArgumentException("Internal angles of a triangle must add up to 180 within specified precision");

        if (Math.Abs(aDegrees - bDegrees) < degreeComparisonPrecision &&
            Math.Abs(aDegrees - cDegrees) < degreeComparisonPrecision)
            return TriangleType.Equilateral;

        if (Math.Abs(aDegrees - bDegrees) < degreeComparisonPrecision ||
            Math.Abs(aDegrees - cDegrees) < degreeComparisonPrecision ||
            Math.Abs(cDegrees - bDegrees) < degreeComparisonPrecision)
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

        var abLength = Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        var acLength = Math.Sqrt(Math.Pow(c.X - a.X, 2) + Math.Pow(c.Y - a.Y, 2));
        var bcLength = Math.Sqrt(Math.Pow(c.X - b.X, 2) + Math.Pow(c.Y - b.Y, 2));
        
        
        return GetTriangleTypeFromSideLengths(abLength, acLength, bcLength);
    }
}