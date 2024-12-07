
using System.Runtime.InteropServices;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor to initialize activity name, description, and duration
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Method to display the starting message
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
        Console.Write("Please enter the duration for this activity (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
       
    }

    // Method to display the ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You've successfully completed this activity.");
        ShowSpinner(6);
        Console.WriteLine();
        Console.WriteLine($"You spent {_duration} seconds on this {_name} activity.");
        ShowSpinner(6);  // Show a spinner before exiting
    }

    // Show a spinning animation for the given number of seconds
    public void ShowSpinner(int seconds)
    {
        // for (int i = 0; i < seconds; i++)
        // {
        //     Console.Write(".");
        //     Thread.Sleep(1000);  // Wait for 1 second per dot
        // }
        // Console.WriteLine();

        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        int spinnerIndex = 0;

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[spinnerIndex]);  // Print the current spinner character
            spinnerIndex = (spinnerIndex + 1) % spinner.Count;  // Move to the next spinner character
            Thread.Sleep(250); // Adjust the speed of the spinner
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);  // Move cursor back to overwrite the spinner character
        }
        Console.WriteLine(" ");
        
        
    
    }

    // Show a countdown for the given number of seconds
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
