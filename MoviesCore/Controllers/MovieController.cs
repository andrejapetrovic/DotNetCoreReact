using Microsoft.AspNetCore.Mvc;
using MoviesCore.Models;
using System;
using System.Collections.Generic;

namespace MoviesCore.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private DBFirstMoviesContext mc = new DBFirstMoviesContext();

        [HttpGet]
        [Route("all")]
        public IEnumerable<Movie> GetAll()
        {
            return mc.Movie;
        }
    }
}
