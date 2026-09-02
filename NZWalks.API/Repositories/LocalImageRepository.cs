using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly NZWalksDbContext _dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment,NZWalksDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
        }
        public async Task<Image> UploadImageAsync(Image image)
        {
            var imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            Directory.CreateDirectory(imageFolder);

            var uniqueFileName = $"{Guid.NewGuid()}{image.FileExtension}";
            var localFilePath = Path.Combine(imageFolder, uniqueFileName);

            using var fileStream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(fileStream);

            image.FilePath = $"/Images/{uniqueFileName}";

            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();
            
            return image;
        }
    }
}
