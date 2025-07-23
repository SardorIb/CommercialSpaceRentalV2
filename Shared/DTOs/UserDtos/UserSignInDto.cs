using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.UserDtos
{
  public class LoginDto
  {
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
  }

}
