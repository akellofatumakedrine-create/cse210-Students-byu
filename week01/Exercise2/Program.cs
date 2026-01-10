using System;

class Program
{
    static void Main()
    {
        // Core Requirement 1: Get grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());
        string letter;

        // Core Requirement 2: Determine letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Determine sign
        string sign = "";
        if (letter != "F") // No signs for F grades
        {
            int lastDigit = gradePercentage % 10;
            if (lastDigit >= 7 && letter != "A") // No A+
            {
                sign = "+";
            }
            else if (lastDigit < 3 && gradePercentage != 100) // Handle 100% edge case
            {
                sign = "-";
            }
        }

        // Print grade with sign (Core Requirement 3: Single output)
        Console.WriteLine($"Your letter grade: {letter}{sign}");

        // Pass/Fail check
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed.");
        }
        else
        {
            Console.WriteLine("Keep working hard for next time!");
        }
    }
}