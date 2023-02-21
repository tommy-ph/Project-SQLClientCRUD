using Project_SQLClientCRUD.Models;
using Project_SQLClientCRUD.Repositories;
using System.Net;
using System.Numerics;

namespace Project_SQLClientCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            SelectAllCustomer(repository);
            //Get all the Customer
            // CRUD
        }

        static void SelectAllCustomer(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void SelectCustomer(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer("Customer"));
        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach(Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Company} {customer.Address} {customer.City} {customer.State} {customer.PostalCode} {customer.Phone} {customer.Fax} {customer.Email} {customer.SupportRepId} ---");
        }

        static void Insert(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                FirstName = "Tommy",
                LastName = "Pham",
                Company = "Experis",
                Address = "Gothenburg",
                City = "Gothenburg",
                State = "Gothenburg",
                PostalCode = "12345",
                Phone = "0725559559",
                Fax = "321123123",
                Email = "tommy.experis@se.com",

            };
            if(repository.AddNewCustomer(customer))
            {
                Console.WriteLine("Insert worked");
            }else
            {
                Console.WriteLine("Checked insert again");
            };
        }

        static void Update(ICustomerRepository repository)
        {

        }
        static void Delete(ICustomerRepository repository)
        {

        }
    }
}