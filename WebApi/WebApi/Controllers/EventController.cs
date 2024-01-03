using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        //private static List<Event> events = new List<Event> { new Event { Id = 1, Title = "start" ,Start=DateTime.Now} };
        private readonly DataContext _contex;
        public EventController(DataContext contex)
        {
            _contex = contex;
        }

        private static int countID=1;
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _contex.Events;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eve = _contex.Events.ToList().Find(e => e.Id == id);
            if (eve is null)
            {
                return NotFound();
            }
            return Ok(eve);
        }


        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event newevent)
        {
            _contex.Events.Add(new Event {  Id = ++countID, Title = newevent.Title ,Start=newevent.Start});
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event enentPut)
        {
            Event eventToUpdate = _contex.Events.Where(e => e.Id == id).FirstOrDefault();

            if (eventToUpdate != null)
            {
                eventToUpdate.Title = enentPut.Title;
                eventToUpdate.Start = enentPut.Start;
            }
            else
                _contex.Events.Add(new Event { Id = ++countID, Title = enentPut.Title, Start = enentPut.Start });


        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event eventToDelete = _contex.Events.Where(e=>e.Id==id).FirstOrDefault();
            _contex.Events.Remove(eventToDelete);
        }
    }
}
