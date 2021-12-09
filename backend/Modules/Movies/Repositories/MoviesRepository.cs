using way.Database;
using way.Modules.Movies.Entities;
using Microsoft.EntityFrameworkCore;
using way.Modules.Movies.Dtos;

namespace way.Modules.Movies.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DatabaseContext _context;

        public MoviesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie); 
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            return await _context.Movies.Where(x => x.Title.ToUpper() == title.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            _context.Movies.Attach(movie);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
