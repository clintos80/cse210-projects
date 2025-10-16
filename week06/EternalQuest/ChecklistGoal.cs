using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted < _target)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Progress recorded for '{ShortName}' ({_amountCompleted}/{_target}). You earned {Points} points!");
            Console.ResetColor();
            return Points;
        }
        else if (_amountCompleted == _target)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"🎉 Congratulations! You completed '{ShortName}' and earned {Points + _bonus} points (including bonus)!");
            Console.ResetColor();
            return Points + _bonus;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"'{ShortName}' is already complete.");
            Console.ResetColor();
            return 0;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}
