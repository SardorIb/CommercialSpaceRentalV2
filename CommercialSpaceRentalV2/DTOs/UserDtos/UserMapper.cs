using CommercialSpaceRentalV2.Constants.Enums;
using CommercialSpaceRentalV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace CommercialSpaceRentalV2.DTOs.UserDtos
{
  public class UserMapper
  {
    public static UserDefaultDto ToDto(UserModel user)
    {
      return new UserDefaultDto
      {
        Id = user.Id,
        Type = user.Type,
        Name = user.Name,
        Email = user.Email,
        Phone = user.Phone,
        CreatedAt = user.CreatedAt,
        Role = user.Role,
        Status = user.Status
      };
    }


    public static IEnumerable<UserDefaultDto> ToDto(IEnumerable<UserModel> users)
    {
      return users.Select(ToDto);
    }

    public static UserModel ToUserModel(UserSignUpDto user){
      return new UserModel{
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        Type = user.Type,
        Name = user.Name,
        Email = user.Email,
        Phone = user.Phone,
        PasswordHash = user.Password,
        Role = user.Role,
        IsVerified = false,
        Status = UserStatus.Active
      }
      ;
}
  }

}
