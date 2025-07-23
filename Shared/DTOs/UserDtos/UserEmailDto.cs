using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.UserDtos
{
  public class UserEmailDto
  {
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public required string Email { get; set; }
  }
}
