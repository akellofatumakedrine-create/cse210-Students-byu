using System;
using System.Collections.Generic;
using System.IO;

class GoalsManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal g) => _goals.Add(g);

    public void ListGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            Console.WriteLine($"{i + 1}. {g.StatusString()} {g.Title} - {g.Description}");
        }
        Console.WriteLine();
        DisplayScore();
    }

    // record event against goal index
    public int RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count) return -1;
        var g = _goals[index];
        int points = g.RecordEvent();
        if (points > 0)
        {
            _score += points;
            return points;
        }
        return -1;
    }

    public void Save(string filename)
    {
        using (var sw = new StreamWriter(filename))
        {
            sw.WriteLine($"Score:{_score}");
            foreach (var g in _goals)
            {
                sw.WriteLine(g.Serialize());
            }
        }
        Console.WriteLine($"Saved to {filename}");
    }

    public void LoadIfExists(string filename)
    {
        if (File.Exists(filename)) Load(filename);
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        var lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = 0;
        foreach (var line in lines)
        {
            if (line.StartsWith("Score:"))
            {
                var parts = line.Split(':');
                if (parts.Length > 1 && int.TryParse(parts[1], out int s)) _score = s;
                continue;
            }

            var pieces = line.Split('|');
            if (pieces.Length == 0) continue;
            var type = pieces[0];
            try
            {
                if (type == "SimpleGoal")
                {
                    // SimpleGoal|Title|Description|points|completed
                    var title = pieces[1];
                    var desc = pieces[2];
                    var pts = int.Parse(pieces[3]);
                    var completed = bool.Parse(pieces[4]);
                    var g = new SimpleGoal(title, desc, pts);
                    if (completed) g.RecordEvent();
                    _goals.Add(g);
                }
                else if (type == "EternalGoal")
                {
                    // EternalGoal|Title|Description|points
                    var title = pieces[1];
                    var desc = pieces[2];
                    var pts = int.Parse(pieces[3]);
                    _goals.Add(new EternalGoal(title, desc, pts));
                }
                else if (type == "ChecklistGoal")
                {
                    // ChecklistGoal|Title|Description|points|current|target|bonus|completed
                    var title = pieces[1];
                    var desc = pieces[2];
                    var pts = int.Parse(pieces[3]);
                    var current = int.Parse(pieces[4]);
                    var target = int.Parse(pieces[5]);
                    var bonus = int.Parse(pieces[6]);
                    var completed = bool.Parse(pieces[7]);
                    var g = new ChecklistGoal(title, desc, pts, target, bonus);
                    for (int i = 0; i < current; i++) g.RecordEvent();
                    _goals.Add(g);
                }
            }
            catch
            {
                // ignore malformed line
            }
        }

        Console.WriteLine($"Loaded {filename}");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {Level}");
    }

    public int Level => (_score / 1000) + 1;
}
