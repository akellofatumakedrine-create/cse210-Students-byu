using System;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        base.DisplayStartingMessage();
        base.PromptForDuration();
        base.PrepareToBegin();

        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine();

        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        Console.WriteLine("Start listing items (press Enter after each item):");

        int itemCount = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.GetDuration());

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    itemCount++;
                }
            }
            Thread.Sleep(100);
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items!");
        base.DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}
