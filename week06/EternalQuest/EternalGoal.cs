using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"You recorded '{ShortName}' and earned {Points} points!");
        Console.ResetColor();
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{ShortName}|{Description}|{Points}";
    }
}
