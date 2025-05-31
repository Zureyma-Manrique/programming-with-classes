using System;
using YouTubeVideos;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("How to Learn Programming in 2025", "CodeMaster", 720);
        video1.AddComment(new Comment("Alice Jhonson", "Great tutorial! Really helped me understand the basics."));
        video1.AddComment(new Comment("Will Smith", "Could you make a follow-up video about advanced topics? I really appreciate that"));
        video1.AddComment(new Comment("Carol Cabrera", "Thanks for the clear explanations. Subscribed & shared!"));
        video1.AddComment(new Comment("Jared Wilson", "This is exactly what I was looking for! I'm a beginner"));

        // Create Video 2
        Video video2 = new Video("10 Minute Morning Workout", "EasyWorkout", 567);
        video2.AddComment(new Comment("Milly Brown", "Perfect length for my busy schedule!"));
        video2.AddComment(new Comment("Frank Miller", "These exercises really work. Feeling stronger already."));
        video2.AddComment(new Comment("Thomas Lee", "Love the music choice in this video & I can workout before work!"));

        // Create Video 3
        Video video3 = new Video("5 minutes for Tacos Recipe", "5minutesChefHand", 534);
        video3.AddComment(new Comment("Jhon Taylor", "Made this last night and it was delicious!"));
        video3.AddComment(new Comment("Juan Alvarez", "Can I substitute the meat type you mentioned?"));
        video3.AddComment(new Comment("Ryker Anderson", "Best tacos recipe on YouTube hands down."));
        video3.AddComment(new Comment("Quinn Roberts", "My kids loved helping me make this! It's so easy!"));

        // Create Video 4
        Video video4 = new Video("Understanding physics for beginners", "MathsGoOn", 2300);
        video4.AddComment(new Comment("Liam Hatch",
            "Mind-blowing content! Physics was never this interesting in school."));
        video4.AddComment(new Comment("Mia Lizama", "Could you explain other concepts like electricity?"));
        video4.AddComment(new Comment("Moni Garcia", "Amazing visualization of complex concepts! I will share it with my students"));

        // Add all videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine(); 
        }
    }
}