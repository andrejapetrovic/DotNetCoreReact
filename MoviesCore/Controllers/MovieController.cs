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
        public IEnumerable<Movie> GetAll()
        {
            return mc.Movies;
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Movie> Search([FromQuery(Name = "q")] string query)
        {
            var list = mc.Movies.Where(m => m.Title.ToLower().Contains(query));
            return list;
        }

        [HttpPost]
        [Route("add")]
        public Movie Add([FromBody] Movie movie)
        {
            var mov = mc.Add(movie);
            mc.SaveChanges();
            return mov.Entity;
        }

		[HttpPut]
		[Route("edit/{id}")]
		public int Edit([FromBody] Movie movie)
		{
			try
			{
				mc.Entry(movie).State = EntityState.Modified;
				mc.SaveChanges();
				return 1;
			}
			catch
			{
				throw;
			}
		}

    }
}
