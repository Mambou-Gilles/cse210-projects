public class ActivityManager
{
    private List<Activity> activities;

    public ActivityManager()
    {
        activities = new List<Activity>();
    }

    public void Start()
    {
        while (true)
        {
            DisplayMenu();
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

        // Use TryParse for validation
        if (int.TryParse(input, out int choice))
        {
            switch (choice)
            {
                case 1:
                    var activity = CreateActivity();
                    if (activity != null)
                    {
                        activities.Add(activity);
                    }
                    break;
                case 2:
                    DisplaySummary();
                    break;
                case 3:
                    SaveToFile(GetFilename());
                    break;
                case 4:
                    LoadFromFile(GetFilename());
                    break;
                case 5:
                    MarkActivityCompleted();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nFitness Tracker Menu");
        Console.WriteLine("1. Create an Activity");
        Console.WriteLine("2. Display Summary");
        Console.WriteLine("3. Save to File");
        Console.WriteLine("4. Load from File");
        Console.WriteLine("5. Record Activity as Completed");
        Console.WriteLine("6. Quit");
    }

    private Activity CreateActivity()
    {
        Console.WriteLine("\nSelect the type of activity to create:");
        Console.WriteLine("1. Running");
        Console.WriteLine("2. Cycling");
        Console.WriteLine("3. Swimming");
        Console.Write("Choose activity type: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter date (dd-MM-yyyy): ");
        string date = Console.ReadLine();
        Console.Write("Enter duration in minutes: ");
        int minutes = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter distance in miles: ");
                double distance = double.Parse(Console.ReadLine());
                return new Running(date, minutes, distance);
            case 2:
                Console.Write("Enter speed in mph: ");
                double speed = double.Parse(Console.ReadLine());
                return new Cycling(date, minutes, speed);
            case 3:
                Console.Write("Enter number of laps: ");
                int laps = int.Parse(Console.ReadLine());
                return new Swimming(date, minutes, laps);
            default:
                Console.WriteLine("Invalid choice!");
                return null;
        }
    }

    private void DisplaySummary()
    {
        if (activities.Count == 0)
        {
            Console.WriteLine("No activities recorded.");
        }
        else
        {
            for (int i = 0; i < activities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i].GetSummary()}");
            }
        }
    }

    private void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var activity in activities)
            {
                activity.WriteToFile(writer);
            }
        }
        Console.WriteLine("Activities saved to file.");
    }

    private void LoadFromFile(string filename)
    {
        activities.Clear();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string type = reader.ReadLine();
                    string date = reader.ReadLine();
                    int minutes = int.Parse(reader.ReadLine());

                    switch (type)
                    {
                        case "Running":
                            double distance = double.Parse(reader.ReadLine());
                            activities.Add(new Running(date, minutes, distance));
                            break;
                        case "Cycling":
                            double speed = double.Parse(reader.ReadLine());
                            activities.Add(new Cycling(date, minutes, speed));
                            break;
                        case "Swimming":
                            int laps = int.Parse(reader.ReadLine());
                            activities.Add(new Swimming(date, minutes, laps));
                            break;
                        default:
                            Console.WriteLine("Unknown activity type in file.");
                            break;
                    }
                }
            }
            Console.WriteLine("Activities loaded from file.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }

    private void MarkActivityCompleted()
    {
        DisplaySummary();
        Console.Write("Enter the index of the activity to mark as completed: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < activities.Count)
        {
            activities[index].MarkAsCompleted();
            Console.WriteLine("Activity marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

     private string GetFilename()
    {
        Console.Write("Enter filename: ");
        return Console.ReadLine();
    }
}