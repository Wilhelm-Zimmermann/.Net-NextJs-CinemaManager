using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Dtos;
using way.Modules.Movies.Repositories;
using way.Utils;

namespace way.Modules.Movies.UseCases.CreateMovie
{
    [ApiController]
    [Route("movies")]
    public class CreateMovieController : ControllerBase
    {
        private readonly CreateMovieService _service;
        private readonly StorageImage _storageImage;

        public CreateMovieController(IMoviesRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _service = new CreateMovieService(repository);
            _storageImage = new StorageImage(webHostEnvironment);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateMovieAsync([FromForm] CreateMovieDto movieDto)
        {
            try
            {
                var formatedFileName = $"{DateTime.Now.Millisecond.ToString()}_{movieDto.Image.FileName}";
                await _service.CreateMovieAsync(movieDto, formatedFileName);
                await _storageImage.SaveImage(movieDto.Image,formatedFileName);

                return StatusCode(201);
            }catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
