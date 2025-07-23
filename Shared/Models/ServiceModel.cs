using System.Net.Http.Json;

namespace Shared.Models
{
  public class ServiceModel : IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool IsAvailable { get; set; }
    public required JsonContent ConfigScheme {  get; set; }

  }
}
