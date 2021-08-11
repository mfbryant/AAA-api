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
    public class usersController : ControllerBase
    {
        // GET: api/users
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetUsers")]
        public List<User> Get()
        {
            IGetAllUsers readUsers = new ReadUsers();
            return readUsers.GetAllUsers();
        }

        // GET: api/users/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            IGetUser readUser = new ReadUsers();
            return readUser.GetUser(id);
        }

        // POST: api/users
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostUser")]
        public void Post([FromBody] User value)
        {
            IAddUser saveUser = new AddUsers();
            saveUser.AddUser(value);
        }

        // PUT: api/users/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/users/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
