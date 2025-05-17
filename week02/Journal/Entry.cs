using System.Text.RegularExpressions;

namespace Journal.dto;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string UserEntry { get; set; }
    public string Mood { get; set; }
    public string Location { get; set; }
    
    public Entry() { }
    
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Entry: {UserEntry}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine("---------------------------");
    }
    
    public string ToCsv()
    {
        return $"{EscapeCsv(Date)},{EscapeCsv(Prompt)},{EscapeCsv(UserEntry)},{EscapeCsv(Mood)},{EscapeCsv(Location)}";
    }

    private string EscapeCsv(string s)
    {
        if (s.Contains("\"") || s.Contains(",") || s.Contains("\n"))
        {
            s = s.Replace("\"", "\"\"");
            s = $"\"{s}\"";
        }
        return s;
    }

    public static Entry FromCsv(string csvLine)
    {
        var fields = Regex.Matches(csvLine, @"(?:^|,)(?:(?:""(?<val>(?:[^""]|"""")*)"")|(?<val>[^"",]*))");

        var values = new List<string>();
        foreach (Match m in fields)
        {
            values.Add(m.Groups["val"].Value.Replace("\"\"", "\""));
        }

        if (values.Count < 5) return null;

        return new Entry
        {
            Date = values[0],
            Prompt = values[1],
            UserEntry = values[2],
            Mood = values[3],
            Location = values[4]
        };
    }
    
}