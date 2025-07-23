using CommercialSpaceRentalV2.Constants.Enums;

namespace CommercialSpaceRentalV2.Models
{
  public class BookingModel : IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required int UserId { get; set; }
    public required int RoomId { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required BookingStatus Status { get; set; }
    public required BookingPaymentStatus PaymentStatus { get; set; }

  }
}
