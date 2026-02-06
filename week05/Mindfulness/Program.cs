using System;

class Program
{
    // Exceeds Requirements: 
    // - Implemented activity count tracking to display statistics at program exit
    // - Added meaningful spinner animations for better user experience
    // - Prompt selection ensures no repeats within a session by removing used prompts

    private static int _breathingCount = 0;
    private static int _reflectionCount = 0;
    private static int _listingCount = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    _breathingCount++;
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    _reflectionCount++;
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    _listingCount++;
                    break;
                case "4":
                    running = false;
                    DisplayStatistics();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    static void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine("Session Statistics:");
        Console.WriteLine($"Breathing Activities: {_breathingCount}");
        Console.WriteLine($"Reflection Activities: {_reflectionCount}");
        Console.WriteLine($"Listing Activities: {_listingCount}");
        Console.WriteLine($"Total Activities: {_breathingCount + _reflectionCount + _listingCount}");
        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}