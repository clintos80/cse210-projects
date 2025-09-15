using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }


    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully (custom format).");
    }


    public void LoadFromFile(string file)
    {
        _entries.Clear();

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2]
                    };
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully (custom format).");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }


    public void SaveToCsv(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            
            writer.WriteLine("Date,Prompt,Entry");

            foreach (Entry entry in _entries)
            {
                
                string safePrompt = entry._promptText.Replace("\"", "\"\"");
                string safeEntry = entry._entryText.Replace("\"", "\"\"");

                writer.WriteLine($"{entry._date},\"{safePrompt}\",\"{safeEntry}\"");
            }
        }
        Console.WriteLine("Journal saved successfully (CSV format).");
    }

   
    public void LoadFromCsv(string file)
    {
        _entries.Clear();

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = SplitCsvLine(line);

                if (parts.Length == 3)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2]
                    };
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully (CSV format).");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    
    private string[] SplitCsvLine(string line)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes; 
            }
            else if (c == ',' && !inQuotes)
            {
                parts.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }
        parts.Add(current);

        return parts.ToArray();
    }
}