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
        "What is your favorite memory from this week?",
        "What is something you learned today?",
        "What challenge did you face today, and how did you overcome it?",
        "How did you practice self-care today?",
        "What are you looking forward to in the coming week?",
        "Write about a recent accomplishment you're proud of.",
        "What is a quality you admire in others?",
        "What is something you’ve been putting off that you want to start?",
        "What is one thing you can do tomorrow to make it better than today?",
        "Reflect on a difficult situation and how it helped you grow.",
        "What is something you're excited about right now?",
        "How did you show kindness to someone today?",
        "What would your ideal day look like?",
        "What are three things you can do to make tomorrow less stressful?",
        "How do you define success, and what steps can you take toward it?",
        "What are you most proud of this week?",
        "What has inspired you lately?",
        "What makes you feel at home and why?",
        "What is a habit you’d like to start or break?",
        "What are you grateful for about your health?",
        "What is something that challenged you today and how did you feel about it?",
        "What is a dream or wish that you’re ready to work toward?"
    };

    private List<string> _quotes = new List<string>()
    {
        "Keep going, you're doing great!",
        "Every day is a new beginning.",
        "Writing helps us understand ourselves better.",
        "Your story matters.",
        "One step at a time.",
        "You are stronger than you think.",
        "Progress is progress, no matter how small.",
        "Believe in yourself and all that you are.",
        "It's okay to rest; you're still moving forward.",
        "Your potential is endless.",
        "The only way out is through.",
        "Take a deep breath and trust the process.",
        "Embrace the challenges—they're the stepping stones to success.",
        "You're exactly where you need to be."
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