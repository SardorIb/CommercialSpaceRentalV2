using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{  public interface IBookingService:ICrudService<BookingServiceModel>
  {
    Task <IEnumerable<BookingServiceModel>> GetBookingServicesByBookingId (int id);
  }
}
