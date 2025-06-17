namespace ExerciseTracking;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public int GetMinutes() => _lengthInMinutes;
    public DateTime GetDate() => _date;

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();     

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_lengthInMinutes} min): " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
    
    public virtual string GetDescription()
    {
        return "This is a generic activity.";
    }
    
}