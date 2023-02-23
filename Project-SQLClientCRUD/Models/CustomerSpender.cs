using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQLClientCRUD.Models
{
    public class CustomerSpender
    {
        public int CustomerId { get; set; }
        public Decimal TotalTopSpent { get; set; }
    }
}
