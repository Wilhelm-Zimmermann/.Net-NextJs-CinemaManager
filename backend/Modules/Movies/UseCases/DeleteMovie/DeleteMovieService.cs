using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.DeleteMovie
{
    public class DeleteMovieService
    {
        private readonly IMoviesRepository _repository;

        public DeleteMovieService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _repository.GetMovieByIdAsync(id);

            if(movie == null)
            {
                throw new Exception("Movie does not exists");
            }

            await _repository.DeleteMovieAsync(movie);
        }
    }
}
