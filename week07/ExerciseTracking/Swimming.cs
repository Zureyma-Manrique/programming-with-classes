namespace ExerciseTracking;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return UnitHelper.SwimmingDistanceInMiles(_laps);
    }

    public override double GetSpeed()
    {
        return UnitHelper.Speed(GetDistance(), GetMinutes());
    }

    public override double GetPace()
    {
        return UnitHelper.Pace(GetDistance(), GetMinutes());
    }
    
    public override string GetDescription()
    {
        return "Swimming is a full-body workout that increases endurance, builds muscle, and improves flexibility.";
    }

    
}