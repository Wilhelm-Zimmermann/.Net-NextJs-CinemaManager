using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.GetOneMovie
{
    [ApiController]
    [Route("movies")]
    public class GetOneMovieController : ControllerBase
    {
        
        private readonly GetOneMovieService _service;
        public GetOneMovieController(IMoviesRepository repository)
        {
            _service = new GetOneMovieService(repository);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _service.GetMovieAsync(id);
        }
    }
}
