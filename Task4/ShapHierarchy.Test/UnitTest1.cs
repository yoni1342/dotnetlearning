using Xunit;

namespace ShapeHerarchy.Tests
{
    public class ShapeTests
    {
        [Fact]
        public void Circle_CalculateArea_ShouldReturnCorrectArea()
        {
            // Arrange
            Circle circle = new Circle("Circle", 5);

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.Equal(78.53981633974483, area);
        }

        [Fact]
        public void Rectangle_CalculateArea_ShouldReturnCorrectArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle("Rectangle", 4, 6);

            // Act
            double area = rectangle.CalculateArea();

            // Assert
            Assert.Equal(24, area);
        }

        [Fact]
        public void Triangle_CalculateArea_ShouldReturnCorrectArea()
        {
            // Arrange
            Triangle triangle = new Triangle("Triangle", 3, 7);

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.Equal(10.5, area);
        }
    }
}
