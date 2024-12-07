using System;

/*
        As part of my enhancement of the program, I added a user-defined filename system for saving and loading the activity log.
        - The user is prompted to enter a filename for the activity log at the start of the program.
        - The ActivityLog system now supports loading from and saving to the specified log file.
        - Allows tracking of how many times each activity is performed (Breathing, Listing, Reflection).
        - Includes functionality to view the activity log and clear it when desired.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("This program helps you track your mindfulness activities, such as Breathing, Listing, and Reflection exercises.");
        Console.WriteLine("You can view your activity log, clear it if needed, or exit the program at any time.");
        Console.WriteLine("To get started, please enter a filename to save your activity log.");
        Console.WriteLine("If the file already exists, the program will load your previous log. Otherwise, a new log file will be created.");
        Console.WriteLine();
        Console.Write("Enter the filename for your activity log (e.g., activity_log.txt): ");
        string logFileName = Console.ReadLine();
        ActivityLog activityLog = new ActivityLog(logFileName);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflection Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Clear Activity Log");
            Console.WriteLine("6. Exit");
            
            Console.Write("Choose an activity (1-6): ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    new BreathingActivity().Run();
                    activityLog.IncrementActivity("Breathing Activity");
                    break;
                case 2:
                    new ListingActivity().Run();
                    activityLog.IncrementActivity("Listing Activity");
                    break;
                case 3:
                    new ReflectingActivity().Run();
                    activityLog.IncrementActivity("Reflection Activity");
                    break;
                case 4:
                    activityLog.DisplayLog();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    activityLog.ClearLog();
                    Console.WriteLine("Activity log has been cleared.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}