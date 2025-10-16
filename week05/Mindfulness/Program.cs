/*
 * EXCEEDS REQUIREMENTS:
 * Added a custom "Gratitude Activity" that allows users to reflect on what they are thankful for.
 * This new activity encourages positivity and emotional awareness beyond the core requirements.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect an option (1–5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity();
                    gratitude.Run();
                    break;    

                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program!");
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}
