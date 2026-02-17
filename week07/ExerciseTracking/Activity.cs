using System;

public class Activity
{
    private string _date;
    private int _length; // minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    protected string Date => _date;
    protected int Length => _length;

    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        return 0.0;
    }

    public virtual double GetPace()
    {
        return 0.0;
    }

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_length} min) - Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}
