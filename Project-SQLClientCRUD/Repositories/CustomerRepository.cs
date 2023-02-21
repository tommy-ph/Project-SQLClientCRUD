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
        public List<Customer> GetAllCustomers()
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Company, Address, City, State, PostalCode, Phone, Fax, Email FROM Customer";
            try
            {
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
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2); 
                                temp.Company = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                temp.Address = reader.GetString(4);
                                temp.City = reader.GetString(5); 
                                temp.State = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                                temp.PostalCode = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                                temp.Phone = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                                temp.Fax = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                                //temp.SupportRepId = reader.GetInt32(10);
                            }
                            reader.Close();
                        }
                    }                                   
                }
            }
            catch (SqlException ex)
            {
                //Log error
            }
           return custList;

        }

        public Customer GetCustomer(string id)
        {
            throw new NotImplementedException();
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
