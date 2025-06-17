namespace ExerciseTracking;

public static class UnitHelper
{
    public static double SwimmingDistanceInMiles(int laps)
    {
        return laps * 50 / 1000.0 * 0.62;
    }

    public static double Speed(double distance, int minutes)
    {
        return (distance / minutes) * 60;
    }

    public static double Pace(double distance, int minutes)
    {
        return minutes / distance;
    }
    
}