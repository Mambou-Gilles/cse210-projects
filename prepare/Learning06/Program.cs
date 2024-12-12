using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning06 World!");

        List<Shape> shapes = new List<Shape>();
        
        Square sq1 = new Square("Green", 2);
        shapes.Add(sq1);
        
        // string col = sq1.GetColor();
        // double are = sq1.GetArea();
        
        // Console.WriteLine($"The color is {col} and the area of the square is {are}");

        Circle c1 = new Circle("Blue", 4);
        shapes.Add(c1);
        // string cirCol = c1.GetColor();
        // double cirAre = c1.GetArea();
        // Console.WriteLine($"The color is {cirCol} and the area of the circle is {cirAre}");

        Rectangle r1 = new Rectangle("Red", 3, 4);
        shapes.Add(r1);
        // string r1Col = r1.GetColor();
        // double r1Are = r1.GetArea();
        // Console.WriteLine($"The color is {r1Col} and the area of the rectangle is {r1Are}");

        

        foreach (Shape s in shapes)
        {
            // Notice that all shapes have a GetColor method from the base class
            string color = s.GetColor();

            // Notice that all shapes have a GetArea method, but the behavior is
            // different for each type of shape
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }

    }
}