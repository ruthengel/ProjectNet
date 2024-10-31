using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable<Coach> Get()
        {
            return Data.Coaches;
        }

        // GET BY ID
        [HttpGet("{id}")]
        public Coach Get(int id)
        {
            Coach c = Data.Coaches.FirstOrDefault(c => c.Id == id);
            return c;
        }

        // POST 
        [HttpPost("  After registration, add your diet course to the diet database")]
        public void Post(int id, string name, string city, string phone)
        {
            Data.Coaches.Add(new Coach(id, name, city, phone));
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, string Name, string city, string phone,bool status)
        {
            Coach couch = Data.Coaches.FirstOrDefault(c => c.Id.Equals(id));
            couch.City = city;
            couch.Phone = phone;
            couch.Name = Name;
            couch.Status = status;
        }

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Data.Coaches.FirstOrDefault(c => c.Id.Equals(id)).Status = false;
            Data.Coaches.FirstOrDefault(c => c.Id.Equals(id)).MyDiets.ForEach(d => d.Status = false);
        }
    }
}
