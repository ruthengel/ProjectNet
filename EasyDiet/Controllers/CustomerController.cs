using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET 
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return Data.Customers.Find(c => c.Id == id);
        }

        // POST 
        [HttpPost]
        public void Post(int id, string name, int codeDiet)
        {
            Diet diet = Data.Diets.Find(d => d.Code == codeDiet);
            if (diet != null && diet.Status)
            {
                Coach coach = Data.Coaches.FirstOrDefault(c => c.Id ==diet.Coach );
                Customer customer = new Customer(id, name, diet);
                Data.Customers.Add(customer);
                Data.Coaches.Find(c => coach.Id == c.Id).MyCustomers.Add(customer);
            }
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id,  string name, int codeDiet,bool status)
        {
            Customer customer = Data.Customers.FirstOrDefault(c => c.Id == id);
            Diet diet = Data.Diets.FirstOrDefault(d => d.Code == codeDiet);
            if (customer != null && diet != null && diet.Status)
            {
                customer.Id = id;
                customer.Name = name;
                customer.Status = status;
                diet.Code = codeDiet;
                if (diet.Coach != customer.MyDiet.Coach)
                {
                    Coach coach = Data.Coaches.FirstOrDefault(c => c.Id == customer.MyDiet.Coach);
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
            Customer customer = Data.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Coach coach = Data.Coaches.FirstOrDefault(c => c.Id == customer.MyDiet.Coach);
                customer.Status = false;
                coach.MyCustomers.Remove(customer);
            }
        }
    }
}
