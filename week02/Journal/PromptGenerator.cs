namespace Journal.dto;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What is something you are grateful for?",
        "Describe a moment when you felt peace today.",
        "What made you smile today?",
        "What would you like to improve tomorrow?",
        "Write about a goal you want to achieve.",
        "What is your favorite memory from this week?"
    };

    private List<string> _quotes = new List<string>()
    {
        "Keep going, you're doing great!",
        "Every day is a new beginning.",
        "Writing helps us understand ourselves better.",
        "Your story matters.",
        "One step at a time."
    };

    private Random _rand = new Random();

    public string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuote()
    {
        int index = _rand.Next(_quotes.Count);
        return _quotes[index];
    }
    
}