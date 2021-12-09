using way.Modules.Movies.Dtos;
using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.CreateMovie
{
    public class CreateMovieService
    {
        private readonly IMoviesRepository _repository;

        public CreateMovieService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateMovieAsync(CreateMovieDto movieDto, string formatedFileName)
        {
            var movieTitleExists = await _repository.GetMovieByTitleAsync(movieDto.Title);

            if (movieTitleExists != null)
            {
                throw new Exception("Movie title already exists");
            }

            Movie movie = new()
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Duration = new TimeSpan(movieDto.Hours, movieDto.Minutes, movieDto.Seconds),
                Image = formatedFileName,
            };

            var image = movieDto.Image;

            await _repository.CreateMovieAsync(movie);
        }
    }
}
