namespace way.Modules.Movies.Dtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public IFormFile Image { get; set; }
    }
}
