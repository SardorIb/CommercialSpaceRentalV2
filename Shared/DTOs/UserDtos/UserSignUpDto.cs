using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shared.Enums;

namespace Shared.DTOs.UserDtos
{
  public class UserSignUpDto
  {
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [Phone]
    [MaxLength(20)]
    public string Phone { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string Password { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserType Type { get; set; } = UserType.Individual;

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRole Role { get; set; } = UserRole.Customer;
  }
}
