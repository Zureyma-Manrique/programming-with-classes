class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                if (number == 0)
                    break;

                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }
        
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        
        var positiveNumbers = numbers.Where(n => n > 0);
        if (positiveNumbers.Any())
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }
        
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}