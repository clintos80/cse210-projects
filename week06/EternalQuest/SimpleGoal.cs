using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Goal '{ShortName}' completed! You earned {Points} points!");
            Console.ResetColor();
            return Points;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("This goal is already completed.");
            Console.ResetColor();
            return 0;
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}
