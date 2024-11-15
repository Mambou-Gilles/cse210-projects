using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Sandbox World!");
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running){
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Delete a specific entry");
            Console.WriteLine("6. Clear all journal entries");
            Console.WriteLine("7. Exit");
            Console.Write("What would you like to do?: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice){
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    journal.AddEntry(new Entry(prompt, response));
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename?: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "4":
                    Console.Write("What is the filename?: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "5":
                    journal.DisplayAll();
                    Console.Write("Enter the entry number to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int entryIndex))
                    {
                        journal.DeleteEntry(entryIndex - 1); 
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter a valid number.");
                    }
                    break;
                
                case "6":
                    Console.Write("Are you sure you want to delete all entries? (yes/no): ");
                    string confirm = Console.ReadLine().ToLower();
                    if (confirm == "yes")
                    {
                        journal.ClearJournal();
                    }
                    else
                    {
                        Console.WriteLine("\nOperation canceled.");
                    }
                    break;
                
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}