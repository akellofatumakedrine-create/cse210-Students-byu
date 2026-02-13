using System;

class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points) : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete => false;

    public override string Serialize()
    {
        return $"EternalGoal|{Title}|{Description}|{_points}";
    }

    public override string StatusString()
    {
        return "[∞]"; // never complete
    }
}
