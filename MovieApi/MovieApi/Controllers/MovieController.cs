using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Model;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _dbContext;

        public MovieController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Movie> AllMovies()
        {
            // TODO: base filter (top 100, current year, pageable...)
            return _dbContext.Movies.ToList();
        }

        [HttpGet("{id:int}")]
        public Movie GetMovieById([FromRoute] int id)
        {
            return _dbContext.Movies
                .Find(id);
        }

        [HttpGet("best")]
        public Movie BestMovie()
        {
            // return "Inception";
            return new()
            {
                Id = 1375666,
                Title = "Inception",
                Year = 2010
            };
        }

        [HttpPost]
        public Movie AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }
    }
}
