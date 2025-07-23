using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface IBooking:ICrudService<BookingModel>
  {
    Task<IEnumerable<BookingModel>> GetBookingByRoomId(int id);
    Task<IEnumerable<BookingModel>> GetBookingByCustomerId(int id);
  }
}
