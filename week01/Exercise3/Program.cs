class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        
        string playAgain;

        do
        {
            var magicNumber = randomGenerator.Next(1, 101); // 1 to 100 inclusive
            var guess = -1;
            var guessCount = 0;

            Console.WriteLine("I have selected a magic number between 1 and 100.");

            // Asking until the guess is correct
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out guess))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }
            
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}