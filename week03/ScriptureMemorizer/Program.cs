using System;
using System.IO;

/*
 *  EXCEEDING REQUIREMENTS 
 *  Added functionality: The program now loads a scripture
 *  from a text file named "scripture.txt" instead of hardcoding it.
 *  This demonstrates file reading and dynamic scripture loading.
 */

class Program
{
    static void Main()
    {
        string filePath = "scripture.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: 'scripture.txt' not found. Please ensure the file exists.");
            return;
        }

        string line = File.ReadAllText(filePath);
        string[] parts = line.Split('|');

        if (parts.Length != 2)
        {
            Console.WriteLine("Error: The file format is incorrect. It should be 'Reference|Text'");
            return;
        }

        string referencePart = parts[0];
        string scriptureText = parts[1];

        // Parse the reference (e.g., "Proverbs 3:5-6")
        string[] refParts = referencePart.Split(' ');
        string book = refParts[0];
        string[] chapterVerse = refParts[1].Split(':');
        int chapter = int.Parse(chapterVerse[0]);

        int verseStart, verseEnd;
        if (chapterVerse[1].Contains('-'))
        {
            string[] range = chapterVerse[1].Split('-');
            verseStart = int.Parse(range[0]);
            verseEnd = int.Parse(range[1]);
        }
        else
        {
            verseStart = verseEnd = int.Parse(chapterVerse[1]);
        }

        Reference reference = new Reference(book, chapter, verseStart, verseEnd);
        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to end:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending...");
                break;
            }
        }
    }
}
