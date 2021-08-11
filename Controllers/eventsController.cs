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
        [HttpGet("{id}", Name = "GetEvent")]
        public Event Get(int id)
        {
            IGetEvent readEvent = new ReadEvents();
            return readEvent.GetEvent(id);
        }

        // POST: api/events
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostEvent")]
        public void Post([FromBody] Event value)
        {
            IAddEvent saveEvent = new AddEvents();
            saveEvent.AddEvent(value);
        }

        // PUT: api/events/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}", Name = "PutEvent")]
        public void Put(int id, [FromBody] Event value)
        {
            IEditEvent editEvent = new EditEvents();
            editEvent.EditEvent(value);
        }

        // DELETE: api/events/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}", Name = "DeleteEvent")]
        public void Delete(int id)
        {
            IDeleteEvent deleteEvent = new DeleteEvents();
            deleteEvent.DeleteEvent(id);
        }
    }
}
