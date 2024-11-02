using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine()); ;

        List<int> numbers = new List<int>();

        int max = 0;
        int small_positive = 100000;

        while (number != 0)
        {
            numbers.Add(number);
            Console.Write("Please enter a number: ");
            number = int.Parse(Console.ReadLine());

        }

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        int sum = 0;
        foreach (int sumnumber in numbers)
        {
            sum += sumnumber;
        }

        double average = (double)sum / numbers.Count;
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        foreach (int i in numbers)
        {
            if (i >= 0 && i < small_positive)
            {
                small_positive = i;
            }
        }
        Console.WriteLine($"The smallest positive number is: {small_positive}");
        Console.WriteLine($"The sorted list is: ");
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    

    }
        
}