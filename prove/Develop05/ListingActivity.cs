
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

  
    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);


        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(2);  

        
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);  

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

   
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    
    public void GetListFromUser()
    {
        Console.Write("> ");
        string item = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(item))
        {
            _count++;  
        }
        
    }
}
