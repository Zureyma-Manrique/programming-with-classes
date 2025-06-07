using Mindfulness;

class Program
{
    
    // ===== Creativity Report =====
    // This program exceeds the core requirements by:
    // 1. Adding a new "Gratitude Activity" where users write a thank-you message.
    // 2. Logging each activity with name and duration into a session log file.
    // 3. Ensuring prompts are not repeated until all have been used.
    // =============================

    static void Main(string[] args)
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    Thread.Sleep(1000);
                    continue;
            }

            activity.Start();
            
            string baseDirectory = AppContext.BaseDirectory; // bin/Debug/net6.0/
            string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..")); // go up to project root
            string logDirectory = Path.Combine(projectRoot, "sources");

            Directory.CreateDirectory(logDirectory);
            
            string logPath = Path.Combine(logDirectory, "ActivityLog.txt");

            using (StreamWriter writer = new StreamWriter(logPath, append: true))
            {
                writer.WriteLine($"{DateTime.Now}: Completed {activity.GetType().Name} for {activity.Duration} seconds.");
            }


        }
    }
}