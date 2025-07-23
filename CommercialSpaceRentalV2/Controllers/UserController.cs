using CommercialSpaceRentalV2.DTOs.UserDtos;
using CommercialSpaceRentalV2.Models;
using CommercialSpaceRentalV2.Models.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;



[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUser _userService;

  public UsersController(IUser userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var users = await _userService.GetAllAsync();
    var response = ApiResponse<IEnumerable<UserDefaultDto>>.SuccessResponse(users, "Users retrieved successfully.");
    return Ok(response);
  }


  [HttpPost("sign-up")]
  public async Task<IActionResult> Create([FromBody] UserSignUpDto user)
  {
    if (!ModelState.IsValid)
    {
      var errors = ModelState.Values
          .SelectMany(v => v.Errors)
          .Select(e => e.ErrorMessage)
          .ToList();

      var message = string.Join("; ", errors);
      throw new ValidationException(message);
    }

    var result = await _userService.CreateAsync(user);
    return Ok(ApiResponse<UserDefaultDto>.SuccessResponse(result, "User created successfully."));
  }



  [HttpPost("get-by-email")]
  public async Task<IActionResult> GetByEmail([FromBody] UserEmailDto user) {
    var result = await _userService.GetByEmailAsync(user.Email);

    return Ok(ApiResponse<UserDefaultDto>.SuccessResponse(result, "User Found"));
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
  {

    if (!ModelState.IsValid)
{
    var errors = ModelState
        .Where(e => e.Value.Errors.Any())
        .ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
        );

    return BadRequest(ApiResponse<Dictionary<string, string[]>>.Failure(
        "Validation error", 400, errors));
}

    var result = await _userService.ValidateUserCredentialsAsync(loginDto.Email, loginDto.Password);
    return Ok(ApiResponse<UserDefaultDto?>.SuccessResponse(result, "Usser Loggedn"));
  }

  [HttpPost("update")]
  public async Task<IActionResult> UpdateUserInformation([FromBody] UserModel user)
  {
    var result  = await _userService.UpdateAsync(user);
    return Ok(ApiResponse<UserDefaultDto>.SuccessResponse(result, "User Updated"));

  }

  [HttpPost("delete")]
  public async Task<IActionResult> DeleteUser([FromBody] UserDefaultDto user) {
    await _userService.DeleteAsync(user);
    return Ok(ApiResponse<bool>.SuccessResponse(true, "User Deleted"));
  }

}


