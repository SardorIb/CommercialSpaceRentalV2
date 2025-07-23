using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface IAuditLog:ICrudService<AuditLogModel>
  {
    Task<IEnumerable<AuditLogModel>> GetAuditLogByRoomId(int id);
    Task<IEnumerable<AuditLogModel>> GetAuditLogByUserId(int id);
    Task<IEnumerable<AuditLogModel>> GetAuditLogByLocationId(int id);
  }
}
