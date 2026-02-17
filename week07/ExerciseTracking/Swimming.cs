using System;

public class Swimming : Activity
{
    private int _laps;
    private const double MetersPerLap = 50.0;

    public Swimming(string date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double km = _laps * MetersPerLap / 1000.0;
        double miles = km * 0.62;
        return miles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Length) * 60.0;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }
}
