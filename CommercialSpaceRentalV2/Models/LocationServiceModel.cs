namespace CommercialSpaceRentalV2.Models
{
  public class LocationServiceModel : IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required int LocationId {  get; set; }
    public required int ServiceId {  get; set; }
    public required JsonContent ConfigSchema {  get; set; }

  }
}
