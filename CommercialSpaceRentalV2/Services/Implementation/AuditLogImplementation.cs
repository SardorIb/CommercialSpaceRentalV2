using CommercialSpaceRentalV2.Models;
using CommercialSpaceRentalV2.Repositories;
using CommercialSpaceRentalV2.Services.Interfaces;

namespace CommercialSpaceRentalV2.Services.Implementation
{
  public class AuditLogImplementation : IAuditLog
  {
    private readonly AuditLogRepository _logger;

    public AuditLogImplementation(AuditLogRepository logger)
    {
      _logger = logger;
    }
    Task<AuditLogModel> ICrudService<AuditLogModel>.CreateAsync(AuditLogModel entity)
    {
      throw new NotImplementedException();
    }

    Task<bool> ICrudService<AuditLogModel>.DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    Task<IEnumerable<AuditLogModel>> ICrudService<AuditLogModel>.GetAllAsync()
    {
      return Task.FromResult(_logger.GetAll());
    }

    Task<IEnumerable<AuditLogModel>> IAuditLog.GetAuditLogByLocationId(int id)
    {
      throw new NotImplementedException();
    }

    Task<IEnumerable<AuditLogModel>> IAuditLog.GetAuditLogByRoomId(int id)
    {
      throw new NotImplementedException();
    }

    Task<IEnumerable<AuditLogModel>> IAuditLog.GetAuditLogByUserId(int id)
    {
      throw new NotImplementedException();
    }

    Task<AuditLogModel?> ICrudService<AuditLogModel>.GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    Task<bool> ICrudService<AuditLogModel>.UpdateAsync(int id, AuditLogModel entity)
    {
      throw new NotImplementedException();
    }
  }
}
