using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace APP.BL.Authentication
{
  public class CustomAuthProvider : AuthenticationStateProvider
  {
    private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      return Task.FromResult(new AuthenticationState(_user));
    }

    public Task MarkUserAsAuthenticated(string username)
    {
      var identity = new ClaimsIdentity(new[]
      {
                new Claim(ClaimTypes.Name, username)
            }, "Fake authentication");

      _user = new ClaimsPrincipal(identity);
      NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
      return Task.CompletedTask;
    }

    public Task MarkUserAsLoggedOut()
    {
      _user = new ClaimsPrincipal(new ClaimsIdentity());
      NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
      return Task.CompletedTask;
    }
  }
}
