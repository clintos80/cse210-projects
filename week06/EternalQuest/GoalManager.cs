using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _badges = new List<string>();

    public void Start()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--- Eternal Quest Menu ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Score & Level");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice: ");
            Console.ResetColor();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": ShowProgress(); break;
                case "7": return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a goal type: ");
        string type = Console.ReadLine();

        Console.Write("Enter short name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target number: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        ListGoals();
        Console.Write("Enter goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earnedPoints = _goals[index].RecordEvent();
            _score += earnedPoints;
            CheckLevelUp();
            CheckMilestones();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 500) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n🌟 Level Up! You reached Level {_level}!");
            Console.ResetColor();
        }
    }

    private void CheckMilestones()
    {
        if (_score >= 1000 && !_badges.Contains("Bronze"))
        {
            AwardBadge("Bronze");
        }
        else if (_score >= 2000 && !_badges.Contains("Silver"))
        {
            AwardBadge("Silver");
        }
        else if (_score >= 3000 && !_badges.Contains("Gold"))
        {
            AwardBadge("Gold");
        }
    }

    private void AwardBadge(string badge)
    {
        _badges.Add(badge);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"🏅 You earned the {badge} Badge!");
        Console.ResetColor();
    }

    private void ShowProgress()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\nYour Current Score: {_score}");
        Console.WriteLine($"Your Level: {_level}");
        if (_badges.Count > 0)
        {
            Console.WriteLine("Your Badges: " + string.Join(", ", _badges));
        }
        else
        {
            Console.WriteLine("No badges earned yet.");
        }
        Console.ResetColor();
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string file = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine($"{_score}|{_level}|{string.Join(",", _badges)}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(file);
        string[] header = lines[0].Split("|");
        _score = int.Parse(header[0]);
        _level = int.Parse(header[1]);
        _badges = new List<string>(header[2].Split(",", StringSplitOptions.RemoveEmptyEntries));

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];
            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}
