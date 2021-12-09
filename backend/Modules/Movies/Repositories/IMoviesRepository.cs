using way.Modules.Movies.Dtos;
using way.Modules.Movies.Entities;

namespace way.Modules.Movies.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> GetMovieByTitleAsync(string title);
        Task DeleteMovieAsync(Movie movie);
    }
}
