using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        bool quit = false;
        while (!quit)
        {
            DisplayMenu();
            string selection = Console.ReadLine();

            if (int.TryParse(selection, out int activityIndex) && activityIndex >= 1 && activityIndex <= activities.Count)
            {
                Activity selectedActivity = activities[activityIndex - 1];
                selectedActivity.StartActivity();
            }
            else if (selection == "4")
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        Console.Write("What would you like to do? ");
    }
}

abstract class Activity
{
    public abstract string Description { get; }
    public abstract void StartActivity();

    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine("========================================================================================================================================================");
        Console.WriteLine("Prepare to begin...");
        Pause(3);
        Console.WriteLine("Loading activity...");
        Pause(3);        
        Console.WriteLine(Description);
        Console.WriteLine("========================================================================================================================================================");
        Console.WriteLine();
    }

    protected void ShowFinishingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("========================================================================================================================================================");
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine("Taking back to menu...");
        Console.WriteLine("========================================================================================================================================================");
        Pause(3);
        Console.Clear();
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(" -");

            Thread.Sleep(1000);

            Console.Write("\b \b");
            Console.Write("o");
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public override string Description => "Breathing Activity: This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

    public override void StartActivity()
    {
        ShowStartingMessage();
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        while (DateTime.Now < futureTime)
        {
            Console.WriteLine("Breathe in for 4...");
            Pause(4);
            Console.WriteLine("Breathe out for 8...");
            Pause(8);
        }

        ShowFinishingMessage();
    }

    private int GetDuration()
    {
        Console.Write("How long, in seconds, would you like for you session? ");
        return int.Parse(Console.ReadLine());
    }
}

class ReflectionActivity : Activity
{
    public override string Description => "Reflection Activity: This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void StartActivity()
    {
        ShowStartingMessage();
        int duration = GetDuration();

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(5);

        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        while (DateTime.Now < futureTime)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            Pause(5);
        }

        ShowFinishingMessage();
    }

    private int GetDuration()
    {
        Console.Write("How long, in seconds, would you like for you session? ");
        return int.Parse(Console.ReadLine());
    }
}

class ListingActivity : Activity
{
    public override string Description => "Listing Activity: This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void StartActivity()
    {
        ShowStartingMessage();
        int duration = GetDuration();

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3);


        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        List<string> items = new List<string>();
        while (DateTime.Now < futureTime)
        {
            Console.Write("Your answer: ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"Number of items entered: {items.Count}");

        ShowFinishingMessage();
    }

    private int GetDuration()
    {
        Console.Write("How long, in seconds, would you like for you session? ");
        return int.Parse(Console.ReadLine());
    }
}
