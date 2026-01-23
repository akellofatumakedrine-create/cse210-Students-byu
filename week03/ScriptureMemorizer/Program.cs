using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements: Added ability to load scriptures from a file and select randomly.
        // Also, improved word hiding to only hide visible words.

        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures loaded.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords(3); // Hide 3 words at a time
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string refText = parts[0];
                    string text = parts[1];
                    Reference reference = ParseReference(refText);
                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }
        return scriptures;
    }

    static Reference ParseReference(string refText)
    {
        // Simple parser for "Book Chapter:Verse" or "Book Chapter:Start-End"
        string[] parts = refText.Split(' ');
        string book = parts[0];
        string[] chapVerse = parts[1].Split(':');
        int chapter = int.Parse(chapVerse[0]);
        string[] verses = chapVerse[1].Split('-');
        int verse = int.Parse(verses[0]);
        if (verses.Length > 1)
        {
            int endVerse = int.Parse(verses[1]);
            return new Reference(book, chapter, verse, endVerse);
        }
        else
        {
            return new Reference(book, chapter, verse);
        }
    }
}