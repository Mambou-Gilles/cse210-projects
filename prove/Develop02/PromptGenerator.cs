public class PromptGenerator {
    public List<string> _prompts = new List<string>
    {
        "If I had one thing I could do over today, what would it be?",
        "What was the best part of my day?",
        "What am I most grateful for right now?",
        "What did I learn today?",
        "How did I help someone today?",
        "What challenge did I face today and how did I overcome it?",
        "What made me smile today?",
        "What was something new I tried today?",
        "How did I take care of myself today?",
        "Who inspired me today and why?",
        "What is one thing I can do tomorrow to make it a great day?",
        "What was the most interesting conversation I had today?",
        "What is one thing I accomplished today that I'm proud of?",
        "How did I step out of my comfort zone today?",
        "What do I want to remember about today?",
        "What positive impact did I make on someone else's day?"
    };

    public Random _random = new Random();

    public string GetRandomPrompt(){
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}