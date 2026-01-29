using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first order - USA customer
        Address addr1 = new Address("123 Main Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", addr1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.50m, 2));
        order1.AddProduct(new Product("Keyboard", "P003", 75.00m, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        // Create second order - International customer
        Address addr2 = new Address("45 Park Lane", "London", "England", "UK");
        Customer customer2 = new Customer("Sarah Johnson", addr2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "P004", 299.99m, 1));
        order2.AddProduct(new Product("USB Cable", "P005", 12.99m, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");

        // Create third order - USA customer
        Address addr3 = new Address("789 Oak Avenue", "Denver", "CO", "USA");
        Customer customer3 = new Customer("Mike Wilson", addr3);
        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Headphones", "P006", 149.99m, 1));
        order3.AddProduct(new Product("Webcam", "P007", 89.99m, 1));

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.GetTotalCost():F2}");
    }
}