using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface IRoom:ICrudService<RoomModel>
  {
    Task<IEnumerable<RoomModel>> GetRoomsByLocation(int id);
    Task<IEnumerable<RoomModel>> GetRoomsByPartnerId(int id);
  }
}
