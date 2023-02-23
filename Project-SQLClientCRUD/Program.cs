using Microsoft.Data.SqlClient;
using Project_SQLClientCRUD.Models;
using Project_SQLClientCRUD.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Numerics;

namespace Project_SQLClientCRUD
{
    public class Program
    {
        static void Main(string[] args)
        {
            // CRUD
            var repository = new CustomerRepository { ConnectionString = ConnectionstringHelper.GetConnectionString() };
            //SelectAllCustomers(repository);
            //SelectCustomerById(repository);
            //SelectCustomerByName(repository);
            //SelectCustomersPage(repository);
            //Insert(repository);
            //Update(repository);
            //ShowDifferentGroupCountries(repository);
            ShowCustomersTopSpenders(repository);


        }

        static void SelectAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void SelectCustomerById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer("1"));
        }

        static void SelectCustomerByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("Luís"));
        }

        static void SelectCustomersPage(ICustomerRepository repository)
        {
            int limit = 5;
            int offset = 0;
            PrintCustomersPage(repository.GetCustomersPage(limit, offset));
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
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} ---");
        }

        static void PrintCustomersPage(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
                Console.WriteLine("{0}", customer.Country);
                Console.WriteLine("{0}", customer.PostalCode);
                Console.WriteLine("{0}", customer.Phone);
                Console.WriteLine("{0}", customer.Email);
                Console.WriteLine("----------------------------");
            }
        }

        static void Insert(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                FirstName = "Tommy",
                LastName = "Pham",
                Company = "Experis",
                Country = "Sweden",
                PostalCode = "12345",
                Phone = "0725559559",
                Email = "tommy.experis@se.com",

            };
            if(repository.AddNewCustomer(customer))
            {
                Console.WriteLine("Insert worked");
                PrintCustomer(repository.GetCustomer("60"));
            }else
            {
                Console.WriteLine("Checked insert again");
            };
        }

        static void Update(ICustomerRepository repository)
        {
            Customer updatedCustomer = new Customer()
            {
                CustomerId = 1,
                FirstName = "Maryam",
                LastName = "Al",
                Country = "Irak",
                PostalCode = "12345",
                Phone = "555-555-1212",
                Email = "maryamAl@gmail.com"
            };
            if(repository.UpdateCustomer(updatedCustomer) )
            {
                Console.WriteLine("Updated sucess");
                PrintCustomer(repository.GetCustomer("1"));
            }
            else
            {
                Console.WriteLine("Unsuccess updated");
            }
        }
        static void ShowDifferentGroupCountries(ICustomerRepository repository)
        {

            var customerCountCountries = repository.GetNumberOfCustomersInEachCountry();
            Console.WriteLine("\n** Customer each Country **");
            Console.WriteLine("{0,-20} {1,-20}", "Country", "Count");
            Console.WriteLine("************************************");
            foreach (var customersCountry in customerCountCountries)
            {
                Console.WriteLine("{0,-20} {1,-20}", customersCountry.Country, customersCountry.CountCountry);
            }
        }

        static void ShowCustomersTopSpenders(ICustomerRepository repository)
        {
            var customerTopSpenders = repository.GetTopSpenders();
            Console.WriteLine("\n** Customer each Country **");
            Console.WriteLine("{0,-20} {1,-20}", "Country", "Count");
            Console.WriteLine("************************************");
            foreach (var customerTopSpender in customerTopSpenders)
            {
                Console.WriteLine("{0,-20} {1,-20}", customerTopSpender.CustomerId, customerTopSpender.TotalTopSpent);
            }
        }







    }
}