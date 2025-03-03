using System;

class Program
{
    static void Main(string[] args)
    {
        Square s1 = new Square("Green", 4);
        Console.WriteLine(s1.GetArea());

        Rectangle r1 = new Rectangle("Red", 3, 6);
        Console.WriteLine(r1.GetArea());

        Circle c1 = new Circle("Yellow", 7);
        Console.WriteLine(c1.GetArea());

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Purple", 4));
        shapes.Add(new Circle("Cyan", 3));
        shapes.Add(new Rectangle("Orange", 7, 6));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"There is a {color} shape and it has an area of {area} cm^2.");
        }

    }
}