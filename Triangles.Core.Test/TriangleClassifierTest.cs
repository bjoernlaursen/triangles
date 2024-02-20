namespace Triangles.Core.Test;

public abstract class TriangleClassifierTest
{
    public class FromIntegerSideLengths
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
    public class FromDoubleSideLengths
    {
        [Theory]
        [InlineData(0d, 2d, 2d)]
        [InlineData(2d, 0d, 2d)]
        [InlineData(2d, 2d, 0d)]
        [InlineData(-2d, 2d, 2d)]
        [InlineData(2d, -2d, 2d)]
        [InlineData(2d, 2d, -2d)]
        public void When_any_side_length_is_zero_or_negative_Then_throw(
            double sideABLength,
            double sideACLength,
            double sideBCLength) =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                TriangleClassifier.GetTriangleTypeFromSideLengths(
                    sideABLength: sideABLength,
                    sideACLength: sideACLength,
                    sideBCLength: sideBCLength));
    
        [Theory]
        [InlineData(1.5, 2.5, 3.5)]
        [InlineData(3.5, 1.5, 2.5)]
        [InlineData(2.5, 3.5, 1.5)]
        public void When_no_sides_are_equal_Then_triangle_is_scalene(
            double sideABLength,
            double sideACLength,
            double sideBCLength)
        {
            var actual = TriangleClassifier.GetTriangleTypeFromSideLengths(
                sideABLength,
                sideACLength,
                sideBCLength);
            
            Assert.Equal(TriangleType.Scalene, actual);
        }
    
        [Theory]
        [InlineData(1.5, 2.5, 2.5)]
        [InlineData(1.5, 1.5, 2.5)]
        [InlineData(1.5, 2.5, 1.5)]
        public void When_exactly_two_sides_are_equal_Then_triangle_is_isosceles(
            double sideABLength,
            double sideACLength,
            double sideBCLength)
        {
            var actual = TriangleClassifier.GetTriangleTypeFromSideLengths(
                sideABLength,
                sideACLength,
                sideBCLength);
            
            Assert.Equal(TriangleType.Isosceles, actual);
        }
    
        [Theory]
        [InlineData(1.5, 1.5, 1.5)]
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue)]
        public void When_all_sides_are_equal_Then_triangle_is_equilateral(
            double sideABLength,
            double sideACLength,
            double sideBCLength)
        {
            var actual = TriangleClassifier.GetTriangleTypeFromSideLengths(
                sideABLength,
                sideACLength,
                sideBCLength);
            
            Assert.Equal(TriangleType.Equilateral, actual);
        }
    }

    public class FromInternalAngles
    {
        [Theory]
        [InlineData(0d, 60d, 60d)]
        [InlineData(60d, 0d, 60d)]
        [InlineData(60d, 60d, 0d)]
        [InlineData(-2d, 60d, 60d)]
        [InlineData(60d, -2d, 60d)]
        [InlineData(60d, 60d, -2d)]
        [InlineData(180d, 60d, 60d)]
        [InlineData(60d, 180d, 60d)]
        [InlineData(60d, 60d, 180d)]
        [InlineData(182d, 60d, 60d)]
        [InlineData(60d, 182d, 60d)]
        [InlineData(60d, 60d, 182d)]
        public void When_an_angle_is_not_greater_than_0_and_less_than_180_then_throw(
            double aDegrees,
            double bDegrees,
            double cDegrees) =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                TriangleClassifier.GetTriangleTypeFromInternalAngles(
                    aDegrees: aDegrees,
                    bDegrees: bDegrees,
                    cDegrees: cDegrees));

        [Theory]
        [InlineData(100d, 40d, 40.99d)]
        [InlineData(100d, 40d, 39.99d)]
        public void When_all_internal_angles_do_not_add_up_to_180_Then_throw(
            double aDegrees,
            double bDegrees,
            double cDegrees)
        {
            const double precision = 0.001;
            Assert.Throws<ArgumentException>(() =>
                TriangleClassifier.GetTriangleTypeFromInternalAngles(
                    aDegrees: aDegrees,
                    bDegrees: bDegrees,
                    cDegrees: cDegrees,
                    degreeComparisonPrecision: precision));
        }

        [Theory]
        [InlineData(60d, 60d, 60d, TriangleType.Equilateral)]
        [InlineData(60d, 60d, 59.9995d, TriangleType.Equilateral)]
        [InlineData(40d, 40d, 100d, TriangleType.Isosceles)]
        [InlineData(40d, 40d, 99.9995d, TriangleType.Isosceles)]
        [InlineData(20d, 40d, 120d, TriangleType.Scalene)]
        [InlineData(20d, 40d, 119.9995d, TriangleType.Scalene)]
        public void When_all_internal_angles_do_add_up_to_180_within_precision_Then_triangle_type_is_calculated(
            double aDegrees,
            double bDegrees,
            double cDegrees,
            TriangleType expectedResult)
        {
            const double precision = 0.001;
            var actual = TriangleClassifier.GetTriangleTypeFromInternalAngles(
                aDegrees: aDegrees,
                bDegrees: bDegrees,
                cDegrees: cDegrees,
                degreeComparisonPrecision: precision);
            
            Assert.Equal(expectedResult, actual);
        }
    }
    public class FromCoordinates
    {
        [Theory]
        [MemberData(nameof(TriangleTestCases))]
        public void Triangles_are_classified_by_type(
            Coordinate a,
            Coordinate b,
            Coordinate c,
            TriangleType expectedType)
        {
            var actual = TriangleClassifier.GetTriangleTypeFromCoordinates(a, b, c);
            Assert.Equal(expectedType, actual);
        }

        public static IEnumerable<object[]> TriangleTestCases() => new[]
        {
            new object[]
            {
                new Coordinate(0, 0),
                new Coordinate(2, 0),
                new Coordinate(1, 1.7320508075689),
                TriangleType.Equilateral
            },
            new object[]
            {
                new Coordinate(0, 0),
                new Coordinate(2, 0),
                new Coordinate(2, 2),
                TriangleType.Isosceles
            },
            new object[]
            {
                new Coordinate(-4, 7),
                new Coordinate(3, 6),
                new Coordinate(-2, -1),
                TriangleType.Scalene
            },
        };
    }
}