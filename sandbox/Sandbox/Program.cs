using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        // Create instances of each activity
            var running = new Running("03 Nov 2022", 30, 3.0); 
            var cycling = new Cycling("04 Nov 2022", 40, 15.0); 
            var swimming = new Swimming("05 Nov 2022", 25, 20); 

            // Add activities to a list
            var activities = new List<Activity> { running, cycling, swimming };

            // Display summaries for each activity
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        
    }
}