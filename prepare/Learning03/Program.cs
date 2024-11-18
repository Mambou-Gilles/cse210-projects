using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        // Fraction denom1 = new Fraction();
        // denom1.Display();

        // Fraction denom2 = new Fraction(6);
        // denom2.Display();

        // Fraction denom3 = new Fraction(6,7);
        // denom3.Display();

        Fraction denom = new Fraction();
        Console.WriteLine(denom.GetFractionString());
        Console.WriteLine(denom.GetDecimalValue());

        Fraction denom1 = new Fraction(5);
        Console.WriteLine(denom1.GetFractionString());
        Console.WriteLine(denom1.GetDecimalValue());

        Fraction denom2 = new Fraction(3,4);
        Console.WriteLine(denom2.GetFractionString());
        Console.WriteLine(denom2.GetDecimalValue());

        Fraction denom3 = new Fraction(1,3);
        Console.WriteLine(denom3.GetFractionString());
        Console.WriteLine(denom3.GetDecimalValue());

        // denom.setTop(8);
        // Console.WriteLine(denom.getTop());
        // denom.setBottom(9);
        // Console.WriteLine(denom.getBottom());
        
    }
}