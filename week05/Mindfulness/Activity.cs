using System;
using System.Threading;

public class Activity
{
    // ===== Attributes =====
    protected string _name;
    protected string _description;
    protected int _duration;

    // ===== Constructor =====
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // ===== Behaviors =====

    // Displays the starting message and sets duration
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    // Displays the ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job!");
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Spinner animation (rotates while pausing)
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b"); // erase last character
            i = (i + 1) % spinner.Length;
        }
    }

    // Countdown timer (like "Get ready in 3, 2, 1")
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
