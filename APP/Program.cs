using APP.BL.Authentication;
using APP.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// 🔐 Auth: For Blazor server authentication
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); // ✅ Required for auth & routing
app.UseAntiforgery();

// Map the main component (e.g., App.razor)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
