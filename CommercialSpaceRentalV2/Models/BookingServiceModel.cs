namespace CommercialSpaceRentalV2.Models
{
  public class BookingServiceModel
  {
    public required int BookingId {  get; set; }
    public required int ServiceId { get; set; }
    public required JsonContent ConfigSchema { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }

  }
}
