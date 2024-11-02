using System;

class Program
{
    static void Main(string[] args)
    {
        display_welcome_message();
        string name = get_user_name();
        int num = get_user_favorite_number();
        int square = square_root(num);
        displayResult(name, square);
    }
    static void display_welcome_message()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string get_user_name()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int get_user_favorite_number()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int square_root(int number)
    {
        int square = (int)Math.Pow(number, 2);
        // int square = number * number;
        return square;
    }
    static void displayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}