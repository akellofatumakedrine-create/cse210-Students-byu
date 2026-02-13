using System;

abstract class Goal
{
    private string _title;
    private string _description;

    protected int _points;

    public string Title => _title;
    public string Description => _description;

    protected Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    // Record an occurrence of this goal. Returns points awarded (or -1 if nothing happened).
    public abstract int RecordEvent();

    // Whether the goal is finished (for eternal goals this will always be false)
    public abstract bool IsComplete { get; }

    // A string representation suitable for saving to a text file
    public abstract string Serialize();

    // Human readable status string
    public abstract string StatusString();
}
