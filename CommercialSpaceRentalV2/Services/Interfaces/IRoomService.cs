using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface IRoomService:ICrudService<RoomServiceModel>
  {
    Task<IEnumerable<RoomServiceModel>> GetByRoomIdAsync(int id);

  }
}
