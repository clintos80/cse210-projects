using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        
        Random rnd = new Random();
        int magic = rnd.Next(1, 101);


        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != magic)
        {
            if (guess < magic)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }

            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("You guessed it!");
    }
}