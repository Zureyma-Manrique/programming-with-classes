namespace Mindfulness;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
            "This activity will help you relax by guiding you through deep breathing.") { }

    protected override void Run()
    {
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);
        }
    }
    
}