using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO;

public class UpdateRegionRequestDto
{
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    public string? RegionImageUrl { get; set; }
}
