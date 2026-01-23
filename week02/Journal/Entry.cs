using System;
using System.Linq;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public string ToCsvString()
    {
        return $"\"{Date.Replace("\"", "\"\"")}\",\"{Prompt.Replace("\"", "\"\"")}\",\"{Response.Replace("\"", "\"\"")}\"";
    }

    public static Entry FromCsvString(string csvString)
    {
        // Simple CSV parser, assuming no escaped quotes inside fields
        string[] parts = csvString.Split(',');
        if (parts.Length >= 3)
        {
            string date = parts[0].Trim('"').Replace("\"\"", "\"");
            string prompt = parts[1].Trim('"').Replace("\"\"", "\"");
            string response = string.Join(",", parts.Skip(2)).Trim('"').Replace("\"\"", "\"");
            return new Entry(date, prompt, response);
        }
        return null;
    }

    public static Entry FromFileString(string fileString)
    {
        string[] parts = fileString.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}