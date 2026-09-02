using System.ComponentModel.DataAnnotations;
namespace NZWalks.API.Models.DTO;


public class UpdateWalkRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    [Required]
    public Guid DifficultyId { get; set; }
    [Required]
    public Guid RegionId { get; set; }
}
