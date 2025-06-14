namespace EternalQuest;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetName() => _shortName;

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return ($"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})");
    }
    public abstract string GetStringRepresentation();
    
}