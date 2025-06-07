namespace Mindfulness;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you feel when it was complete?",
        "How did you get started?",
        "What could you learn from this experience that applies to other situations?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
            "This activity will help you reflect on times you’ve shown strength and resilience.") { }

    private Queue<string> _availablePrompts = new Queue<string>();
    private Queue<string> _availableQuestions = new Queue<string>();
    private void ResetPrompts()
    {
        var shuffled = _prompts.OrderBy(x => Guid.NewGuid()).ToList();
        foreach (var p in shuffled)
            _availablePrompts.Enqueue(p);
    }

    private void ResetQuestions()
    {
        var shuffled = _questions.OrderBy(x => Guid.NewGuid()).ToList();
        foreach (var q in shuffled)
            _availableQuestions.Enqueue(q);
    }
    
    protected override void Run()
    {
        if (_availablePrompts.Count == 0) ResetPrompts();
        Console.WriteLine("\n" + _availablePrompts.Dequeue());
        if (_availableQuestions.Count == 0) ResetQuestions();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            if (_availableQuestions.Count == 0) ResetQuestions();
            Console.Write("\n> " + _availableQuestions.Dequeue() + " ");
            ShowSpinner(5);
        }
    }
    
}