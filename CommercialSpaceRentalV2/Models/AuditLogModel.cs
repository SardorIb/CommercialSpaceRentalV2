using CommercialSpaceRentalV2.Constants.Enums;

namespace CommercialSpaceRentalV2.Models
{
  public class AuditLogModel
  {
    public  int? Id { get; set; }
    public required int UserId { get; set; }
    public required ActionType ActionType { get; set; }
    public required TargetType TargetType { get; set; }
    public required int TargetId { get; set; }
    public required String IpAddress { get; set; }
    public required String Description { get; set; }
    public required DateTime CreatedAt { get; set; }


  }
}
