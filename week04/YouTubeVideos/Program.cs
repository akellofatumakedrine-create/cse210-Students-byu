using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var v1 = new Video("C# Basics", "Alice", 320);
        v1.AddComment(new Comment("Bob", "Great intro!"));
        v1.AddComment(new Comment("Carol", "Very helpful, thanks."));
        v1.AddComment(new Comment("Dave", "Could use more examples."));
        videos.Add(v1);

        var v2 = new Video("Advanced LINQ", "Eve", 540);
        v2.AddComment(new Comment("Frank", "Mind blown."));
        v2.AddComment(new Comment("Grace", "Awesome explanations."));
        v2.AddComment(new Comment("Heidi", "Saved me a lot of time."));
        videos.Add(v2);

        var v3 = new Video("Async Programming", "Ivan", 780);
        v3.AddComment(new Comment("Judy", "Clear and concise."));
        v3.AddComment(new Comment("Mallory", "Waiting for part 2."));
        v3.AddComment(new Comment("Oscar", "Nice examples."));
        v3.AddComment(new Comment("Peggy", "Excellent pacing."));
        videos.Add(v3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}