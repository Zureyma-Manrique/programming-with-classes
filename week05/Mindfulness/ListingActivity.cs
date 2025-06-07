namespace Mindfulness;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "What are you grateful for today?",
        "Who have you helped recently?"
    };

    public ListingActivity()
        : base("Listing Activity",
            "This activity will help you reflect on the good things by listing as many items as you can.")
    {
    }
    
    private Queue<string> _availablePrompts = new Queue<string>();
    
    private void ResetPrompts()
    {
        var shuffled = _prompts.OrderBy(x => Guid.NewGuid()).ToList();
        foreach (var p in shuffled)
            _availablePrompts.Enqueue(p);
    }

    protected override void Run()
    {
        if (_availablePrompts.Count == 0)
            ResetPrompts();

        Console.WriteLine("\n" + _availablePrompts.Dequeue());
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine("\nStart listing items (press Enter after each one):");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = ReadLineWithTimeout(endTime);
            if (input != null)
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
    }

    private string ReadLineWithTimeout(DateTime endTime)
    {
        string input = "";

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }

            Thread.Sleep(50); 
        }

        Console.WriteLine(); 
        return null;
    }
    
}
