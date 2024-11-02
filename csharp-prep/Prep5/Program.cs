using System;

class Program
{
    static void Main(string[] args)
    {
        Welcome();
        string name = Get_Name();
        int num = Get_Favorite_Number();
        int square = Square_Number(num);
        Result(name, square);
    }
    static void Welcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string Get_Name()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int Get_Favorite_Number()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int Square_Number(int number)
    {
        int square = (int)Math.Pow(number, 2);
        return square;
    }
    static void Result(string name, int square)
    {
        Console.WriteLine($"{name}, the square of you number is {square}");
    }
}