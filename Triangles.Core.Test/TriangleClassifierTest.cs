namespace Triangles.Core.Test;

public class TriangleClassifierTest
{
    [Theory]
    [InlineData(0, 2, 2)]
    [InlineData(2, 0, 2)]
    [InlineData(2, 2, 0)]
    [InlineData(-2, 2, 2)]
    [InlineData(2, -2, 2)]
    [InlineData(2, 2, -2)]
    public void When_any_side_length_is_zero_or_negative_Then_throw(
        int sideABLength,
        int sideACLength,
        int sideBCLength) =>
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            TriangleClassifier.GetTriangleTypeFromSideLengths(
                sideABLength: sideABLength,
                sideACLength: sideACLength,
                sideBCLength: sideBCLength));

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 1, 2)]
    [InlineData(2, 3, 1)]
    public void When_no_sides_are_equal_Then_triangle_is_scalene(
        int sideABLength,
        int sideACLength,
        int sideBCLength)
    {
        var actual = TriangleClassifier.GetTriangleTypeFromSideLengths(
            sideABLength,
            sideACLength,
            sideBCLength);
        
        Assert.Equal(TriangleType.Scalene, actual);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(1, 1, 2)]
    [InlineData(1, 2, 1)]
    public void When_exactly_two_sides_are_equal_Then_triangle_is_isosceles(
        int sideABLength,
        int sideACLength,
        int sideBCLength)
    {
        var actual = TriangleClassifier.GetTriangleTypeFromSideLengths(
            sideABLength,
            sideACLength,
            sideBCLength);
        
        Assert.Equal(TriangleType.Isosceles, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
    public void When_all_sides_are_equal_Then_triangle_is_equilateral(
        int sideABLength,
        int sideACLength,
        int sideBCLength)
    {
        var actual = TriangleClassifier.GetTriangleTypeFromSideLengths(
            sideABLength,
            sideACLength,
            sideBCLength);
        
        Assert.Equal(TriangleType.Equilateral, actual);
    }
}