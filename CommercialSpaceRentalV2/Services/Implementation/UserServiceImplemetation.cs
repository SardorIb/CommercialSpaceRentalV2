using CommercialSpaceRentalV2.Constants.Methods;
using CommercialSpaceRentalV2.DTOs.UserDtos;
using CommercialSpaceRentalV2.Exceptions;
using CommercialSpaceRentalV2.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace CommercialSpaceRentalV2.Services.Implementation
{
  public class UserServiceImplemetation : IUser
  {

    private readonly UserRepository _userRepository;
    private readonly PasswordHasher<UserModel> _passwordHasher = new();


    public UserServiceImplemetation(UserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public Task DeleteAsync(UserDefaultDto user)
    {
      _userRepository.DeleteUser(user);
      return Task.CompletedTask;
    }

    Task<UserDefaultDto> IUser.CreateAsync(UserSignUpDto user)
    {
      UserModel userModel = UserMapper.ToUserModel(user);
      userModel.PasswordHash = _passwordHasher.HashPassword(userModel, user.Password);
      return Task.FromResult(_userRepository.SignUp(userModel));
    }


    Task<IEnumerable<UserDefaultDto>> IUser.GetAllAsync()
    {
      return Task.FromResult(UserMapper.ToDto(_userRepository.GetActiveUsers()));
    }

    Task<UserDefaultDto> IUser.GetByEmailAsync(string email)
    {
      if (EmailValidator.IsValid(email) == false) {
        throw new InvalidEmailFormatException();
      }
      return Task.FromResult(UserMapper.ToDto(_userRepository.GetUserByEmail(email)));
    }


    Task<UserDefaultDto> IUser.UpdateAsync(UserModel updated)
    {
      updated.PasswordHash = _passwordHasher.HashPassword(updated, updated.PasswordHash);
      return Task.FromResult(_userRepository.UpdateUser(updated));
    }

    Task<UserDefaultDto?> IUser.ValidateUserCredentialsAsync(string email, string password)
    {
      if (EmailValidator.IsValid(email) == false)
      {
        throw new InvalidEmailFormatException();
      }
      UserModel userModel = _userRepository.GetUserByEmail(email);
      var verficationResults = _passwordHasher.VerifyHashedPassword(userModel, userModel.PasswordHash, password);
      if (verficationResults == PasswordVerificationResult.Success) {
        return Task.FromResult<UserDefaultDto?>(UserMapper.ToDto(userModel));
      }
      throw new InvalidCredentialsException();
    }
  }
}
