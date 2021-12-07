using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.GetOneMovie
{
    public class GetOneMovieService
    {
        private readonly IMoviesRepository _repository;

        public GetOneMovieService(IMoviesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Movie> GetMovieAsync(int id)
        {
            var movie = await _repository.GetMovieByIdAsync(id);

            return movie;
        }
    }
}
