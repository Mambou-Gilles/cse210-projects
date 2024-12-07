class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will guide you through breathing in and out slowly to help you relax.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);  

        int breathInTime = 2; 
        int breathOutTime = 3; 
        bool incremented = false;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)

        {
            Console.WriteLine(" ");
            
            Console.Write("Breathe in... ");
            ShowCountDown(breathInTime); 

            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountDown(breathOutTime);

            

            if (!incremented)
            {
                breathInTime += 2;
                breathOutTime += 3;
                incremented = true;
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}
