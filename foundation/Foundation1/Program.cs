using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");
        // Create a list to store videos
        List<Video> videos = new List<Video>();

       

        // Create and populate the videos
        Video video1 = new Video("Introduction to C#", "Elie Mambou", 600);
        video1.AddComment(new Comment("Daniel", "Great introduction!"));
        video1.AddComment(new Comment("Leah", "Very helpful, thanks."));
        video1.AddComment(new Comment("Kolob", "Could you explain enums?"));

        Video video2 = new Video("Advanced C# Techniques", "Matsiu Alice", 1200);
        video2.AddComment(new Comment("Brian", "Loved the deep dive into LINQ."));
        video2.AddComment(new Comment("Evelyne", "Really well explained!"));
        video2.AddComment(new Comment("Francesca", "Helped me with my project."));

        Video video3 = new Video("C# Design Patterns", "Sylvere Mambou", 900);
        video3.AddComment(new Comment("Gracelia", "Singleton pattern was confusing."));
        video3.AddComment(new Comment("Divine", "Loved the Factory pattern example."));
        video3.AddComment(new Comment("Leslie", "This is gold! Thanks."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}