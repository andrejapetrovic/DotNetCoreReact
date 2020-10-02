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
            return await mc.Movies.ToListAsync();
        }

        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<Movie>> Search([FromQuery(Name = "q")] string query)
        {
            var list = await mc.Movies.Where(m => m.Title.ToLower().Contains(query)).ToListAsync();
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
            var mov = await mc.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
            mov.Title = movie.Title;
            await mc.SaveChangesAsync();
            return mov;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<Movie> Delete([FromQuery(Name = "id")] int id)
        {
            var mov = await mc.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
            mc.Movies.Remove(mov);
            await mc.SaveChangesAsync();
            return mov;
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<IEnumerable<Movie>> GetMoviesByUser(int id)
        {
            var movies = await mc.Movies
                .Where(mov => mov.MemberMovies
                .Any(mm => mm.MemberId == id))
                .ToArrayAsync();
            return movies;
        }

        [HttpGet]
        [Route("mem/{id}")]
        public async Task<Member> GetMember(int id)
        {
            return await mc.Members.Where(mem => mem.Id == id).FirstOrDefaultAsync();
        }
    }
}
