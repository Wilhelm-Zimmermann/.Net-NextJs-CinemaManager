namespace way.Utils
{
    public class StorageImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StorageImage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> SaveImage(IFormFile image, string formatedFileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", formatedFileName);
        
            using(var fs = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fs);
            }

            return formatedFileName;
        }

        public async Task RemoveImage(string formatedFileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", formatedFileName);

            File.Delete(filePath);
        }
    }
}