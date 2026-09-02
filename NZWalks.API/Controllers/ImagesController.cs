using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using NZWalks.API.Models.Domain;
using AutoMapper;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;
    private readonly IMapper _mapper;

    public ImagesController(IImageRepository imageRepository, IMapper mapper)
    {
        _imageRepository = imageRepository;
        _mapper = mapper;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
    {
        ValidateFileUpload(request);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var imageDomainModel = new Image
        {
            File = request.File,
            FileName = request.FileName,
            FileDescription = request.FileDescription,
            FileExtension = Path.GetExtension(request.File.FileName).ToLower(),
            FileSizeInBytes = request.File.Length,
            FilePath = string.Empty
        };

        await _imageRepository.UploadImageAsync(imageDomainModel);

        var requestInfo = HttpContext.Request;
        var baseUrl = $"{requestInfo.Scheme}://{requestInfo.Host}{requestInfo.PathBase}";

        var response = _mapper.Map<ImageDto>(imageDomainModel);
        response.FilePath = $"{baseUrl}{imageDomainModel.FilePath}";

        return Ok(response);
    }

    private void ValidateFileUpload(ImageUploadRequestDto request)
    {
        if (request.File == null || request.File.Length == 0)
        {
            ModelState.AddModelError("File", "File is required.");
            return;
        }

        var allowedExtension = new string[] { ".jpg", ".png", ".jpeg" };
        var extension = Path.GetExtension(request.File.FileName).ToLower();

        if (!allowedExtension.Contains(extension))
            ModelState.AddModelError("File", "Only .jpg, .png, .jpeg files are allowed.");
        if (request.File.Length > 10 * 1024 * 1024)
            ModelState.AddModelError("File", "File size should not exceed 10 MB.");
    }

}
