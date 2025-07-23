// File: Services/ClientInfoService.cs
using Microsoft.AspNetCore.Http;

public class ClientInfoService
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public ClientInfoService(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public string GetClientIp()
  {
    var context = _httpContextAccessor.HttpContext;

    var forwarded = context?.Request?.Headers["X-Forwarded-For"].FirstOrDefault();
    return !string.IsNullOrWhiteSpace(forwarded)
        ? forwarded
        : context?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";
  }
}
