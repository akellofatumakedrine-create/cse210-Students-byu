using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>();

        // Running: date, length (min), distance (miles)
        activities.Add(new Running("03 Nov 2022", 30, 3.0));

        // Cycling: date, length (min), speed (mph)
        activities.Add(new Cycling("04 Nov 2022", 45, 12.0));

        // Swimming: date, length (min), laps (50m per lap)
        activities.Add(new Swimming("05 Nov 2022", 60, 40));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}