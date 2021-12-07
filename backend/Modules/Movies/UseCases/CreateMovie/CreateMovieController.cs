using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Dtos;
using way.Modules.Movies.Repositories;

namespace way.Modules.Movies.UseCases.CreateMovie
{
    [ApiController]
    [Route("movies")]
    public class CreateMovieController : ControllerBase
    {
        private readonly CreateMovieService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateMovieController(IMoviesRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _service = new CreateMovieService(repository);
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateMovieAsync([FromForm] CreateMovieDto movieDto)
        {
            try
            {
                await _service.CreateMovieAsync(movieDto);
                await SaveImage(movieDto.Image);

                return StatusCode(201);
            }catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile image)
        {
            var formatedFileName = $"{DateTime.Now.Millisecond.ToString()}_{image.FileName}";
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", formatedFileName);
        
            using(var fs = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fs);
            }

            return formatedFileName;
        }
    }
}
