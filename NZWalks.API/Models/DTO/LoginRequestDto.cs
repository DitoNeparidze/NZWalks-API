using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO;

public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public required string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

}
