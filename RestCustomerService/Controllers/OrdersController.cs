using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestCustomerService.model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        internal static readonly List<Order> OList = new List<Order>
        {
            new Order {Id = 1, CustomerId = 1, Item = "Book", Price = 12.45},
            new Order {Id = 2, CustomerId = 1, Item = "Another book", Price = 21.34}
        };

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return OList;
        }

        // GET: api/Orders/5
        //[HttpGet("{id}", Name = "Get")]
        public Order Get(int id)
        {
            return OList.FirstOrDefault(order => order.Id == id);
        }

        [Route("customer/{customerId}")]
        public IEnumerable<Order> GetByCustomerId(int customerId)
        {
            return OList.FindAll(order => order.CustomerId == customerId);
        }

        // POST: api/Orders
        [HttpPost]
        public Order Post([FromBody] Order value)
        {
            value.Id = Order.NextId++;
            OList.Add(value);
            return value;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public Order Put(int id, [FromBody] Order value)
        {
            Order o = OList.FirstOrDefault(order => order.Id == id);
            if (o == null) return null;
            o.CustomerId = value.CustomerId;
            o.Item = value.Item;
            o.Price = value.Price;
            return o;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Order Delete(int id)
        {
            Order o = OList.FirstOrDefault(order => order.Id == id);
            if (o == null) return null;
            OList.Remove(o);
            return o;
        }
    }
}
