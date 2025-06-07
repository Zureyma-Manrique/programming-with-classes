namespace Mindfulness;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() 
        : base("Gratitude Activity", 
            "This activity helps you practice gratitude by writing thank-you notes.") { }

    protected override void Run()
    {
        Console.WriteLine("\nThink of someone or something you're grateful for.");
        Console.Write("Write your thank-you message below:\n\n> ");

        string message = Console.ReadLine();
        Console.WriteLine("\nThank you for taking the time to show gratitude.");
        
        string baseDirectory = AppContext.BaseDirectory; // bin/Debug/net6.0/
        string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..")); // go up to project root
        string logDirectory = Path.Combine(projectRoot, "sources");

        Directory.CreateDirectory(logDirectory);
            
        string logPath = Path.Combine(logDirectory, "GratitudeMessages.txt");

        using (StreamWriter writer = new StreamWriter(logPath, append: true))
        {
            writer.WriteLine($"[{DateTime.Now}] {message}");
            writer.WriteLine();
        }
    }
}