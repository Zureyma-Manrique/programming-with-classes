namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _badges = new List<string>();

    public void Start()
    {
        int choice = -1;
        while (choice != 6)
        {
            Console.WriteLine($"\nYour score: {_score} | Level: {_level} | Badges: {string.Join(", ", _badges)}");
            Console.WriteLine("1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type: 1. Simple 2. Eternal 3. Checklist");
        int type = int.Parse(Console.ReadLine());
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

        if (type == 1) _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == 2) _goals.Add(new EternalGoal(name, desc, points));
        else if (type == 3)
        {
            Console.Write("Target count: "); int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: "); int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;
        CheckLevelUp();
        AssignBadges();
        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(_score);
            sw.WriteLine(_level);
            sw.WriteLine(string.Join(";", _badges));
            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _badges = new List<string>(lines[2].Split(';'));
        for (int i = 3; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])));
            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3])));
        }
        Console.WriteLine("Goals loaded.");
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You leveled up to Level {_level}!");
        }
    }

    private void AssignBadges()
    {
        if (_score >= 500 && !_badges.Contains("Bronze Achiever"))
        {
            _badges.Add("Bronze Achiever");
            Console.WriteLine("You earned the 'Bronze Achiever' badge!");
        }
        if (_score >= 1000 && !_badges.Contains("Silver Star"))
        {
            _badges.Add("Silver Star");
            Console.WriteLine("You earned the 'Silver Star' badge!");
        }
        if (_score >= 2000 && !_badges.Contains("Golden Hero"))
        {
            _badges.Add("Golden Hero");
            Console.WriteLine("You earned the 'Golden Hero' badge!");
        }
    }
    
}