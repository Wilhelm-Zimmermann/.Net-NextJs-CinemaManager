using way.Modules.Movies.Dtos;
using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;
using way.Utils;

namespace way.Modules.Movies.UseCases.UpdateMovie
{
    public class UpdateMovieService
    {
        private readonly StorageImage _storageImage;
        private readonly IMoviesRepository _repository;

        public UpdateMovieService(IMoviesRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _storageImage = new StorageImage(webHostEnvironment);
        }

        public async Task UpdateMovieAsync(int id, UpdateMovieDto movieDto, string formatedFileName)
        {
            var movieExists = await _repository.GetMovieByIdAsync(id);

            if(movieExists == null)
            {
                throw new Exception("Movie not found");
            }

            var movieTitleExists = await _repository.GetMovieByTitleAsync(movieDto.Title);

            if(movieTitleExists != null && movieTitleExists.Id != id)
            {
                throw new Exception("Movie title already exists");
            }

            if(formatedFileName != "")
            {
                _storageImage.RemoveImage(movieExists.Image);
            }

            movieExists.Title = movieDto.Title;
            movieExists.Description = movieDto.Description;
            movieExists.Duration = new TimeSpan(movieDto.Hours, movieDto.Minutes, movieDto.Seconds);
            movieExists.Image = formatedFileName == "" ? movieExists.Image : formatedFileName;

            await _repository.UpdateMovieAsync(movieExists);
        }
    }
}
