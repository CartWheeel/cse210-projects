using System;
using System.Collections.Generic;

// Abstract class representing a media item
abstract class MediaItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
}

// Class representing a comment on a video
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
}

// Class representing a video
class Video : MediaItem
{
    public List<Comment> Comments { get; set; }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video
        {
            Title = "Cat video",
            Author = "Carter Williams",
            LengthInSeconds = 120,
            Comments = new List<Comment>
            {
                new Comment { CommenterName = "Bill", Text = "I love cats!" },
                new Comment { CommenterName = "Bob", Text = "Hilarious LOL!" },
                new Comment { CommenterName = "Bary", Text = "cute boi :3" }
            }
        };
        videos.Add(video1);

        Video video2 = new Video
        {
            Title = "Serious Video",
            Author = "Sam Williams",
            LengthInSeconds = 180,
            Comments = new List<Comment>
            {
                new Comment { CommenterName = "Joe", Text = "Very serious." },
                new Comment { CommenterName = "John", Text = "I completely agree @Joe." }
            }
        };
        videos.Add(video2);

        // Displaying video information
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.LengthInSeconds);
            Console.WriteLine("Number of Comments: " + video.GetNumberOfComments());

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine("Commenter: " + comment.CommenterName);
                Console.WriteLine("Text: " + comment.Text);
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
