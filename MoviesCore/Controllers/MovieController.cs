using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCore.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private DBFirstMoviesContext mc = new DBFirstMoviesContext();

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await mc.Movie.ToListAsync();
        }

        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<Movie>> Search([FromQuery(Name = "q")] string query)
        {
            var list = await mc.Movie.Where(m => m.Title.ToLower().Contains(query)).ToListAsync();
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

        [HttpPost]
        [Route("edit")]
        public async Task<Movie> Edit([FromBody] Movie movie)
        {
            var mov = await mc.Movie.FirstOrDefaultAsync(m => m.Id == movie.Id);
            mov.Title = movie.Title;
            await mc.SaveChangesAsync();
            return mov;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<Movie> Delete([FromQuery(Name = "id")] int id)
        {
            var mov = await mc.Movie.Where(m => m.Id == id).FirstOrDefaultAsync();
            mc.Movie.Remove(mov);
            await mc.SaveChangesAsync();
            return mov;
        }
    }
}
