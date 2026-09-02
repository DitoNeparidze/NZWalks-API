using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO;

public class AddWalkRequestDto
{
    [Required]
    [StringLength(50, MinimumLength =1, ErrorMessage ="Name should be between 1 and 50 characters long")]
    public string Name { get; set; } = String.Empty;
    [Required]
    [StringLength(1000, MinimumLength =1)]
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(0.1, 100)]
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    [Required]
    public Guid DifficultyId { get; set; }
    [Required]
    public Guid RegionId { get; set; }
}
