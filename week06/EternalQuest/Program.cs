using System;
using System.Collections.Generic;
using System.IO;

// Creativity: Added a simple leveling system where every 1000 points increases level.
// See Level calculation in `GoalsManager`.

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalsManager();
        manager.LoadIfExists("goals.txt");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest - Main Menu");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event (complete a goal)");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Display score/level");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            if (input == "1") CreateGoal(manager);
            else if (input == "2") manager.ListGoals();
            else if (input == "3") RecordEvent(manager);
            else if (input == "4") manager.Save("goals.txt");
            else if (input == "5") manager.Load("goals.txt");
            else if (input == "6") manager.DisplayScore();
            else if (input == "7") { manager.Save("goals.txt"); break; }
            else Console.WriteLine("Invalid option");
        }
    }

    static void CreateGoal(GoalsManager manager)
    {
        Console.WriteLine("Choose goal type: 1=Simple, 2=Eternal, 3=Checklist");
        var t = Console.ReadLine();
        Console.Write("Title: ");
        var title = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        var desc = Console.ReadLine() ?? "";

        if (t == "1")
        {
            Console.Write("Points for completion: ");
            if (int.TryParse(Console.ReadLine(), out int pts))
            {
                manager.AddGoal(new SimpleGoal(title, desc, pts));
                Console.WriteLine("Simple goal created.");
            }
        }
        else if (t == "2")
        {
            Console.Write("Points per occurrence: ");
            if (int.TryParse(Console.ReadLine(), out int pts))
            {
                manager.AddGoal(new EternalGoal(title, desc, pts));
                Console.WriteLine("Eternal goal created.");
            }
        }
        else if (t == "3")
        {
            Console.Write("Points per item: ");
            if (!int.TryParse(Console.ReadLine(), out int pts)) return;
            Console.Write("Target count: ");
            if (!int.TryParse(Console.ReadLine(), out int target)) return;
            Console.Write("Bonus on completion: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus)) return;

            manager.AddGoal(new ChecklistGoal(title, desc, pts, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
        else Console.WriteLine("Unknown type");
    }

    static void RecordEvent(GoalsManager manager)
    {
        manager.ListGoals();
        Console.Write("Enter goal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int idx))
        {
            var points = manager.RecordEvent(idx - 1);
            if (points >= 0) Console.WriteLine($"You earned {points} points!");
            else Console.WriteLine("Invalid goal selection or already completed.");
        }
    }
}