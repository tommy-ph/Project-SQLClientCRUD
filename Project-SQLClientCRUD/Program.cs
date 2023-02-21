using Project_SQLClientCRUD.Models;
using Project_SQLClientCRUD.Repositories;
using System.Net;
using System.Numerics;

namespace Project_SQLClientCRUD
{
    public class Program
    {
        static void Main(string[] args)
        {
            var repository = new CustomerRepository { ConnectionString = ConnectionstringHelper.GetConnectionString() };
            //SelectAllCustomers(repository);
            //SelectCustomerById(repository);
            SelectCustomerByName(repository);
            //Get all the Customer
            // CRUD
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

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach(Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Company} {customer.Address} {customer.City} {customer.State} {customer.PostalCode} {customer.Phone} {customer.Fax} {customer.Email} ---");
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