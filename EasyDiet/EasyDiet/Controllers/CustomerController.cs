using EasyDietCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataContext _context;

        public CustomerController(IDataContext context)
        {
            _context = context;
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Customer c = _context.Customers.Find(c => c.Id == id);
            if (c is null)
            {
                return NotFound();
            }
            return Ok(c);
        }

        // POST 
        [HttpPost]
        public void Post(int id, string name, int codeDiet)
        {
            Diet diet = _context.Diets.Find(d => d.Code == codeDiet);
            if (diet != null && diet.Status)
            {
                Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == diet.Coach);
                Customer customer = new Customer(id, name, diet);
                _context.Customers.Add(customer);
                _context.Coaches.Find(c => coach.Id == c.Id).MyCustomers.Add(customer);
            }
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, string name, int codeDiet, bool status)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            Diet diet = _context.Diets.FirstOrDefault(d => d.Code == codeDiet);
            if (customer != null && diet != null && diet.Status)
            {
                customer.Id = id;
                customer.Name = name;
                customer.Status = status;
                diet.Code = codeDiet;
                if (diet.Coach != customer.MyDiet.Coach)
                {
                    Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == customer.MyDiet.Coach);
                    coach.MyCustomers.Remove(customer);
                    coach.MyCustomers.Add(customer);
                }
                customer.MyDiet = diet;

            }
        }


        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == customer.MyDiet.Coach);
                customer.Status = false;
                coach.MyCustomers.Remove(customer);
            }
        }
    }
}
