using System.ComponentModel.DataAnnotations;

namespace CommercialSpaceRentalV2.DTOs.UserDtos
{
  public class UserEmailDto
  {
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public required string Email { get; set; }
  }
}
