using EasyDietCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private readonly IDataContext _context;

        public WeightController(IDataContext context)
        {
            _context = context;
        }

        // GET 
        [HttpGet("{id}")]
        public  List<Weight> Get(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id).MyWeigths;
        }

        // POST 
        [HttpPost]
        public void Post(int id, double weight)
        {

            Customer c = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (c != null)
                c.MyWeigths.Add(new Weight(DateTime.Now, weight));
        }
    }
}
