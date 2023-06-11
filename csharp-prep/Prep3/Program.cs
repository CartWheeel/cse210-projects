using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int answer = 0;

        // We could also use a do-while loop here...
        while (answer != magicNumber)
        {
            Console.Write("What is your answer? ");
            answer = int.Parse(Console.ReadLine());

            if (magicNumber > answer)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < answer)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it!");
            }
            // to test
            // Console.WriteLine($"{magicNumber}");

        }                    
    }
}