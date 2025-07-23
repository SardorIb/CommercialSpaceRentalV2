using CommercialSpaceRentalV2.Constants.Enums;

namespace CommercialSpaceRentalV2.Models
{
  public class RoomModel : IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required int LocationId { get; set; }
    public required int PartnerId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required double DimentionWidth { get; set; }
    public required double DimentionLength { get; set; }
    public required RoomStatus Status { get; set; } = RoomStatus.Draft;
    public required int RoomOccupacy { get; set; }
    public required string Images {  get; set; }
    public required string Documents {  get; set; }


  }
}
