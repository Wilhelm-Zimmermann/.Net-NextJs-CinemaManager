using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Dtos;
using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.UpdateMovie
{
    [ApiController]
    [Route("movies")]
    public class UpdateMovieController : ControllerBase
    {
        private readonly UpdateMovieService _service;

        public UpdateMovieController(IMoviesRepository repository)
        {
            _service = new UpdateMovieService(repository);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> UpdateMovieAsync(int id,[FromForm] UpdateMovieDto movieDto)
        {
            Movie movie = new()
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Duration = new TimeSpan(movieDto.Hours, movieDto.Minutes, movieDto.Seconds),
                Image = movieDto.Image.FileName
            };

            try
            {
                await _service.UpdateMovieAsync(id, movie);
                return StatusCode(200);
            }catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
