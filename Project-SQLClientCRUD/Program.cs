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
            var repository = new CustomerRepository { ConnectionString = ConnectionstringHelper.GetConnectionString() };

            while (true)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Select all customers");
                Console.WriteLine("2. Select customer by ID");
                Console.WriteLine("3. Select customer by name");
                Console.WriteLine("4. Select customers by page");
                Console.WriteLine("5. Insert customer");
                Console.WriteLine("6. Update customer");
                Console.WriteLine("7. Show different group countries");
                Console.WriteLine("8. Show top spenders");
                Console.WriteLine("9. Show top customer genres");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SelectAllCustomers(repository);
                        break;
                    case "2":
                        SelectCustomerById(repository);
                        break;
                    case "3":
                        SelectCustomerByName(repository);
                        break;
                    case "4":
                        SelectCustomersPage(repository);
                        break;
                    case "5":
                        Insert(repository);
                        break;
                    case "6":
                        Update(repository);
                        break;
                    case "7":
                        ShowDifferentGroupCountries(repository);
                        break;
                    case "8":
                        ShowCustomersTopSpenders(repository);
                        break;
                    case "9":
                        ShowTopCustomerGenres(repository);
                        break;
                    case "0":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine(); // blank line for formatting purposes
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear(); // clear the console before showing the menu again
            }
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
            Console.WriteLine("\n** Customer Topspender **");
            Console.WriteLine("{0,-20} {1,-20}", "Customer", "TopSpender");
            Console.WriteLine("************************************");
            foreach (var customerTopSpender in customerTopSpenders)
            {
                Console.WriteLine("{0,-20} {1,-20}", customerTopSpender.CustomerId, customerTopSpender.TotalTopSpent);
            }
        }

        static void ShowTopCustomerGenres(ICustomerRepository repository)
        {
            Console.WriteLine("Enter a customer ID:");
            int customerId = int.Parse(Console.ReadLine());

            IEnumerable<CustomerGenre> customerTopGenres = repository.GetTopCustomerGenres(customerId);

            if (customerTopGenres.Any())
            {
                Console.WriteLine($"Top genre(s) for customer {customerId}:");
                foreach (CustomerGenre genre in customerTopGenres)
                {
                    Console.WriteLine($"Genre: {genre.Name}, Count: {genre.GenreCount}");
                }
            }
            else
            {
                Console.WriteLine($"No top genres found for customer {customerId}.");
            }
        }








    }
}