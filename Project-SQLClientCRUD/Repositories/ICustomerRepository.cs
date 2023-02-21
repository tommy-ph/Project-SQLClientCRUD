using Project_SQLClientCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQLClientCRUD.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(string id);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);
    }
}
