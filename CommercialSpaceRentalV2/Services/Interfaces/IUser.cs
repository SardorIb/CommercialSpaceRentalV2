using CommercialSpaceRentalV2.DTOs.UserDtos;
using CommercialSpaceRentalV2.Models;

public interface IUser
{
  Task<IEnumerable<UserDefaultDto>> GetAllAsync();
  Task<UserDefaultDto> CreateAsync(UserSignUpDto user);
  Task<UserDefaultDto> UpdateAsync(UserModel updated);
  Task DeleteAsync(UserDefaultDto user);
  Task<UserDefaultDto?> ValidateUserCredentialsAsync(string email, string password);
  Task<UserDefaultDto> GetByEmailAsync(string email);


}
