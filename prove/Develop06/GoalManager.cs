//For my extra I decided to add a menu option to delete a gola from the list of goals.

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Delete Goal");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DeleteGoal();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The type of Goals are:");
        Console.WriteLine("  1. Simple Goals");
        Console.WriteLine("  2. Eternal Goals");
        Console.WriteLine("  3. Checklist Goals");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully. Press Enter to return to the menu.");
        Console.ReadLine();
    }

    public void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }


    public void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());
        Goal goal = _goals[choice - 1];
        goal.RecordEvent();

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            _score += goal.GetPoints() + checklistGoal.GetBonus();
            Console.WriteLine($"Congratulations! You've earned {goal.GetPoints() + checklistGoal.GetBonus()} points!");
        }
        else
        {
            _score += goal.GetPoints();
            Console.WriteLine($"Congratulations! You've earned {goal.GetPoints()} points!");
        }

        Console.WriteLine($"You now have {_score} points. Press Enter to return to the menu.");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully. Press Enter to return to the menu.");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            using (StreamReader inputFile = new StreamReader(filename))
            {
                if (int.TryParse(inputFile.ReadLine(), out int loadedScore))
            {
                _score = loadedScore;
            }
            else
            {
                Console.WriteLine("Invalid file format. Press Enter to return to the menu.");
                Console.ReadLine();
                return;
            }
                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    string[] parts = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2)
                {
                    Console.WriteLine($"Skipping invalid goal entry: {line}");
                    continue;
                }
                    if (parts[0].StartsWith("SimpleGoal"))
                    {
                        string[] details = parts[1].Split(" | ");
                        string name = details[0].Split(": ")[1];
                        string description = details[1].Split(": ")[1];
                        int points = int.Parse(details[2].Split(": ")[1]);
                        bool isComplete = bool.Parse(details[3]);
                        SimpleGoal goal = new SimpleGoal(name, description, points);
                        if (isComplete) goal.RecordEvent();
                        _goals.Add(goal);
                    }
                    else if (parts[0].StartsWith("EternalGoal"))
                    {
                        string[] details = parts[1].Split(" | ");
                        string name = details[0].Split(": ")[1];
                        string description = details[1].Split(": ")[1];
                        int points = int.Parse(details[2].Split(": ")[1]);
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (parts[0].StartsWith("ChecklistGoal"))
                    {
                        string[] details = parts[1].Split(" | ");
                        string name = details[0].Split(": ")[1];
                        string description = details[1].Split(": ")[1];
                        int points = int.Parse(details[2].Split(": ")[1]);
                        int bonus = int.Parse(details[3].Split(": ")[1]);
                        int target = int.Parse(details[4].Split(": ")[1]);
                        int completed = int.Parse(details[5].Split(": ")[1]);
                        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int i = 0; i < completed; i++) goal.RecordEvent();
                        _goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully. Press Enter to return to the menu.");
        }
        else
        {
            Console.WriteLine("File not found. Press Enter to return to the menu.");
        }
        Console.ReadLine();
    }

    public void DeleteGoal()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to delete. Press Enter to return to the menu.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal to delete: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal goalToDelete = _goals[choice - 1];
            _goals.RemoveAt(choice - 1);
            Console.WriteLine($"Goal \"{goalToDelete.GetShortName()}\" deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid choice. No goal deleted.");
        }

        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }

}
