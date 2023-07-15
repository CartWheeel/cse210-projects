using System;
using System.Collections.Generic;

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFormattedAddress()
    {
        return $"{streetAddress}\n{city}, {state}, {country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFormattedAddress();
    }
}

class Product
{
    private string name;
    private int productId;
    private decimal price;
    private int quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public int GetProductId()
    {
        return productId;
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;

        foreach (var product in products)
        {
            totalCost += product.GetTotalPrice();
        }

        if (customer.IsInUSA())
        {
            totalCost += 5; // USA shipping cost
        }
        else
        {
            totalCost += 35; // International shipping cost
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";

        foreach (var product in products)
        {
            packingLabel += $"Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Name: {customer.GetName()}\n";
        shippingLabel += $"Address:\n{customer.GetAddress()}";

        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "Idaho", "USA");
        Customer customer1 = new Customer("Carter Williams", address1);
        List<Product> products1 = new List<Product>
        {
            new Product("Product 1", 1, 10.99m, 2),
            new Product("Product 2", 2, 5.99m, 3)
        };
        Order order1 = new Order(products1, customer1);

        Address address2 = new Address("456 Apple St", "Vancouver", "Providence", "Canada");
        Customer customer2 = new Customer("Sam Williams", address2);
        List<Product> products2 = new List<Product>
        {
            new Product("Product 3", 3, 15.99m, 1),
            new Product("Product 4", 4, 8.99m, 4)
        };
        Order order2 = new Order(products2, customer2);

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
        Console.WriteLine();

        Console.ReadLine();
    }
}
