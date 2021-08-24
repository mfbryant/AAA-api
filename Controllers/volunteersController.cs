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
    public class volunteersController : ControllerBase
    {
        // GET: api/volunteers
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetVolunteerse")]
        public List<Volunteer> Get()
        {
            IGetAllVolunteers readVols = new ReadVolunteers();
            return readVols.GetAllVolunteers();
        }

        // GET: api/volunteers/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetVolunteer")]
        public Volunteer Get(int id)
        {
            IGetVolunteer readVols = new ReadVolunteers();
            return readVols.GetVolunteer(id);
        }

        // POST: api/volunteers
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostVolunteer")]
        public void Post([FromBody] Volunteer value)
        {
            IAddVolunteer saveVol = new AddVolunteers();
            saveVol.AddVolunteer(value);
        }

        // PUT: api/volunteers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/volunteers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
