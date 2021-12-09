using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.GetMovies
{
    [ApiController]
    [Route("movies")]
    public class GetMoviesController : ControllerBase
    {
        private readonly IMoviesRepository _repository;

        public GetMoviesController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        // [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = await _repository.GetMoviesAsync();

            return movies;
        }
    }
}
