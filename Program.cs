using ShopApplication.Models;
using System;
using System.Collections.Generic;

namespace ShopApplication
{
    internal class Program
    {
        public static List<Customer> customers;
        static void Main(string[] args)
        {
            Product product1 = new Product(100, "Product A", 100.0, 10.0);
            Product product2 = new Product(101, "Product B", 200.0, 15.0);
            Product product3 = new Product(102, "Product C", 300.0, 5.0);
            Product product4 = new Product(103, "Product D", 400.0, 20.0);

            customers = new List<Customer>();

            Customer customer1 = new Customer(1, "Nani");
            Order order1 = new Order(1, DateTime.Now);
            order1.AddLineItem(new LineItem(1, 2, product1));
            order1.AddLineItem(new LineItem(2, 1, product2));
            customer1.AddOrder(order1);

            Order order2 = new Order(2, DateTime.Now);
            order2.AddLineItem(new LineItem(1, 1, product3));
            order2.AddLineItem(new LineItem(2, 3, product4));
            customer1.AddOrder(order2);
            customers.Add(customer1);

            Customer customer2 = new Customer(2, "Dheeraj");
            Order order3 = new Order(3, DateTime.Now);
            order3.AddLineItem(new LineItem(1, 2, product2));
            order3.AddLineItem(new LineItem(2, 1, product4));
            customer2.AddOrder(order3);
            customers.Add(customer2);

            ViewCustomerDetails(customers);
            DisplayAllOrders(customers);
        }

        private static void ViewCustomerDetails(List<Customer> customers)
        {
            Console.Write("Enter Customer Id to View Customer Details: ");
            int customerId = int.Parse(Console.ReadLine());

            Customer customer = customers.Find(c => c.Id == customerId);
            if (customer != null)
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine($"Customer Id: {customer.Id}");
                Console.WriteLine($"Customer Name: {customer.Name}");
                Console.WriteLine($"Order Count: {customer.Orders.Count}");
                Console.WriteLine("*********************************************");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public static void DisplayAllOrders(List<Customer> customers)
        {
            Console.Write("Enter Customer Id to Display all orders: ");
            int customerId = int.Parse(Console.ReadLine());

            Customer customer = customers.Find(c => c.Id == customerId);
            if (customer != null)
            {
                Console.WriteLine($"\nDisplaying Orders for Customer: {customer.Name}");
                int orderNo = 1;
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"\nOrder No. {orderNo++}");
                    Console.WriteLine($"Order Id: {order.Id}");
                    Console.WriteLine($"Order Date: {order.Date}");

                    foreach (var item in order.Items)
                    {
                        var product = item.products;
                        Console.WriteLine("========================================================================================================================================================");
                        Console.WriteLine($"LineItemId: {item.Id}, ProductId: {product.Id}, ProductName: {product.Name}, " +
                                          $"Quantity: {item.Quantity}, UnitPrice: {product.Price}, Discount%: {product.DiscountPercent} " +
                                          $"UnitCostAfterDiscount: {product.calculateDiscountedPrice()} --->TotalLineItemCost: {item.CalculateItemCost()}");
                    }
                    Console.WriteLine("========================================================================================================================================================");
                    Console.WriteLine($"                                                                                                                 Total Order Cost: {order.CalculateOrderPrice()}\n");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
    }
}
