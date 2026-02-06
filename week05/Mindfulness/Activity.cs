using System;

class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine();
    }

    public void PromptForDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void PrepareToBegin()
    {
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} second {_name} Activity.");
        ShowCountdown(3);
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        string[] spinnerFrames = { "|", "/", "-", "\\" };
        int frameIndex = 0;

        while (DateTime.Now < futureTime)
        {
            Console.Write(spinnerFrames[frameIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % spinnerFrames.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < futureTime)
        {
            int remainingSeconds = (int)(futureTime - DateTime.Now).TotalSeconds + 1;
            Console.Write(remainingSeconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run()
    {
        DisplayStartingMessage();
        PromptForDuration();
        PrepareToBegin();
        DisplayEndingMessage();
    }

    protected int GetDuration()
    {
        return _duration;
    }
}
