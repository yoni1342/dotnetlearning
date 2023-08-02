using System;
using ShapeHerarchy;
using Xunit;

namespace ShapeHerarchy.Tests
{
    public class ShapeTests
    {
        [Fact]
        public void Circle_CalculateArea_ShouldReturnCorrectArea()
        {
            // Arrange
            Circle circle = new Circle { Name = "Circle", Radius = 5 };

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.Equal(Math.PI * 25, area);
        }

        [Fact]
        public void Rectangle_CalculateArea_ShouldReturnCorrectArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle { Name = "Rectangle", Width = 4, Height = 6 };

            // Act
            double area = rectangle.CalculateArea();

            // Assert
            Assert.Equal(24, area);
        }

        [Fact]
        public void Triangle_CalculateArea_ShouldReturnCorrectArea()
        {
            // Arrange
            Triangle triangle = new Triangle { Name = "Triangle", Base = 3, Height = 7 };

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.Equal(10.5, area);
        }
    }
}
