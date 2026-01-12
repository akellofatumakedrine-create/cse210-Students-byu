using System.Collections.Generic;

public class Resume
{
    // Member variable for the person's name
    public string _name;

    // Member variable for the list of jobs, initialized to a new list
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Iterate through the list of jobs and call the Display method for each one
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}