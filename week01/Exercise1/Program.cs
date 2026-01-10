using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name");
        string firstName = Console.ReadLine();

        //prompt for last name
        Console.WriteLine("What is your last name");
        string lastName = Console.ReadLine();

        //print full name
        Console.WriteLine("Your full name is " + firstName + " " + lastName
        );
    }
}