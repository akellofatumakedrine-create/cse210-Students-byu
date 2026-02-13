using System;

class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string title, string description, int points) : base(title, description, points)
    {
        _completed = false;
    }

    public override int RecordEvent()
    {
        if (_completed) return -1;
        _completed = true;
        return _points;
    }

    public override bool IsComplete => _completed;

    public override string Serialize()
    {
        return $"SimpleGoal|{Title}|{Description}|{_points}|{_completed}";
    }

    public override string StatusString()
    {
        return _completed ? "[X]" : "[ ]";
    }
}
