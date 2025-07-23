using Shared.Enums;
using Shared.DTOs.UserDtos;

namespace APP.Components.Pages
{
  public partial class Users
  {


    List<UserDefaultDto> users = new()
        {
            new() { Id = 29, Type = UserType.Individual, Name = "string", Email = "uasdasdasser@example.com", Phone = "+82144948", CreatedAt = DateTime.Parse("2025-07-14T17:13:19.2773193"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 28, Type = UserType.Individual, Name = "string", Email = "ushjhgjghjhgjgher@example.com", Phone = "+8484984", CreatedAt = DateTime.Parse("2025-07-14T16:36:41.0333266"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 27, Type = UserType.Individual, Name = "string", Email = "useasdasr@example.com", Phone = "+82", CreatedAt = DateTime.Parse("2025-07-14T16:13:37.9332825"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 26, Type = UserType.Individual, Name = "string", Email = "usesdfsdr@example.com", Phone = "+821059310489", CreatedAt = DateTime.Parse("2025-07-14T15:21:29.223048"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 25, Type = UserType.Individual, Name = "string", Email = "usesfasfdsfdsr@example.com", Phone = "+82", CreatedAt = DateTime.Parse("2025-07-14T15:13:48.5981446"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 24, Type = UserType.Individual, Name = "string", Email = "usadsader@example.com", Phone = "+8210591", CreatedAt = DateTime.Parse("2025-07-14T15:07:54.8810809"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 23, Type = UserType.Individual, Name = "string", Email = "usadsadaser@example.com", Phone = "+2848489735", CreatedAt = DateTime.Parse("2025-07-14T15:06:25.5182195"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 22, Type = UserType.Individual, Name = "string", Email = "usergfdgfd@example.com", Phone = "+821059310321", CreatedAt = DateTime.Parse("2025-07-14T15:02:21.3753309"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 21, Type = UserType.Individual, Name = "string", Email = "useewrwerwewer@example.com", Phone = "+821059310231", CreatedAt = DateTime.Parse("2025-07-14T14:59:00.2951791"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 20, Type = UserType.Individual, Name = "string", Email = "usesadasdasdr@example.com", Phone = "+8210593154564", CreatedAt = DateTime.Parse("2025-07-14T14:55:00.0235063"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 19, Type = UserType.Individual, Name = "string", Email = "user@example.com", Phone = "+821059449", CreatedAt = DateTime.Parse("2025-07-14T14:46:26.8635762"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 18, Type = UserType.Individual, Name = "string", Email = "user@example.com", Phone = "+821059449", CreatedAt = DateTime.Parse("2025-07-14T14:46:06.8661387"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 17, Type = UserType.Individual, Name = "string", Email = "use12312r@example.com", Phone = "+821059310231", CreatedAt = DateTime.Parse("2025-07-14T14:41:46.3831149"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 16, Type = UserType.Individual, Name = "string", Email = "user12345@example.com", Phone = "+8215554447884213", CreatedAt = DateTime.Parse("2025-07-14T14:37:44.2299325"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 15, Type = UserType.Individual, Name = "string", Email = "use345r@example.com", Phone = "+821059310231", CreatedAt = DateTime.Parse("2025-07-14T14:35:29.017483"), Role = UserRole.Admin, Status = UserStatus.Active },
            new() { Id = 14, Type = UserType.Individual, Name = "string", Email = "user@example.com", Phone = "+01059310231", CreatedAt = DateTime.Parse("2025-07-11T11:27:27.4729439"), Role = UserRole.Admin, Status = UserStatus.Active }
        };

    private IEnumerable<UserDefaultDto> pagedItems = new List<UserDefaultDto>();
    private int currentPage = 1;
    private int rowsPerPage = 10;
    private int totalPages = 1;

    protected override void OnInitialized()
    {
      UpdatePagedItems();
    }

    private void PageChanged(int newPage)
    {
      currentPage = newPage;
      UpdatePagedItems();
    }

    private void UpdatePagedItems()
    {
      totalPages = (int)Math.Ceiling((double)users.Count / rowsPerPage);
      pagedItems = users
          .Skip((currentPage - 1) * rowsPerPage)
          .Take(rowsPerPage);
    }

  

 
  }
}
