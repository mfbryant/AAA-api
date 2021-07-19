using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.models;
using api.models.interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eventsController : ControllerBase
    {
        // GET: api/events
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetEvents")]
        public List<Event> Get()
        {
            IGetAllEvents readEvents = new ReadEvents();
            return readEvents.GetAllEvents();
        }

        // GET: api/events/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Event Get(int id)
        {
            IGetEvent readEvent = new ReadEvents();
            return readEvent.GetEvent(id);
        }

        // POST: api/events
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/events/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
