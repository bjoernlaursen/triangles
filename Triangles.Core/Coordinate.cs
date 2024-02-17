namespace Triangles.Core;

public readonly record struct Coordinate
{
    public const double EqualityPrecision = 0.0000000001;

    public Coordinate(double X, double Y)
    {
        if (double.IsNaN(X))
            throw new ArgumentOutOfRangeException(nameof(X), "Value must not be double.NaN");
        
        if (double.IsNaN(Y))
            throw new ArgumentOutOfRangeException(nameof(Y), "Value must not be double.NaN");
        
        this.X = X;
        this.Y = Y;
    }

    public bool Equals(Coordinate other)
    {
        return Math.Abs(X - other.X) < EqualityPrecision &&
               Math.Abs(Y - other.Y) < EqualityPrecision;
    }

    public override int GetHashCode() =>
        HashCode.Combine(X, Y);

    public double X { get; init; }
    public double Y { get; init; }

    public void Deconstruct(out double X, out double Y)
    {
        X = this.X;
        Y = this.Y;
    }
}