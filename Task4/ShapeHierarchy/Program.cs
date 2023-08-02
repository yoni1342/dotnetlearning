namespace ShapeHerarchy;
using System;
public class Shape
{
    // Constructor
    public Shape(string name)
    {
        Name = name;
    }
    // Properties
    public string Name { get; private set; }

    // Methods
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    // Constructor
    public Circle(string name, double radius) : base(name)
    {
        Radius = radius;
    }
    // Properties
    public double Radius { get; private set; }

    // Methods
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape 
{
    // Constructor
    public Rectangle(string name, double width, double height) : base(name)
    {
        Width = width;
        Height = height;
    }
    // Properties
    public double Width { get; private set; }
    public double Height { get; private set; }

    // Methods
    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    // Constructor
    public Triangle(string name, double @base, double height) : base(name)
    {
        Base = @base;
        Height = height;
    }
    // Properties
    public double Base { get; private set; }
    public double Height { get; private set; }

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
        Shape circle = new Circle ("Circle", 5 );
        Shape rectangle = new Rectangle("Rectangle", 4, 6 );
        Shape triangle = new Triangle ("Triangle", 3, 7 );

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
