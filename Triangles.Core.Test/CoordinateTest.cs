namespace Triangles.Core.Test;

public class CoordinateTest
{
    public class ObjectConstruction
    {
        [Fact]
        public void When_X_is_NaN_then_throw()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Coordinate(double.NaN, 1));
            Assert.Contains("X", exception.Message);
        }        
        
        [Fact]
        public void When_Y_is_NaN_then_throw()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Coordinate(1, double.NaN));
            Assert.Contains("Y", exception.Message);
        }

        [Fact]
        public void Constructor_assigns_X_from_argument_X_and_Y_from_argument_Y()
        {
            var x = 24;
            var y = 42;
            var actual = new Coordinate(x, y);
            Assert.Multiple(() =>
            {
                Assert.Equal(x, actual.X);
                Assert.Equal(y, actual.Y); 
            });
        }
    }
    
    public class Equality
    {
        [Fact]
        public void When_coordinates_coordinates_difference_is_smaller_than_defined_precision_Then_they_are_considered_equal()
        {
            var difference = Coordinate.EqualityPrecision - double.Epsilon;
            var one = new Coordinate();
            var other = new Coordinate(one.X + difference, one.Y + difference);
            
            Assert.NotEqual(other, one);
        }
        
        [Fact]
        public void When_coordinates_coordinates_difference_is_larger_than_defined_precision_Then_they_are_not_considered_equal()
        {
            var difference = Coordinate.EqualityPrecision + double.Epsilon;
            var one = new Coordinate();
            var other = new Coordinate(one.X + difference, one.Y + difference);
            
            Assert.NotEqual(other, one);
        }
    }
}