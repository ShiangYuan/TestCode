using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CustomerViewModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
