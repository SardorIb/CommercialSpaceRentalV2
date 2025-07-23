using Shared.Enums;

namespace Shared.Models
{
  public class LocationModel : IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required int PartnerId { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Description { get; set; }
    public required string Documents { get; set; }
    public required LocationStatus Status {get; set; }
    public required string Images { get; set; }



  }
}
