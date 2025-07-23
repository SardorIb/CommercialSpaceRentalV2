using CommercialSpaceRentalV2.Constants.Enums;

namespace CommercialSpaceRentalV2.Models
{
  public class UserModel : IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public UserType Type { get; set; }
    public required string Name { get; set; }
    public required string Email {  get; set; }
    public required string PasswordHash { get; set; }
    public required string Phone {  get; set; }
    public required UserRole Role { get; set; }
    public required bool IsVerified {  get; set; }
    public required UserStatus Status { get; set; }
  }
}
