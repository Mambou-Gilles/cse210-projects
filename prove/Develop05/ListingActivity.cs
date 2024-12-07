
class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    // Constructor initializes the prompts list
    public ListingActivity() : base("Listing", "This activity will ask you to list things you are grateful for or that come to mind based on a prompt.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt proud of yourself?",
            "What are some of your favorite memories?"
        };
    }

    // Run method for the listing activity
    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);


        // Clear the screen and prepare for the activity
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(2);  // Short spinner before the prompt

        // Display a random prompt and start the countdown
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);  // Countdown before user starts listing responses

        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            GetListFromUser();
        }
        Console.WriteLine($"You listed {_count} Items.");

        Console.WriteLine();

        // End the activity
        DisplayEndingMessage();
    }

    // Get a random prompt from the list
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    // Get list item from the user and increment the count
    public void GetListFromUser()
    {
        Console.Write("> ");
        string item = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(item))
        {
            _count++;  // Increment the count for each valid response
        }
        
    }
}
