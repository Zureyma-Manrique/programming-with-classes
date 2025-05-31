using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Salt Lake City", "Utah", "USA");
        Address address2 = new Address("Vicente Guerrero 316", "Mexico City", "Gustavo A. Madero", "Mexico");

        Customer customer1 = new Customer("Mia Salas", address1);
        Customer customer2 = new Customer("Sarah Fuentes", address2);

        // Products for Order 1
        Product product1 = new Product("Wireless Headphones", "WH-001", 99.00, 1);
        Product product2 = new Product("USB Cable", "USB-002", 12.50, 2);
        Product product3 = new Product("Phone Case", "PC-003", 24.75, 1);

        // Products for Order 2
        Product product4 = new Product("Bluetooth Speaker", "BS-001", 149.50, 1);
        Product product5 = new Product("Power Bank", "PB-002", 45.00, 1);
        Product product6 = new Product("Screen Protector", "SP-003", 9.99, 3);

        // Create Order 1 - USA customer
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create Order 2 - International customer
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        Console.WriteLine("| ==== | ORDER 1 | ==== |");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("| ==== | ORDER 2 | ==== |");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}