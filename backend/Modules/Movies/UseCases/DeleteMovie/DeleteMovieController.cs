using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.DeleteMovie
{
    [ApiController]
    [Route("movies")]
    public class DeleteMovieController : ControllerBase
    {
        private readonly DeleteMovieService _service;

        public DeleteMovieController(IMoviesRepository repository)
        {
            _service = new DeleteMovieService(repository);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                await _service.DeleteMovieAsync(id);
                return StatusCode(200);
            } catch(Exception ex)
            {
                return StatusCode(400, ex);
            }
        }
    }
}
