using EasyDietCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {

        private readonly IDataContext _context;

        public CoachController(IDataContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public List<Coach> Get()
        {
            return _context.Coaches;
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Coach c = _context.Coaches.Find(c => c.Id == id);
            if (c is null)
                return NotFound();
            return Ok();
        }

        // POST 
        [HttpPost("  After registration, add your diet course to the diet database")]
        public void Post(int id, string name, string city, string phone)
        {
            _context.Coaches.Add(new Coach(id, name, city, phone));
        }

        // PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, string Name, string city, string phone, bool status)
        {

            Coach coach = _context.Coaches.FirstOrDefault(c => c.Id.Equals(id));
            if (coach is null)
                return NotFound();
            coach.City = city;
            coach.Phone = phone;
            coach.Name = Name;
            coach.Status = status;
            return Ok();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Coach coach = _context.Coaches.Find(c => c.Id.Equals(id));
            if (coach is null)
                return NotFound();
            coach.Status = false;
            coach.MyDiets.ForEach(d => d.Status = false);
            return Ok();
        }




    }
}
