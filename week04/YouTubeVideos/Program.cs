using System;
using System.Collections.Generic;

namespace YouTubeVideoProgram
{
    public class Comment
    {
        private string _commenterName;
        private string _commentText;

        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        public void DisplayComment()
        {
            Console.WriteLine($"   {_commenterName}: {_commentText}");
        }
    }

    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_lengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in _comments)
            {
                comment.DisplayComment();
            }
            Console.WriteLine("-----------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("C# Basics for Beginners", "TechWorld", 480);
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("John", "Very helpful tutorial."));
            video1.AddComment(new Comment("Mary", "I finally understand classes now!"));

            Video video2 = new Video("Cooking Jollof Rice", "Chef Ada", 720);
            video2.AddComment(new Comment("Tunde", "Looks so delicious!"));
            video2.AddComment(new Comment("Grace", "I tried it and it came out great."));
            video2.AddComment(new Comment("Emma", "Can you make a fried rice version next?"));

            Video video3 = new Video("Travel Vlog: Exploring Delta State", "Clinton Travels", 960);
            video3.AddComment(new Comment("David", "Beautiful views!"));
            video3.AddComment(new Comment("Sandra", "I love the cultural part."));
            video3.AddComment(new Comment("Victor", "This made me want to visit soon!"));

            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            foreach (Video video in videos)
            {
                video.DisplayVideoInfo();
            }

            Console.WriteLine("Press any key to exit...");
        }
    }
}
