using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        base.DisplayStartingMessage();
        base.PromptForDuration();
        base.PrepareToBegin();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();

            if (DateTime.Now >= endTime) break;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            Console.WriteLine();
        }

        base.DisplayEndingMessage();
    }
}
