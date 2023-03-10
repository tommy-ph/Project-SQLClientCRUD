using Microsoft.Data.SqlClient;
using Project_SQLClientCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQLClientCRUD.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; }
        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Fax, Email FROM Customer";
           
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionstringHelper.GetConnectionString())) 
                {
                    conn.Open();
                    //Make a command
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                //Handle result
                                yield return new Customer() 
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Country = reader.GetString(3),
                                    PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                    Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                                    Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                };
                            }
                        }
                    }                                   
                }
        }

        public Customer GetCustomer(string id)
        {
            Customer customer = null;
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                         "WHERE CustomerId = @CustomerId";
            //Connect
            using (SqlConnection conn = new SqlConnection(ConnectionstringHelper.GetConnectionString()))
            {
                conn.Open();
                //Make a command
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //Set parameter value
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    //Reader
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Handle result
                            customer = new Customer()
                            {
                                CustomerId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Country = reader.GetString(3),
                                PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                                Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public Customer GetCustomerByName(string name)
        {
            Customer customer = null;
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                         "WHERE FirstName = @FirstName";
            //Connect
            using (SqlConnection conn = new SqlConnection(ConnectionstringHelper.GetConnectionString()))
            {
                conn.Open();
                //Make a command
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //Set parameter value
                    cmd.Parameters.AddWithValue("@FirstName", name);
                    //Reader
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Handle result
                            customer = new Customer()
                            {
                                CustomerId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Country = reader.GetString(3),
                                PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                                Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public List<Customer> GetCustomersPage(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();

            // Create a SQL query that retrieves a page of customers from the database
            string sql = "SELECT CustomerId, FirstName, LastName, Country, " +
                "PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY;";
                        
            using (SqlConnection conn = new SqlConnection(ConnectionstringHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@limit", System.Data.SqlDbType.Int).Value = limit;
                    cmd.Parameters.Add("@offset", System.Data.SqlDbType.Int).Value = offset;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Customer customer;
                        while (reader.Read())
                        {
                            //Handle result
                            customer = new Customer()
                            {
                                CustomerId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Country = reader.GetString(3),
                                PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                                Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }


        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) " +
                         "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using (SqlConnection conn = new SqlConnection(ConnectionstringHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    success = cmd.ExecuteNonQuery() > 0;
                }
            }
            return success;
        }

        public bool UpdateCustomer(Customer customer)
        {

            bool success = false;
            string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, " +
             "Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
             "WHERE CustomerId = 5";

            using (SqlConnection conn = new SqlConnection(ConnectionstringHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    success = cmd.ExecuteNonQuery() > 0;
                }
            }
            return success;
        }

        public IEnumerable<CustomersCountry> GetNumberOfCustomersInEachCountry()
        {
            List<CustomersCountry> customersCountries = new List<CustomersCountry>();
            string sql = "SELECT Country, COUNT(*) AS NumCustomers " +
                               "FROM Customer " +
                               "GROUP BY Country " +
                               "ORDER BY NumCustomers DESC";

            using var conn = new SqlConnection(ConnectionstringHelper.GetConnectionString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                string country = reader.GetString(0);
                int customerCount = reader.GetInt32(1);
                customersCountries.Add(new CustomersCountry { Country = country, CountCountry = customerCount });
            }
            reader.Close();

            return customersCountries;
        }

        public IEnumerable<CustomerSpender> GetTopSpenders()
        {
            List<CustomerSpender> customerSpender = new List<CustomerSpender>();
            string sql = "SELECT CustomerId, SUM(Total) AS TotalTopSpender " +
                               "FROM Invoice " +
                               "GROUP BY CustomerId " +
                               "ORDER BY TotalTopSpender DESC;";
            using var conn = new SqlConnection(ConnectionstringHelper.GetConnectionString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int customerId = reader.GetInt32(0);
                decimal totalTopSpent = reader.GetDecimal(1);
                customerSpender.Add(new CustomerSpender { CustomerId = customerId, TotalTopSpent = totalTopSpent });
            }
            reader.Close();

            return customerSpender;
        }

        public IEnumerable<CustomerGenre> GetTopCustomerGenres(int customerId)
        {
            List<CustomerGenre> customerTopGenres = new List<CustomerGenre>();
            string sql = @"SELECT genre.Name AS GenreName, COUNT(track.GenreId) AS GenreCount
                   FROM Customer customer
                   INNER JOIN Invoice invoice ON customer.CustomerId = invoice.CustomerId
                   INNER JOIN InvoiceLine invoiceLine ON invoice.InvoiceId = invoiceLine.InvoiceId
                   INNER JOIN Track track ON invoiceLine.TrackId = track.TrackId
                   INNER JOIN Genre genre ON track.GenreId = genre.GenreId
                   WHERE customer.CustomerId = @customerId
                   GROUP BY genre.Name
                   HAVING COUNT(track.GenreId) = (
                     SELECT MAX(GenreCount)
                     FROM (
                       SELECT COUNT(track.GenreId) AS GenreCount
                       FROM Customer customer
                       INNER JOIN Invoice invoice ON customer.CustomerId = invoice.CustomerId
                       INNER JOIN InvoiceLine invoiceLine ON invoice.InvoiceId = invoiceLine.InvoiceId
                       INNER JOIN Track track ON invoiceLine.TrackId = track.TrackId
                       INNER JOIN Genre genre ON track.GenreId = genre.GenreId
                       WHERE customer.CustomerId = @customerId
                       GROUP BY genre.Name
                     ) AS genreCounts
                   )";

            using var conn = new SqlConnection(ConnectionstringHelper.GetConnectionString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                int genreCount = reader.GetInt32(1);
                customerTopGenres.Add(new CustomerGenre { Name = name, GenreCount = genreCount });
            }
            reader.Close();

            return customerTopGenres;
        }
    }
}
