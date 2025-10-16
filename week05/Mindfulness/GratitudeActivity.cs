using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    private List<string> _prompts;

    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity helps you reflect on the things and people you are grateful for. " +
               "Taking time to recognize gratitude can lift your mood and increase your happiness.")
    {
        _prompts = new List<string>()
        {
            "Think of someone who has recently helped you.",
            "Recall a small act of kindness you experienced today.",
            "Think about a moment this week that made you smile.",
            "Name one thing about your life that you are truly thankful for."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"→ {prompt}");
        Console.WriteLine("\nTake a few moments to reflect on this...");
        ShowSpinner(5);

        Console.WriteLine("\nNow, type a few things you feel grateful for:");
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} things you’re grateful for. 😊");
        ShowSpinner(3);
        DisplayEndingMessage();
    }
}
