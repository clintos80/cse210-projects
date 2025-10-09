using System;
using System.Collections.Generic;

namespace OnlineOrderingProgram
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Trim().ToUpper() == "USA";
        }

        public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }

        public string GetName()
        {
            return _name;
        }

        public string GetAddressString()
        {
            return _address.GetFullAddress();
        }
    }

    public class Product
    {
        private string _name;
        private string _productId;
        private float _price;
        private int _quantity;

        public Product(string name, string productId, float price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public float GetTotalCost()
        {
            return _price * _quantity;
        }

        public string GetProductInfo()
        {
            return $"{_name} (ID: {_productId})";
        }
    }

    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public float GetTotalPrice()
        {
            float total = 0;
            foreach (Product p in _products)
            {
                total += p.GetTotalCost();
            }

            if (_customer.LivesInUSA())
            {
                total += 5;
            }
            else
            {
                total += 35;
            }

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product p in _products)
            {
                label += $" - {p.GetProductInfo()}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "Shipping Label:\n";
            label += $"{_customer.GetName()}\n{_customer.GetAddressString()}\n";
            return label;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main Street", "Dallas", "TX", "USA");
            Customer customer1 = new Customer("Steven Stones", address1);
            Order order1 = new Order(customer1);

            order1.AddProduct(new Product("Laptop", "P1001", 899.99f, 1));
            order1.AddProduct(new Product("Mouse", "P1002", 25.50f, 2));

            Address address2 = new Address("45 Victoria Island", "Lagos", "Lagos State", "Nigeria");
            Customer customer2 = new Customer("Ada Okafor", address2);
            Order order2 = new Order(customer2);

            order2.AddProduct(new Product("Smartphone", "P2001", 650.00f, 1));
            order2.AddProduct(new Product("Headphones", "P2002", 120.00f, 1));
            order2.AddProduct(new Product("Power Bank", "P2003", 45.00f, 2));

            List<Order> orders = new List<Order> { order1, order2 };

            foreach (Order order in orders)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
                Console.WriteLine("=======================================\n");
            }
        }
    }
}
