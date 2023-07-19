using System;
using System.Collections.Generic;

class Activity
{
    private DateTime date;
    protected int lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    public virtual decimal GetDistance()
    {
        return 0;
    }

    public virtual decimal GetSpeed()
    {
        return 0;
    }

    public virtual decimal GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        string summary = $"{date.ToShortDateString()} {GetType().Name} ({lengthInMinutes} min):";

        decimal distance = GetDistance();
        if (distance > 0)
        {
            summary += $" Distance: {distance} km";
        }

        decimal speed = GetSpeed();
        if (speed > 0)
        {
            summary += $" Speed: {speed} kph";
        }

        decimal pace = GetPace();
        if (pace > 0)
        {
            summary += $" Pace: {pace} min per km";
        }

        return summary;
    }
}

class Running : Activity
{
    private decimal distance;

    public Running(DateTime date, int lengthInMinutes, decimal distance)
        : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    public override decimal GetDistance()
    {
        return distance;
    }

    public override decimal GetSpeed()
    {
        return (distance / lengthInMinutes) * 60;
    }

    public override decimal GetPace()
    {
        return lengthInMinutes / distance;
    }
}

class Cycling : Activity
{
    private decimal speed;

    public Cycling(DateTime date, int lengthInMinutes, decimal speed)
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override decimal GetSpeed()
    {
        return speed;
    }

    public override decimal GetDistance()
    {
        return (speed / 60) * lengthInMinutes;
    }

    public override decimal GetPace()
    {
        return 60 / (speed / GetDistance());
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override decimal GetDistance()
    {
        return laps * 50 / 1000m; // Convert meters to kilometers
    }

    public override decimal GetPace()
    {
        return lengthInMinutes / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        DateTime date = new DateTime(2022, 11, 3);

        Running running = new Running(date, 30, 3.0m);
        activities.Add(running);

        Cycling cycling = new Cycling(date, 30, 6.0m);
        activities.Add(cycling);

        Swimming swimming = new Swimming(date, 30, 60);
        activities.Add(swimming);

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

    }
}
