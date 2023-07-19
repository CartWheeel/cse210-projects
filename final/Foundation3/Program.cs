using System;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFormattedAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GenerateStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFormattedAddress()}";
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nWeather: {weatherStatement}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "Idaho", "USA");
        Lecture lecture = new Lecture("Lecture Title", "Lecture Description", DateTime.Now, TimeSpan.FromHours(2), address1, "Speaker Name", 100);

        Address address2 = new Address("456 Dunes", "Peoria", "Arizona", "USA");
        Reception reception = new Reception("Reception Title", "Reception Description", DateTime.Now.AddDays(1), TimeSpan.FromHours(3), address2, "rsvp@example.com");

        Address address3 = new Address("789 Shasta", "Pocatello", "Idaho", "USA");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", DateTime.Now.AddDays(2), TimeSpan.FromHours(4), address3, "Sunny and clear");

        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GenerateStandardDetails());
        Console.WriteLine(lecture.GenerateFullDetails());
        Console.WriteLine(lecture.GenerateShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GenerateStandardDetails());
        Console.WriteLine(reception.GenerateFullDetails());
        Console.WriteLine(reception.GenerateShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(outdoorGathering.GenerateStandardDetails());
        Console.WriteLine(outdoorGathering.GenerateFullDetails());
        Console.WriteLine(outdoorGathering.GenerateShortDescription());

        Console.ReadLine();
    }
}
