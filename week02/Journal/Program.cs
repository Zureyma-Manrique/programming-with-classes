using Journal.dto;

// - Asks user for file name and uses a default path
// - Supports both CSV and JSON formats
// - Uses input validation and file existence checks
class Program
{
    static void Main(string[] args)
    {
        JournalEntry journal = new JournalEntry();
        PromptGenerator promptGenerator = new PromptGenerator();

        // Define your default directory (change this as needed)
        string defaultDirectory = "C:\\Users\\Admin\\OneDrive\\Documents\\BYU\\Term3\\programming-with-classes\\week02\\Journal\\sources";
        Directory.CreateDirectory(defaultDirectory); // Ensure it exists

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save to CSV");
            Console.WriteLine("4. Load from CSV");
            Console.WriteLine("5. Save to JSON");
            Console.WriteLine("6. Load from JSON");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    string quote = promptGeneratorGetRandomQuote();
                    
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("Your mood: ");
                    string mood = Console.ReadLine();

                    Console.Write("Your location: ");
                    string location = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                        Prompt = prompt,
                        UserEntry = response,
                        Mood = mood,
                        Location = location
                    };
                    
                    journal.AddEntry(newEntry);
                    
                    Console.WriteLine($"{quote}");
                    
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter file name (without extension): ");
                    string csvName = Console.ReadLine();
                    string csvPath = Path.Combine(defaultDirectory, csvName + ".csv");
                    journal.SaveToCSV(csvPath);
                    break;

                case "4":
                    Console.Write("Enter CSV file name to load (without extension): ");
                    string csvLoadName = Console.ReadLine();
                    string csvLoadPath = Path.Combine(defaultDirectory, csvLoadName + ".csv");
                    if (File.Exists(csvLoadPath))
                        journal.LoadFromCSV(csvLoadPath);
                    else
                        Console.WriteLine("File does not exist.");
                    break;

                case "5":
                    Console.Write("Enter file name (without extension): ");
                    string jsonName = Console.ReadLine();
                    string jsonPath = Path.Combine(defaultDirectory, jsonName + ".json");
                    journal.SaveToJSON(jsonPath);
                    break;

                case "6":
                    Console.Write("Enter JSON file name to load (without extension): ");
                    string jsonLoadName = Console.ReadLine();
                    string jsonLoadPath = Path.Combine(defaultDirectory, jsonLoadName + ".json");
                    if (File.Exists(jsonLoadPath))
                        journal.LoadFromJSON(jsonLoadPath);
                    else
                        Console.WriteLine("File does not exist.");
                    break;

                case "7":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
