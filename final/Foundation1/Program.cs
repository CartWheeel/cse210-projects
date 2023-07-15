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
            Title = "Video 1",
            Author = "Author 1",
            LengthInSeconds = 120,
            Comments = new List<Comment>
            {
                new Comment { CommenterName = "User 1", Text = "Comment 1" },
                new Comment { CommenterName = "User 2", Text = "Comment 2" },
                new Comment { CommenterName = "User 3", Text = "Comment 3" }
            }
        };
        videos.Add(video1);

        Video video2 = new Video
        {
            Title = "Video 2",
            Author = "Author 2",
            LengthInSeconds = 180,
            Comments = new List<Comment>
            {
                new Comment { CommenterName = "User 4", Text = "Comment 4" },
                new Comment { CommenterName = "User 5", Text = "Comment 5" }
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
