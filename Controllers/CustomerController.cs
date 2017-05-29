using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Dal;
using BankAPI.Models;
namespace BankAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CustomerController : Controller
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;

           /* if(_context.Customers.Count()==0)
            {
                _context.Customers.Add(new Customer { FirstName="Aditya" });
                _context.SaveChanges();
            }*/
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if(customer==null)
            {
                return BadRequest();
            }
            _context.Customers.Add(customer);

            _context.SaveChanges();

            return Ok();
        }
    }
}
