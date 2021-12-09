using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Dtos;
using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;
using way.Utils;

namespace way.Modules.Movies.UseCases.UpdateMovie
{
    [ApiController]
    [Route("movies")]
    public class UpdateMovieController : ControllerBase
    {
        private readonly UpdateMovieService _service;
        private readonly StorageImage _storageImage;

        public UpdateMovieController(IMoviesRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _service = new UpdateMovieService(repository, webHostEnvironment);
            _storageImage = new StorageImage(webHostEnvironment);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> UpdateMovieAsync(int id,[FromForm] UpdateMovieDto movieDto)
        {
            try
            {
                if (movieDto.Image.ContentType != "image/jpg" && movieDto.Image.ContentType != "image/png")
                {
                    return StatusCode(400, "This type of file is not allowed");
                }
                var formatedFileName = movieDto.Image is null ? "" : $"{DateTime.Now.Millisecond.ToString()}_{movieDto.Image.FileName}";
                await _service.UpdateMovieAsync(id, movieDto, formatedFileName);
                if(movieDto.Image != null) await _storageImage.SaveImage(movieDto.Image, formatedFileName);
                
                return StatusCode(200);
            }catch (Exception ex)
            {
                return StatusCode(400, ex.StackTrace);
            }
        }
    }
}
