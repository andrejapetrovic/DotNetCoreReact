using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MoviesCore.DAL;
using System.Threading.Tasks;

namespace MoviesCore.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private readonly MyContext mc;

        public MovieController(MyContext myCtx)
        {
            mc = myCtx;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return mc.Movie;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<Movie>> Search([FromQuery(Name = "q")] string query)
        {
            var list = mc.Movie.Where(m => m.Title.ToLower().Contains(query));
            return list;
        }

        [HttpPost]
        [Route("add")]
        public async Task<Movie> Add([FromBody] Movie movie)
        {
            var mov = mc.Add(movie);
            await mc.SaveChangesAsync();
            return mov.Entity;
        }

    }
}
