using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static int points = 0;
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine($"You have {points} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Choose a goal type: ");
        string goalTypeChoice = Console.ReadLine();

        GoalType goalType;

        switch (goalTypeChoice)
        {
            case "1":
                goalType = GoalType.Simple;
                break;
            case "2":
                goalType = GoalType.Eternal;
                break;
            case "3":
                goalType = GoalType.Checklist;
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.\n");
                return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points you want associated with this goal? ");
        int goalPoints;
        if (!int.TryParse(Console.ReadLine(), out goalPoints))
        {
            Console.WriteLine("Invalid points. Please try again.\n");
            return;
        }

        Goal goal;

        if (goalType == GoalType.Checklist)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int bonusThreshold;
            if (!int.TryParse(Console.ReadLine(), out bonusThreshold))
            {
                Console.WriteLine("Invalid bonus threshold. Please try again.\n");
                return;
            }

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints;
            if (!int.TryParse(Console.ReadLine(), out bonusPoints))
            {
                Console.WriteLine("Invalid bonus points. Please try again.\n");
                return;
            }

            goal = new ChecklistGoal(name, description, goalPoints, bonusThreshold, bonusPoints);
        }
        else
        {
            goal = new Goal(name, description, goalPoints, goalType);
        }

        goals.Add(goal);

        Console.WriteLine("Goal created successfully!\n");
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals added yet.\n");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].ToString()}");
        }

        Console.WriteLine();
    }

    static void SaveGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals added yet.\n");
            return;
        }

        Console.Write("Enter the file name to save the goals: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Goal goal in goals)
                {
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        outputFile.WriteLine($"{goal.Name}~~{goal.Description}~~{goal.Points}~~{goal.Type}~~{checklistGoal.BonusThreshold}~~{checklistGoal.BonusPoints}");
                    }
                    else
                    {
                        outputFile.WriteLine($"{goal.Name}~~{goal.Description}~~{goal.Points}~~{goal.Type}");
                    }
                }
            }

            Console.WriteLine("Goals saved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
    }

    static void LoadGoals()
    {
        Console.Write("Enter the file name to load the goals: ");
        string fileName = Console.ReadLine();

        try
        {
            if (File.Exists(fileName))
            {
                goals.Clear();

                using (StreamReader inputFile = new StreamReader(fileName))
                {
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        string[] parts = line.Split("~~");
                        if (parts.Length >= 4)
                        {
                            string name = parts[0];
                            string description = parts[1];
                            int points = int.Parse(parts[2]);
                            GoalType type = (GoalType)Enum.Parse(typeof(GoalType), parts[3]);

                            Goal goal;

                            if (type == GoalType.Checklist && parts.Length == 6)
                            {
                                int bonusThreshold = int.Parse(parts[4]);
                                int bonusPoints = int.Parse(parts[5]);
                                goal = new ChecklistGoal(name, description, points, bonusThreshold, bonusPoints);
                            }
                            else
                            {
                                goal = new Goal(name, description, points, type);
                            }

                            goals.Add(goal);
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully!\n");
            }
            else
            {
                Console.WriteLine("File not found.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
    }

    static void RecordEvent()
    {
        ListGoals();

        Console.Write("Select the goal number to record an event for: ");
        string goalChoice = Console.ReadLine();

        int goalNumber;
        if (!int.TryParse(goalChoice, out goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal number. Please try again.\n");
            return;
        }

        Goal selectedGoal = goals[goalNumber - 1];

        Console.Write("Enter a description of the event: ");
        string eventDescription = Console.ReadLine();

        selectedGoal.AddEvent(eventDescription);
        points += selectedGoal.Points;

        Console.WriteLine("Event recorded successfully!\n");
    }
}

enum GoalType
{
    Simple,
    Eternal,
    Checklist
}

class Goal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }
    public GoalType Type { get; }
    public List<string> Events { get; }

    public Goal(string name, string description, int points, GoalType type)
    {
        Name = name;
        Description = description;
        Points = points;
        Type = type;
        Events = new List<string>();
    }

    public void AddEvent(string eventDescription)
    {
        Events.Add(eventDescription);
    }

    public override string ToString()
    {
        string goalType = Type.ToString();
        string events = string.Join(", ", Events);
        string completedStatus = events.Length > 0 ? "[X]" : "[ ]";

        return $"{completedStatus} {Name} ({Description}) - Type: {goalType} - Events: {events}";
    }
}

class ChecklistGoal : Goal
{
    public int BonusThreshold { get; }
    public int BonusPoints { get; }

    public ChecklistGoal(string name, string description, int points, int bonusThreshold, int bonusPoints)
        : base(name, description, points, GoalType.Checklist)
    {
        BonusThreshold = bonusThreshold;
        BonusPoints = bonusPoints;
    }

    public override string ToString()
    {
        string baseString = base.ToString();
        return $"{baseString} - Bonus Threshold: {BonusThreshold} - Bonus Points: {BonusPoints}";
    }
}
