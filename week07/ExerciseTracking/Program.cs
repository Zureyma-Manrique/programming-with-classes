using ExerciseTracking;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2024, 11, 3), 45, 15.0),
            new Swimming(new DateTime(2024, 11, 3), 40, 20),
            new Swimming(new DateTime(2024, 12, 1), 45, 30),
            new Cycling(new DateTime(2024, 12, 1), 50, 20.0),
            new Running(new DateTime(2024, 12, 1), 35, 5.0),
        };

        foreach (Activity activity in activities)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(activity.GetDescription());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(activity.GetSummary());
        }
        Console.ResetColor();
    }
}