using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestCustomerService.model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> CList = new List<Customer>
        {
            new Customer {Id = 1, FirstName = "Anders", LastName = "B", Year = 2000}
        };

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return CList;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return CList.FirstOrDefault(customer => customer.Id == id);
        }

        [Route("{customerId}/orders")]
        public IEnumerable<Order> GetByCustomerId(int customerId)
        {
            return OrdersController.OList.FindAll(order => order.CustomerId == customerId);
        }

        // POST: api/Customers
        [HttpPost]
        public Customer Post([FromBody] Customer value)
        {
            value.Id = Customer.NextId++; ;
            CList.Add(value);
            return value;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public Customer Put(int id, [FromBody] Customer value)
        {
            Customer c = CList.FirstOrDefault(customer => customer.Id == id);
            if (c == null) return null;
            c.FirstName = value.FirstName;
            c.LastName = value.LastName;
            c.Year = value.Year;
            return c;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Customer Delete(int id)
        {
            Customer c = CList.FirstOrDefault(customer => customer.Id == id);
            if (c == null) return null;
            CList.Remove(c);
            return c;
        }
    }
}
