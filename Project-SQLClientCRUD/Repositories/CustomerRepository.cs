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
            string sql = "SELECT CustomerId, FirstName, LastName, Company, Address, City, State, PostalCode, Phone, Fax, Email FROM Customer";
           
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
                                { CustomerId = reader.GetInt32(0),
                                  FirstName = reader.GetString(1),
                                  LastName = reader.GetString(2),
                                  Company = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                  Address = reader.GetString(4),
                                  City = reader.GetString(5),
                                  State = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                  PostalCode = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                  Phone = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                  Fax = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                                };
                            }
                        }
                    }                                   
                }
        }

        public Customer GetCustomer(string id)
        {
            Customer customer = null;
            string sql = "SELECT CustomerId, FirstName, LastName, Company, Address, City, State, PostalCode, Phone, Fax, Email FROM Customer " +
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
                                Company = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Address = reader.GetString(4),
                                City = reader.GetString(5),
                                State = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                PostalCode = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                Phone = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                Fax = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
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
            string sql = "SELECT CustomerId, FirstName, LastName, Company, Address, City, State, PostalCode, Phone, Fax, Email FROM Customer " +
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
                                Company = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Address = reader.GetString(4),
                                City = reader.GetString(5),
                                State = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                PostalCode = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                Phone = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                Fax = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                            };
                        }
                    }
                }
            }
            return customer;
        }
        public bool AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        
    }
}
