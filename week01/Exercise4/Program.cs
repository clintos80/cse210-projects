using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");


        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                continue;
            }

            if (value == 0) 
                break;

            numbers.Add(value);
        }

        
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

       
        int sum = 0;
        int max = numbers[0];
        foreach (int n in numbers)
        {
            sum += n;
            if (n > max)
                max = n;
        }

        
        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average.ToString("G17")}");
        Console.WriteLine($"The largest number is: {max}");
    }
}