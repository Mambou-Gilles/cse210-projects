
class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you overcame a great challenge.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something really difficult."
        };
    private List<string>  _questions = new List<string>
        {
            "How did you feel when it was complete?",
            "What is your favorite thing about this experience?",
            "What did you learn from this experience?",
            "How has this experience influenced your decisions in life?"
        };

    // Constructor initializes the prompts and questions list
    public ReflectingActivity() : base("Reflection", "This activity will guide you through reflecting on significant life moments and asking thoughtful questions.")
    {
        
    }

    // Run method for the reflecting activity
    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);  // Show a spinner for 3 seconds
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DisplayQuestions();


        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
    }

    private void DisplayQuestions()
    {
        for (int i = 0; i < _questions.Count; i++)
        {
            string question = GetRandomQuestion(); // Get a random question
            Console.Write($"> {question} ");
            ShowSpinner(10); // Spinner for reflection time
            
        }
    }
}
