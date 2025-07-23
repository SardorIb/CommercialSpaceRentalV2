using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface IAccountingSyncLog:ICrudService<AccountingSyncLogModel>
  {
    Task<IEnumerable<AccountingSyncLogModel>> GetAccountingSyncLogByRoomId(int id);
    Task<IEnumerable<AccountingSyncLogModel>> GetAccountingSyncLogByUserId(int id);
    Task<IEnumerable<AccountingSyncLogModel>> GetAccountingSyncLogByLocationId(int id);
  }
}
