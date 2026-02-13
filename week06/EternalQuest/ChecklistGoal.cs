using System;

class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _target;
    private int _bonus;
    private bool _completed;

    public ChecklistGoal(string title, string description, int pointsPer, int target, int bonus) : base(title, description, pointsPer)
    {
        _currentCount = 0;
        _target = target;
        _bonus = bonus;
        _completed = false;
    }

    public override int RecordEvent()
    {
        if (_completed) return -1;
        _currentCount++;
        int earned = _points;
        if (_currentCount >= _target)
        {
            _completed = true;
            earned += _bonus;
        }
        return earned;
    }

    public override bool IsComplete => _completed;

    public override string Serialize()
    {
        return $"ChecklistGoal|{Title}|{Description}|{_points}|{_currentCount}|{_target}|{_bonus}|{_completed}";
    }

    public override string StatusString()
    {
        return _completed ? $"[X] Completed {_currentCount}/{_target}" : $"[ ] Completed {_currentCount}/{_target}";
    }
}
