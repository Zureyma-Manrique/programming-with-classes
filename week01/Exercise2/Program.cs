class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        var input = Console.ReadLine();
        var grade = int.Parse(input);

        var letter = "";
        var sign = "";

        letter = grade switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };

        // Determine the sign, if applicable
        var lastDigit = grade % 10;

        if (letter != "F")
        {
            sign = lastDigit switch
            {
                // No A+
                >= 7 when grade < 90 => "+",
                // Allow A- but no A+
                < 3 when !(letter == "A" && grade >= 93) => "-",
                _ => sign
            };
        }
        
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine pass/fail
        Console.WriteLine(grade >= 70
            ? "Congratulations! You passed the course."
            : "Don't give up! Keep working and you'll do better next time.");
    }
}