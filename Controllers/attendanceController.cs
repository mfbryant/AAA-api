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
    public class attendanceController : ControllerBase
    {
        // GET: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetAttendances")]
        public List<Attendance> Get()
        {
            IGetAllAttendance readAttendances = new ReadAttendance();
            return readAttendances.GetAllAttendance();
        }

        // GET: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetAttendance")]
        public Attendance Get(int id)
        {
            IGetAttendance readAttendance = new ReadAttendance();
            return readAttendance.GetAttendance(id);
        }

        // POST: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostAttendance")]
        public void Post([FromBody] Attendance value)
        {
            IAddAttendance saveAttendance = new AddAttendances();
            saveAttendance.AddAttendance(value);
        }

        // PUT: api/attendance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/attendance/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
