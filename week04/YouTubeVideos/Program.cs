using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Jollof Rice", "Chef Ama", 600);
        video1.AddComment(new Comment("Kwame", "This was very helpful!"));
        video1.AddComment(new Comment("Akosua", "I love this recipe!"));
        video1.AddComment(new Comment("John", "Great explanation."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("C# Basics for Beginners", "CodeMaster", 1200);
        video2.AddComment(new Comment("Sarah", "Very clear tutorial."));
        video2.AddComment(new Comment("Michael", "Helped me understand OOP."));
        video2.AddComment(new Comment("Linda", "Nice pacing!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Football Goals", "SportsHub", 900);
        video3.AddComment(new Comment("David", "Amazing goals!"));
        video3.AddComment(new Comment("Emma", "Goal #3 was insane."));
        video3.AddComment(new Comment("Chris", "Loved this video."));
        videos.Add(video3);

        // Display all videos
        foreach (Video v in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Title: {v.GetTitle()}");
            Console.WriteLine($"Author: {v.GetAuthor()}");
            Console.WriteLine($"Length: {v.GetLength()} seconds");
            Console.WriteLine($"Comments Count: {v.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"- {c.GetCommentInfo()}");
            }
        }
    }
}