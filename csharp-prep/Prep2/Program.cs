using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What percent was your grade? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";
        //if statements to determine letter grade based on user input
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You did it!");
        }
        else
        {
            Console.WriteLine("Keep trying and never give up!");
        }
    }
}