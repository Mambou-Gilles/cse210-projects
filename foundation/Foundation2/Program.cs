using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");
        //Create the addresses
        var address1 = new Address("123 Joseph Smith", "Ohio", "Utah", "USA");
        Address address2 = new Address("456 Oak Str", "Toronto", "ON", "Canada");

        //Create customers
        Customer customer1 = new Customer("John Abel", address1);
        Customer customer2 = new Customer("Jospehine Cruz", address2);

        //create the products

        var product1 = new Product("Toy", "P001", 10.50m, 3);
        var product2 = new Product("Gadget", "P002", 20.00m, 2);
        var product3 = new Product("Lotion", "P003", 15.75m, 1);

        //Create orders
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        //Display the result for order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.TotalCost():F2}");

        Console.WriteLine();
        
        //Display result for order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.TotalCost():F2}");

    }
}