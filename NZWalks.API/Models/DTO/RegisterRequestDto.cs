using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO;

public class RegisterRequestDto
{
    [Required]
    [EmailAddress]
    public required string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public string[] Roles { get; set; } = [];
}
