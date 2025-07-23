using CommercialSpaceRentalV2.Constants.Enums;

namespace CommercialSpaceRentalV2.DTOs.UserDtos
{
  public class UserDefaultDto
  {
    public int Id { get; set; }=0;
    public UserType Type { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public UserRole Role { get; set; } = UserRole.Customer;
    public UserStatus Status { get; set; } = UserStatus.Pending;
  }
}
