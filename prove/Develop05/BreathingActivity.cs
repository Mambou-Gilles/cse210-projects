class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will guide you through breathing in and out slowly to help you relax.")
    {
    }

    // Run method for the breathing activity
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);  // Show a spinner for 3 seconds

        int breathInTime = 2;  // Start the breath-in countdown from 2
        int breathOutTime = 3; // Start the breath-out countdown from 3
        bool incremented = false;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)

        {
            Console.WriteLine(" ");
            // Breathing in message with countdown
            Console.Write("Breathe in... ");
            ShowCountDown(breathInTime); // Use ShowCountDown from Activity class'

            Console.WriteLine();

            // Breathing out message with countdown
            Console.Write("Breathe out... ");
            ShowCountDown(breathOutTime);

            

            // Increment only once, after the first loop
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
