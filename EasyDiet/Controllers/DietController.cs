using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        //GET
        [HttpGet]
        public IEnumerable<Diet> Get()
        {
            return Data.Diets;
        }

        //GET BY PRICE
        [HttpGet("{price}")]
        public IEnumerable<Diet> Get([FromQuery] int price)
        {
            return Data.Diets.FindAll(d => d.Price <= price);
        }

        //GET BY ID
        //[HttpGet("{code}")]
        //public IEnumerable<Diet> Get_by_code([FromQuery] int code)
        //{
        //    return Diets.FindAll(diet => diet.Code <= code);
        //}

        // POST 
        [HttpPost]
        public void Post(string name, double price, int idcoach)
        {
            Coach coach = Data.Coaches.FirstOrDefault(c => c.Id == idcoach);
            if (coach != null && coach.Status)
            {
                Diet diet = new Diet(name, price, idcoach);
                coach.MyDiets.Add(diet);
                Data.Diets.Add(diet);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name, double price)
        {
            Diet diet = Data.Diets.FirstOrDefault(d => d.Equals(id));
            if (diet != null && diet.Status)
            {
                diet.Name = name;
                diet.Price = price;
            }
        }

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Data.Diets.Find(d => d.Equals(id)).Status = false;
        }
    }
}
