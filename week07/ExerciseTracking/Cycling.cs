namespace ExerciseTracking;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * GetMinutes()) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
    
    public override string GetDescription()
    {
        return "Cycling strengthens leg muscles and improves cardiovascular fitness with low joint impact.";
    }

    
}