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
    public class favoritesController : ControllerBase
    {
        // GET: api/favorites
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetFavorites")]
        public List<Favorite> Get()
        {
            IGetAllFavorites readFavs = new ReadFavorites();
            return readFavs.GetAllFavorites();
        }

        // GET: api/favorites/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetFavorite")]
        public Favorite Get(int id)
        {
            IGetFavorite readFavs = new ReadFavorites();
            return readFavs.GetFavorite(id);
        }

        // POST: api/favorites
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostFavorite")]
        public void Post([FromBody] Favorite value)
        {
            IAddFavorite saveFav = new AddFavorites();
            saveFav.AddFavorite(value);
        }

        // PUT: api/favorites/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}", Name = "PutFavorite")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/favorites/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}", Name = "DeleteFavorite")]
        public void Delete(int id)
        {
            IDeleteFavorite deleteFavorite = new DeleteFavorites();
            deleteFavorite.DeleteFavorite(id);
        }
    }
}
