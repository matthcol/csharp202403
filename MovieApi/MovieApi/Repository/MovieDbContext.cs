using Microsoft.EntityFrameworkCore;
using MovieApi.Model;

namespace MovieApi.Repository
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
