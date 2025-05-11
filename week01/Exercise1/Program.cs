class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        var name = Console.ReadLine();
        Console.WriteLine("What is your last name? ");
        var lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {name} {lastName}.");
    }
}