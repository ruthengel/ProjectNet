using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        // GET 
        [HttpGet("{id}")]
        public IEnumerable<Weight> Get(int id)
        {
            return Data.Customers.FirstOrDefault(c => c.Id == id).MyWeigths;
        }

        // POST 
        [HttpPost]
        public void Post(int id, double weight)
        {
            Data.Customers.FirstOrDefault(c => c.Id == id).MyWeigths.Add(new Weight(DateTime.Now, weight));
        }
    }
}
