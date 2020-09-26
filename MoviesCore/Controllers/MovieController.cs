using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<Movie> GetAll()
        {
            return mc.Movie;
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Movie> Search([FromQuery(Name = "q")] string query)
        {
            var list = mc.Movie.Where(m => m.Title.ToLower().Contains(query));
            return list;
        }
    }
}
