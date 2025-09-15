/*

Exceeding Requirements Report:
- In addition to the core requirements (writing entries,
  displaying, saving, and loading in a simple text format),
  I have added functionality to save and load the journal
  in **CSV format**.
- The CSV format ensures that the journal can be opened
  directly in Excel or Google Sheets for better readability,
  filtering, and analysis.
- To handle this correctly, I included:
  * A header row: (Date, Prompt, Entry)
  * Proper escaping of quotation marks and commas within text
  * A CSV parser that can handle quoted fields when loading

*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

           Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("6. Save the journal to a CSV file");
            Console.WriteLine("7. Load the journal from a CSV file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry entry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _promptText = prompt,
                        _entryText = response
                    };
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                case "6":
                    Console.Write("Enter CSV filename to save: ");
                    string csvSaveFile = Console.ReadLine();
                    journal.SaveToCsv(csvSaveFile);
                    break;

                case "7":
                    Console.Write("Enter CSV filename to load: ");
                    string csvLoadFile = Console.ReadLine();
                    journal.LoadFromCsv(csvLoadFile);
                    break;    

                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }
}