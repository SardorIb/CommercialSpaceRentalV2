using System.ComponentModel.DataAnnotations;

namespace CommercialSpaceRentalV2.DTOs.UserDtos
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
