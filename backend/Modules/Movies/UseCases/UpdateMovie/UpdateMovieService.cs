using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.UpdateMovie
{
    public class UpdateMovieService
    {
        private readonly IMoviesRepository _repository;

        public UpdateMovieService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateMovieAsync(int id, Movie movie)
        {
            var movieExists = await _repository.GetMovieByIdAsync(id);

            if(movieExists == null)
            {
                throw new Exception("Movie not found");
            }

            var movieTitleExists = await _repository.GetMovieByTitleAsync(movie.Title);

            if(movieExists != null && movieTitleExists.Id != movie.Id)
            {
                throw new Exception("Movie title already exists");
            }

            await _repository.UpdateMovieAsync(id, movie);
        }
    }
}
