using System;

public class Shape
{
    // Properties
    public string Name { get; init; }

    // Methods
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    // Properties
    public double Radius { get; init; }

    // Methods
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    // Properties
    public double Width { get; init; }
    public double Height { get; init; }

    // Methods
    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    // Properties
    public double Base { get; init; }
    public double Height { get; init; }

    // Methods
    public override double CalculateArea()
    {
        return (Base * Height) / 2;
    }
}

public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine($"Shape: {shape.Name}, Area: {shape.CalculateArea()}");
    }

    public static void Main()
    {
        Circle circle = new Circle { Name = "Circle", Radius = 5 };
        Rectangle rectangle = new Rectangle { Name = "Rectangle", Width = 4, Height = 6 };
        Triangle triangle = new Triangle { Name = "Triangle", Base = 3, Height = 7 };

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
