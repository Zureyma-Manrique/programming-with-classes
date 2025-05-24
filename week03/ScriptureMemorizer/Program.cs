using ScriptureMemorizer;

class Program {
    static void Main(string[] args) {
        string baseDirectory = AppContext.BaseDirectory;
        string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\.."));
        string filePath = Path.Combine(projectRoot, "sources", "scriptures.txt");

        List<Scripture> scriptures = LoadScripturesFromFile(filePath);

        // Default scripture
        if (scriptures.Count == 0) {
            var fallbackReference = new Reference("Philippians", 4, 13);
            string fallbackText = "I can do all things through Christ who strengthens me.";
            scriptures.Add(new Scripture(fallbackReference, fallbackText));
        }

        bool keepGoing = true;
        Random rand = new Random();

        while (keepGoing) {
            Scripture scripture = scriptures[rand.Next(scriptures.Count)];

            while (true) {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input != null && input.ToLower().Equals("quit")) {
                    keepGoing = false;
                    break;
                }

                scripture.HideRandomWords();

                if (!scripture.IsCompletelyHidden()) continue;
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden.");
                break;
            }

            if (!keepGoing) continue;
            {
                Console.WriteLine("\nType 'another' to try a new scripture, or 'quit' to exit:");
                string input = Console.ReadLine().ToLower();

                if (input != "another") {
                    keepGoing = false;
                }
            }
        }

        Console.WriteLine("Goodbye!");
    }
    
    static List<Scripture> LoadScripturesFromFile(string filePath) {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filePath)) {
            Console.WriteLine($"[Warning] Scriptures file not found: {filePath}");
            return scriptures;
        }

        var lines = File.ReadAllLines(filePath);
        if (lines.Length == 0) {
            Console.WriteLine($"[Warning] Scriptures file is empty.");
            return scriptures;
        }

        foreach (var line in lines) {
            var parts = line.Split('|');
            if (parts.Length < 4) continue;

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            string[] verses = parts[2].Split('-');
            int verseStart = int.Parse(verses[0]);
            int verseEnd = verses.Length > 1 ? int.Parse(verses[1]) : verseStart;

            string text = parts[3];
            var reference = new Reference(book, chapter, verseStart, verseEnd);
            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}