using System.Text.Json;

namespace Journal.dto;

public class JournalEntry
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    
    public void SaveToCSV(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Date,Prompt,Entry,Mood,Location");
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToCsv());
                }
            }
            Console.WriteLine($"Journal saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to CSV: {ex.Message}");
        }
    }

    public void LoadFromCSV(string filePath)
    {
        try
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++) // Skip header
            {
                var entry = Entry.FromCsv(lines[i]);
                if (entry != null)
                    _entries.Add(entry);
            }
            Console.WriteLine($"Loaded {_entries.Count} entries from: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from CSV: {ex.Message}");
        }
    }

    public void SaveToJSON(string filePath)
    {
        try
        {
            string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Journal saved to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to JSON: {ex.Message}");
        }
    }

    public void LoadFromJSON(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
            Console.WriteLine($"Loaded {_entries.Count} entries from: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from JSON: {ex.Message}");
        }
    }
    
}